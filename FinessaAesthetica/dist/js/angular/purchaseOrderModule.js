(function () {
    'use strict';

    angular.module('purchaseOrderModule', [])
    .controller('purchaseOrderCtrl', PurchaseOrderController)
    .factory('dataService', ServiceFactory);

})();