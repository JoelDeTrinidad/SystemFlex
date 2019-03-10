(function () {
    'use strict'
    angular
    .module('app.security.login')
    .controller('LoginController', LoginController)
    function LoginController($window, $state, $scope, $stateParams, $http, WEBAPI, session, spinnerService, toastr) {
        //Data
        var vm = this;
        //Methods
        vm.login = login;
        $scope.loading = true;
        function login() {
            spinnerService.show('booksSpinner');
            $http.post(WEBAPI.URL + '/api/Login/Account', vm.user)
            .success(function (data) {
                session.setSession(data);
                $state.go('resorts.lodgment', { user: vm.user });
                
            })
            .error(function (data) {
                toastr.error('Usuario o Contraseña incorrecta', '', {
                    "autoDismiss": false,
                    "positionClass": "toast-bottom-right",
                    "type": "error",
                    "timeOut": "5000",
                    "extendedTimeOut": "2000",
                    "allowHtml": false,
                    "closeButton": false,
                    "tapToDismiss": true,
                    "progressBar": false,
                    "newestOnTop": true,
                    "maxOpened": 0,
                    "preventDuplicates": false,
                    "preventOpenDuplicates": false
                });
            }).finally(function () {
                spinnerService.hide('booksSpinner');
            });
           
        }
       
    }
})();