(function () {
    'use strict';

    angular.module('app.security.users')
      .service('usersModal', usersModal);

    /** @ngInject */
    function usersModal($uibModal) {
        this.open = function (options,size) {
            return $uibModal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'app/pages/security/users/add-user-dialog/add-user-dialog.html',
                controller: 'addUsersDialogController',
                controllerAs: 'vm',
                size: size,
                resolve: {
                    locals: function () {
                        return options.locals;
                    }
                }
               
            });
        }

    }

})();