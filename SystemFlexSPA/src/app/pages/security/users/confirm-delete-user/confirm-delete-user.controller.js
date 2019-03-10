(function () {
    'use strict';
    angular
    .module('app.security.users')
    .controller('deletUsersDialogController', deletUsersDialogController);
    /*@ngInject*/
    function deletUsersDialogController($http, locals, WEBAPI, toastr) {
        var vm = this;
        //Data
        vm.locals = locals;
        //Methods
        vm.deleteUser = deleteUser;
        function load() {
         
        }

        function deleteUser() {
            if (vm.locals.users.isActive == true) {
                vm.locals.users.isActive == false;
                $http.post(WEBAPI.URL + '/api/User/DisableUser', vm.locals.users)
                .success(function (data) {
                    console.log(data.data);
                    toastr.success('el Usuario se desactivo correctamente', '', {
                        "autoDismiss": false,
                        "positionClass": "toast-bottom-right",
                        "type": "success",
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
                })
                .error(function (data) {

                });
            }
        }

        load();
    }
})();