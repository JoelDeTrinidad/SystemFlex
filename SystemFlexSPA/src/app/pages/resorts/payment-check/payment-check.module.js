(function () {
    'use strict';

    angular
        .module('app.resorts.payment_check', [])
      .config(routeConfig);


    function routeConfig($stateProvider) {
        $stateProvider
          .state('resorts.payment_check', {
              url: '/ComprobanteDePago',
              params: {
                  recordStay: null
              },
              templateUrl: 'app/pages/resorts/payment-check/payment-check.html',
              controller: 'PaymentCheckController as vm',
              title: 'Comp. de pago',
              sidebarMeta: {
                  order: 3,
              },
          });
    }
})();