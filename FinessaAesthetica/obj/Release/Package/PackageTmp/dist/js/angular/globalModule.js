(function () {
    'use strict';

    angular.module('globalModule', [])
    .controller('globalCtrl', GlobalController)
    .controller('supplierCtrl', SupplierController)
    .controller('purchaseOrderCtrl', PurchaseOrderController)
    .controller('receivingCtrl', ReceivingController)
    .factory('dataService', ServiceFactory);

})();