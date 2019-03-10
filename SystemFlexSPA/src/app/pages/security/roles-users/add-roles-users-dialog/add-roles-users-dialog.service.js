(function () {
    'use strict';

    angular.module('app.security.roles_users')
      .service('rolesUsersModal', rolesUsersModal);

    /** @ngInject */
    function rolesUsersModal($uibModal) {

        this.open = function (options, size) {
            return $uibModal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'app/pages/security/roles-users/add-roles-users-dialog/add-roles-users-dialog.html',
                controller: 'addRolesUsersDialogController',
                controllerAs: 'vm',
                size: size,
                resolve: {
                    locals: function () {
                        return options.locals;
                    },
                   
                }
            });
        }

    }

})();