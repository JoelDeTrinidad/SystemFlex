(function () {
    'use strict';

    angular
        .module('app.resorts.payment_check')
        .controller('PaymentCheckController', PaymentCheckController)

    //$http, $state, $scope, WEBAPI
    function PaymentCheckController($scope, $http, $stateParams, WEBAPI, _, session, paymentModal, toastr) {
        /* viewModels */
        var vm = this;
        //Data
        vm.dataObject = $stateParams.recordStay;
        vm.roomList = [];
        vm.confirmSelection = false;
        vm.roomsObjects = [];
        vm.result;
        vm.users = session.getSession();
        vm.total;
        vm.paymentData;
        var getUserInfoById = vm.users.id;
        vm.dataUserLogged;

        //Methods
        vm.receive = receive;
        vm.AddPaymentDialog = AddPaymentDialog;

        //function to load list of room objects
        function load() {
            $http.get(WEBAPI.URL + '/api/CatalogRooms')
         .success(function (data) {
             vm.roomList = data;
             if (!$scope.$$phase) {
                 $scope.$digest();
             };
         })
         .error(function (status) {

         });
        }


        //function to receive a room 
        function receive(room) {

            //process to receive selected room
            vm.elementReceived = [{ room: room }];
            _.each(vm.elementReceived, function (element, index) {
                if (vm.roomsObjects.length > 0) {
                    vm.roomsObjects[index + 1] = vm.elementReceived[index].room
                    room.disabled = true;
                }
                else {
                    vm.roomsObjects[index] = vm.elementReceived[index].room

                }
            });

            //process to verify if the number of selected room is equal to quantity of room specified in information request
            if (vm.roomsObjects.length == vm.dataObject.roomQuantityCatalog) {
                vm.confirmSelection = true;
                vm.result = vm.confirmSelection;
            }
            else {
                room.disabled = true;
            }

            //process to calculate total price of reserve
            if (vm.roomsObjects.length == 2) {
                var sum = vm.roomsObjects[0].price + vm.roomsObjects[1].price;
                var days = vm.dataObject.days;
                vm.total = days * sum;
            }
            else if (vm.roomsObjects.length == 1) {
                var sum2 = vm.roomsObjects[0].price;
                var days2 = vm.dataObject.days;
                vm.total = days2 * sum2;
            }

        }


        //conditional to verify value null in dataObject
        if (vm.dataObject == null) {
            document.getElementById("payment").style.display = 'none';

            toastr.error('ERROR, Seleccione una solicitud de estancia para realizar este proceso', '', {
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

        }


        loadInfoUser(getUserInfoById);
        //function to load info user logged
        function loadInfoUser(getUserInfoById) {
            $http.get(WEBAPI.URL + '/api/User/GetUserById/{Id}', { params: { Id: getUserInfoById } })
        .success(function (data) {
            vm.dataUserLogged = data;

            if (!$scope.$$phase) {
                $scope.$digest();
            };
        })
          .error(function (status) {

          })
        }


        function AddPaymentDialog(locals) {

            //form data collection
            vm.paymentData = {
                detailId: vm.dataObject.detailId,
                name: vm.dataUserLogged.name,
                lastname: vm.dataUserLogged.lastName,
                email: vm.dataUserLogged.email,
                totalPayment: vm.total,
                payed: true,
                userid: vm.dataUserLogged.id,
                catalogRoom: vm.roomsObjects
            }

            //send data to process payment
            paymentModal.open({
                locals: {
                    payment: vm.paymentData
                }
            });
        }


        /**Format date picker (dd/MM/yyyy) **/
        vm.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate', 'dd/MM/yyyy'];
        vm.format = vm.formats[4];


        load();//load catalog rooms

      

    }
})();
