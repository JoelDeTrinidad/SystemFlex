(function () {
    'use strict';

    angular
        .module('app.resorts.payment_check')
        .service('paymentModal', paymentModal);


    function paymentModal($uibModal) {

        this.open = function (options, size) {
            return $uibModal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'app/pages/resorts/payment-check/add-credit-card/add-credit-card.html',
                controller: 'AddPaymentDialogController',
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
