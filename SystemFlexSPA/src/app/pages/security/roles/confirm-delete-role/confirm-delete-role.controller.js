(function () {
    'use strict';
    angular
    .module('app.security.roles')
    .controller('DeleteRolesDialogController', DeleteRolesDialogController)
    function DeleteRolesDialogController(locals, WEBAPI, $http, toastr) {
        var vm = this;
        //Data 
        vm.locals = locals;
        //Methods
        vm.deleteRole = deleteRole;

        function deleteRole() {
            $http.delete(WEBAPI.URL + '/api/Role', {
                params: {id: vm.locals.roles.roleId}
        })
            .success(function (data) {
                vm.locals.rolesList = _.reject(vm.locals.rolesList, function rejectRole() { return rejectRole.id == vm.locals.roles.id });
                console.log(data.data);
                toastr.success('Role se elimino correctamente', '', {
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
})();