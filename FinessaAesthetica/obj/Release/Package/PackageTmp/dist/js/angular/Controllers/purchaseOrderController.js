var PurchaseOrderController = function ($http) {
    var purchaseOrderCtrl = this;
    purchaseOrderCtrl.isAllRecordSelected = false;
    purchaseOrderCtrl.Quantity = 1;
    var fakeProduct = [
        { Id: 1, Quantity: 0 },
        { Id: 2, Quantity: 0 },
         { Id: 3, Quantity: 0 },
          { Id: 4, ProductCode: 'Product-001', UnitPrice: 'P1,000', Quantity: 0 }, 
        { Id: 5, ProductCode: 'Product-002', UnitPrice: 'P5,000', Quantity: 0  },
        { Id: 6, ProductCode: 'Product-003', UnitPrice: 'P3,000', Quantity: 0 },
        { Id: 7}];
    purchaseOrderCtrl.itemList = [];

purchaseOrderCtrl.list = [
    { Id: 1, Number: 'PO-00001', Remarks: 'Sample Data 1', Status: 'Pending', Supplier: 'Supplier-01', TotalAmount: 'P25,000', TotalQuantity: 5, IsSelected: false },
    { Id: 2, Number: 'PO-00002', Remarks: 'Sample Data 2', Status: 'Pending', Supplier: 'Supplier-02', TotalAmount: 'P5,000', TotalQuantity: 15, IsSelected: false },
    { Id: 3, Number: 'PO-00003', Remarks: 'Sample Data 3', Status: 'Cancelled', Supplier: 'Supplier-03', TotalAmount: 'P2, 000', TotalQuantity: 5, IsSelected: false },
    { Id: 4, Number: 'PO-00004', Remarks: 'Sample Data 4', Status: 'Approved', Supplier: 'Supplier-01', TotalAmount: 'P2, 000', TotalQuantity: 5, IsSelected: false },
    { Id: 5, Number: 'PO-00005', Remarks: 'Sample Data 5', Status: 'Pending', Supplier: 'Supplier-101', TotalAmount: 'P2, 000', TotalQuantity: 5, IsSelected: false }
];




purchaseOrderCtrl.goToFakeReceiving = function (isApproved) {
    if (isApproved) {
        window.location.href = "/PurchaseOrder/Receiving";
    }
}

purchaseOrderCtrl.addRow = function () {
    var selected = $('#product').val();

    if (selected >= 3 && selected <= 5 && selected != "") {
        fakeProduct[selected].Quantity = purchaseOrderCtrl.Quantity
        purchaseOrderCtrl.itemList.push(fakeProduct[selected]);
    }
 
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

    alert('Update Successful!');            
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

PurchaseOrderController.$inject = ['$http'];