(function () {
    'use strict';
    angular
         .module('app.security.roles_users')
         .controller('addRolesUsersDialogController', addRolesUsersDialogController);
    /** @ngInject */
    function addRolesUsersDialogController($scope, $http, WEBAPI, locals, toastr) {
        var vm = this;
        //Data
        vm.locals = locals;
        vm.roleUser;
        vm.selectUserSearchItems = [];
        vm.selectRoleSearchItems = [];
        //Methods
        vm.saveRoleUser = saveRoleUser;
        function load() {
            getUser();
            getRole();
        }
       
        function getUser() {
            $http.get(WEBAPI.URL + '/api/RolesUsers/GetActiveUser')
            .success(function (data) {
                vm.selectUserSearchItems = data;
                if (!$scope.$$phase) {
                    $scope.$digest();
                };
            })
            .error(function (data) {

            });
        }
        function getRole() {
            $http.get(WEBAPI.URL + '/api/RolesUsers/GetActiveRole')
            .success(function (data) {
                vm.selectRoleSearchItems = data;
                if (!$scope.$$phase) {
                    $scope.$digest();
                };
            })
            .error(function (data) {

            });
        }

        function saveRoleUser() {
            $http.post(WEBAPI.URL + '/api/RolesUsers', vm.roleUser)
            .success(function (data) {
                vm.locals.rolesUsersList.push(data);
                $scope.$apply();
                toastr.success('el perfil Usuario se guardo con exito', '', {
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

        load();
    }
})();