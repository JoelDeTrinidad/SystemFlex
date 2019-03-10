(function () {
'use strict';
angular
    .module('app.security.users')
    .controller('UsersController', UsersController)

    /** @ngInject */
function UsersController($http, $scope, usersModal, WEBAPI, usersDeleteModal) {
    var vm = this;
    //data
    vm.userList = [];
    vm.paginations = 5;

    // Methods
    vm.addOpendialogUsers = addOpendialogUsers;
    vm.deleteUser = deleteUser;
    function init() {
        $http.get(WEBAPI.URL + '/Api/User')
       
          .success(function (data) {
              vm.users = [];
              vm.users = data;
              vm.userList = [].concat(vm.users);
              if (!$scope.$$phase) {
                  $scope.$digest();
              };
          })
            .error(function (data) {
                
            })
 

    }

    function addOpendialogUsers(users) {
        usersModal.open({
            locals: {
                users: users,
                userList: vm.userList,
            }
        });

    }
    function deleteUser(users) {
        usersDeleteModal.open({
            locals: {
                users: users
            }
        });
    }
    init();
}
})();