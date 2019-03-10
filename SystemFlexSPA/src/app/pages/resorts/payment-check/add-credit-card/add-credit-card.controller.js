(function () {
	'use strict';

	angular
        .module('app.resorts.payment_check')
        .controller('AddPaymentDialogController', AddPaymentDialogController);
	/** @ngInject */
	function AddPaymentDialogController($http, $state, locals, WEBAPI, toastr) {
		var vm = this;

		//Data
		vm.isEdit = false;
		vm.title = '';
		vm.locals = locals;

		//methods
		vm.dtPickeropen1 = dtPickeropen1;
		vm.savePayment = savePayment;


		function init() {
		    if (vm.locals.payment) {
				vm.title = 'Metodo de pago';
				vm.payment = angular.copy(vm.locals.payment);
				vm.isEdit = true;
		    } else {
                 //======nothing to do==========//
				//vm.title = 'Metodo de pago';
				//vm.isEdit = false;
			}

		}


		function dtPickeropen1() {
		    vm.popup1.opened = true;
		};

		vm.popup1 = {
		    opened: false
		};


		

		function savePayment() {
		    var payTransaction = { numbercard: vm.numbercard, expiration: vm.expiration, code: vm.code };
		    vm.allData = _.extend(vm.locals.payment, { paymentTransaction: payTransaction })
			if (vm.isEdit) {
			    $http.post(WEBAPI.URL + '/api/PaymentCheck', vm.allData)
                   .success(function (status) {
                       //if status 200 ok
                       if (status == "OK") {
                           toastr.success('Pago realizado con exito', '', {
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

                           $state.go('resorts.recordstay', null);
                       }
                  
                   })
                .error(function (status) {

                    toastr.error("ERROR interno del servidor!", '', {
                        "autoDismiss": false,
                        "positionClass": "toast-bottom-right",
                        "type": "error",
                        "timeOut": "3000",
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



                });
			}

		}

		init();
	}
})();
