(function () {
'use strict';
angular
     .module('app.security.users')
     .controller('addUsersDialogController', addUsersDialogController);
    /** @ngInject */
function addUsersDialogController($http, $scope, WEBAPI, locals, toastr, toastrConfig) {
    var vm = this;
    //Data 
    vm.user = {};
    vm.locals = locals;
    vm.title = '';
    vm.isEdit = false;
    vm.showFieldIsActive = false;
    //methods 
    vm.saveUser = saveUser;
    function init() {
        if (vm.locals.users) {
            vm.title = "Editar Usuario";
            //vm.user = vm.locals.user;
            vm.isEdit = true
            getByUserId(vm.locals.users.id);
            vm.showFieldIsActive = true;
        } else {
            vm.title = "Agregar Usuario";
            vm.isEdit = false;
        };
    }
    
    function getByUserId(id) {
        $http.get(WEBAPI.URL + '/api/User/GetUserById/{Id}', {
            params: {id: id}
        })
         .success(function (data) {
             vm.user = data;
         })
            .error(function (data) {

            })
    }
   
    function saveUser() {
        if (!vm.isEdit) {
            vm.user.isActive = true;
            $http.post(WEBAPI.URL + '/api/user', vm.user)
            .success(function (data) {
                vm.locals.userList.push(data);
                $scope.$apply();
                toastr.success('el Usuario se guardo con exito', '', {
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
        } else {
            $http.put(WEBAPI.URL + '/api/user', vm.user)
            .success(function (data) {
                console.log(data.data);
                $scope.$apply();
                toastr.success('el Usuario se edito correctamente', '', {
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
        };
    }
   
    init();
}
})();