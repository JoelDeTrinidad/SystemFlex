(function () {
    'use strict';

    angular
        .module('app.security.roles')
        .controller('AddRolesDialogController', AddRolesDialogController);
    /** @ngInject */
    function AddRolesDialogController($http, locals, WEBAPI, toastr) {
        var vm = this;

        //Data
        vm.role = {};
        vm.isEdit = false;
        vm.title = '';
        vm.locals = locals;

        //methods
        vm.saveRole = saveRole;


        function init() {
            if (vm.locals.roles) {
                vm.title = 'Editar perfil';
                vm.role = angular.copy(vm.locals.roles);
                vm.isEdit = true;
            } else {
                vm.title = 'Agregar perfil';
                vm.isEdit = false;
            }

        }


        function saveRole() {
            if (!vm.isEdit) {
                $http.post(WEBAPI.URL + '/api/Role', vm.role)
                   .success(function (data) {
                       vm.locals.rolesList.push(data);
                       toastr.success('Role se guardo con exito', '', {
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
                .error(function (status) {

                });
            }
            else {
                $http.put(WEBAPI.URL + '/api/Role',vm.role)
                    .success(function (data) {
                        console.log(data.data);
                        toastr.success('Role se edito correctamenta', '', {
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
                 .error(function (status) {

                 });

            }


        }

        init();
    }
})();
