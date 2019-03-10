(function () {
    'use strict';

    angular
        .module('app.security.roles')
        .controller('RolesController', RolesController)


    function RolesController($http, $scope, rolesModal, deleteRolesModal, WEBAPI) {
        var vm = this;
        //Data
        vm.rolesList = [];
        vm.paginations = 5;

        //Methods
        vm.AddRolesDialog = AddRolesDialog;
        vm.DeleteRole = DeleteRole;
       
        function load() {
            $http.get(WEBAPI.URL + '/api/Role')
              .success(function (data) {
                  vm.roles = [];
                  vm.roles = data;
                  vm.rolesList = [].concat(vm.roles);
                  if (!$scope.$$phase) {
                      $scope.$apply();
                  };
              })
                .error(function (status) {

                });
        }


        function AddRolesDialog(roles, locals) {
            rolesModal.open({
                locals: {
                    roles: roles,
                    rolesList: vm.rolesList
                }
            });
        }


        //show delete dialog
        function DeleteRole(roles) {
            deleteRolesModal.open({
                locals: {
                    roles: roles,
                    rolesList: vm.rolesList
                }
            });
        }


        ////function for delete
        //function deleteRecord(roles) {

        //    $http.delete(WEBAPI.URL + '/api/Role', { id: roles.id })
        //       .success(function (data) {
        //           vm.rolesList = _.reject(vm.rolesList, function (rolesReject) { return rolesReject.id == role.id; });
        //       })
        //        .error(function (status) {

        //        });
        //}
        load();
    }
})();
