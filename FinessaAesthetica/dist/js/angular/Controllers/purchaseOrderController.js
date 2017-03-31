var PurchaseOrderController = function ($http, dataService) {
    var purchaseOrderCtrl = this;

    purchaseOrderCtrl.isAllRecordSelected = false;
    purchaseOrderCtrl.Quantity = 1;
    purchaseOrderCtrl.itemList = [];
    purchaseOrderCtrl.remarks = "";
    purchaseOrderCtrl.supplierId = 0;   

    purchaseOrderCtrl.initData = function () {
        // get purchase order
        dataService.get('/api/PurchaseOrder/').then(function (data) {

            var obj = [];
            for (var i = 0; i < data.length; i++) {
                obj.push({ IsSelected: false });
            }

            purchaseOrderCtrl.list = angular.merge({}, data, obj);
        });
    }

    purchaseOrderCtrl.getProducts = function () {
        // get products 
        dataService.get('/api/Product/').then(function (data) {
            var obj = [];
            for (var i = 0; i < data.length; i++) {
                obj.push({ IsSelected: false });
            }
            purchaseOrderCtrl.productList = angular.merge({}, data, obj);
        });
    }

    purchaseOrderCtrl.getSuppliers = function () {
        // get products 
        dataService.get('/api/Supplier/').then(function (data) {
            var obj = [];
            for (var i = 0; i < data.length; i++) {
                obj.push({ IsSelected: false });
            }

            purchaseOrderCtrl.supplierList = angular.merge({}, data, obj);
        });
    }

    purchaseOrderCtrl.goToFakeReceiving = function (isApproved) {
        if (!isApproved) {

        }
        //if (isApproved) {
        //    window.location.href = "/PurchaseOrder/Receiving";
        //}

    }

    purchaseOrderCtrl.addRowToItems = function (product, quantity) {

        if (typeof product === 'undefined') return;

        var result = false;

        angular.forEach(purchaseOrderCtrl.itemList, function (value, index) {
            if (value.ProductId == product.ProductId) {
                result = true;
                value.Quantity += quantity;
            }
        });

        if (result) return;

        purchaseOrderCtrl.itemList.push({
            ProductId: product.ProductId,          
            Quantity: quantity,
            ProductCode: product.ProductCode,
            UnitPrice: product.UnitPrice
        });
    }

    purchaseOrderCtrl.removeRowToItems = function (index) {
        purchaseOrderCtrl.itemList.splice(index, 1);
    }

    purchaseOrderCtrl.save = function () {

        console.log(purchaseOrderCtrl.supplierId);

        var newRecord = {
            PurchaseOrderId: 0,
            SupplierId: purchaseOrderCtrl.supplierId.SupplierId,
            PurchaseOrderItems: purchaseOrderCtrl.itemList,
            Remarks: purchaseOrderCtrl.remarks,
            TotalAmount: 0,
            TotalProductQuantity: 0
        }

        angular.forEach(newRecord.PurchaseOrderItems, function (value, index) {
            newRecord.TotalAmount += value.UnitPrice * value.Quantity;
            newRecord.TotalProductQuantity += value.Quantity;
        });     


        var json = JSON.stringify(newRecord);

        $.ajax({
            type: 'POST',
            url: '/api/PurchaseOrder/CreatePurchaseOrder',
            contentType: "application/json; charset=utf-8",
            async: true,
            cache: false,
            data: json
        }).then(function () {
            alert('succesfully saved!');
            window.location.href = '/PurchaseOrder/';
        });
    }


    purchaseOrderCtrl.changeStatus = function (status) {

        var list = []

        angular.forEach(purchaseOrderCtrl.list, function (item, index) {

            if (item.IsSelected == true) {
                list.push(item);
            }

        });

        if (list.length <= 0) {
            alert('select a record first.');
            return;
        }

        angular.forEach(list, function (item, index) {
            item.Status = status;
        });

        var json = JSON.stringify(list);

        $.ajax({
            type: 'PUT',
            url: '/api/PurchaseOrder/UpdatePurchaseOrder',
            contentType: "application/json; charset=utf-8",
            async: true,
            cache: false,
            data: json
        }).then(function () {
            alert('Update Successful!');
            window.location.reload(true);
        });

       
    }

    purchaseOrderCtrl.selectAll = function () {
        var result = purchaseOrderCtrl.isAllRecordSelected;

        if (result == false) {
            result == true;
            purchaseOrderCtrl.isAllRecordSelected = result;
        }
        else {
            result == false;
            purchaseOrderCtrl.isAllRecordSelected = result;
        }

        angular.forEach(purchaseOrderCtrl.list, function (item, index) {
            item.IsSelected = result;
        });
    }

    purchaseOrderCtrl.selectSingle = function (item) {
        if (item.IsSelected == true) {
            item.IsSelected = false;
        }
        else {
            item.IsSelected = true;
        }
    }

    purchaseOrderCtrl.selectRow = function (data) {
        data.IsSelected = true;
        data.isAllRecordSelected = false;

        angular.forEach(purchaseOrderCtrl.list, function (item, index) {

            if (data.Id != item.Id) {
                item.IsSelected = false;
            }

        });
    }

    purchaseOrderCtrl.deleteRecord = function (index) {
        if (confirm('Are you sure you want to delete this record?')) {
            purchaseOrderCtrl.list.splice(index, 1);
        }
    }
};

PurchaseOrderController.$inject = ['$http', 'dataService'];