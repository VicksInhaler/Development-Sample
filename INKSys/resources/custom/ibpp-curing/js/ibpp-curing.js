var MainTable;
$(document).ready(function () {
    Display();
    $('#btnUpdate').on('click', function () {
        UpdateCuring();
    })
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    function EndRequestHandler(sender, args) {
        Display();
    }
});
$(document).on('click', 'button', function (e) {
    var elem = $(this);
    if (elem.hasClass('btn-update-row')) {
        var data = MainTable.row($(this).closest('tr')).data();
        var id = data[Object.keys(data)[0]];
        var modelcode = data[Object.keys(data)[1]];
        var sflotno = data[Object.keys(data)[5]];
        var sfpartcode = data[Object.keys(data)[6]];
        var sfpartname = data[Object.keys(data)[7]];
        var sfamount = data[Object.keys(data)[8]];
        var bottlelotno = data[Object.keys(data)[9]];
        var bottlepartcode = data[Object.keys(data)[10]];
        var bottleamount = data[Object.keys(data)[11]];
        var cavityno = data[Object.keys(data)[12]];
        var curingline = data[Object.keys(data)[13]];
        $('#txt_ID').val(id);
        $('#lbl_ModelCode').text(modelcode);
        $('#txt_SFLotNo').val(sflotno);
        $('#lbl_SFPartCode').text(sfpartcode);
        $('#txt_SFPartName').val(sfpartname);
        $('#txt_SFFilmAmount').val(sfamount);
        $('#lbl_BottleCode').text(bottlepartcode);
        $('#txtBottleLot').val(bottlelotno);
        $('#txt_BottleAmount').val(bottleamount);
        $('#txt_CavityNo').val(cavityno);
        $('[id*=ddl_CuringMachine]').val(curingline).trigger('change');
    }
});

function Display(callback) {
    $.ajax({
        url: "IBPP_Curing.aspx/getIBPPCuring",
        type: "POST",
        data: "{}",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (e) {
            var d = JSON.parse(e.d);
            if (callback !== undefined) {
                callback(d);
            }
            var btnEdit = '<button type="button" data-toggle="modal" data-target="#ModalEdit" class="btn btn-sm btn-primary btn-update-row" title="Update"><i class="fas fa-edit"></i></button>';
            if (MainTable !== undefined && MainTable !== null) {
                MainTable.clear().destroy();
            }
            MainTable = $(".curing-table").DataTable({
                searching: true,
                paging: true,
                info: true,
                ordering: false,
                scrollX: true,
                scrollY: 400,
            
                data: d,
                columnDefs: [
                    { 'visible': false, 'targets': [1, 13] }
                ],
                columns: [
                    {
                        data: 'ID', title: 'Edit', render: function (e) {
                            return btnEdit;
                        }
                    },
                    { data: 'ID', title: 'ID' },
                    { data: 'PARTCODE', title: 'Part Code' },
                    { data: 'MODEL', title: 'Model' },
                    { data: 'DESTINATION', title: 'Destination' },
                    { data: 'COLOR', title: 'Color' },
                    { data: 'SFLOTNO', title: 'SF Lot No.' },
                    { data: 'SFPARTCODE', title: 'SF PartCode' },
                    { data: 'SFPARTNAME', title: 'SF PartName' },
                    { data: 'SFAMOUNT', title: 'SF Amount' },
                    { data: 'BOTTLELOTNO', title: 'Bottle Lot No.' },
                    { data: 'BOTTLEPARTCODE', title: 'Bottle PartCode' },
                    { data: 'BOTTLEAMOUNT', title: 'Bottle Amount' },
                    { data: 'CAVITYNO', title: 'Cavity No.' },
                    { data: 'CURINGLINE', title: 'Line' },
                    {
                        data: 'DATECREATED', title: 'DATECREATED',
                        render: function (d) {
                            return moment(d).format("MM/DD/YYYY hh:mm:ss A");
                        }
                    },
                    { data: 'WORKSHIFT', title: 'Shift' },
                    { data: 'INCHARGE', title: 'In Charge' },        
                ], createdRow: function (row, data, index) {
                    if (data.WORKSHIFT == 'DS') {
                        $('td:eq(14)', row).css('background-color', '#E6DB63');  //DAY SHIFT
                    } else {
                        $('td:eq(14)', row).css('background-color', '#2E3033');//NIGHTSHIFT
                        $('td:eq(14)', row).css('color', '#fff');
                    }

                    if (data.CURINGLINE == 'A') {
                        $('td:eq(12)', row).css('background-color', ' #00A8C9');  //CURING A
                    } else if (data.CURINGLINE == 'B') {
                        $('td:eq(12)', row).css('background-color', '#DB3EB1'); //CURING B
                    } else {
                        $('td:eq(12)', row).css('background-color', '#C9C900'); //CURING C
                    }
                },
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}
function UpdateCuring() {
   var ID = $('#txt_ID').val();
   var SFLOTNO = $('#txt_SFLotNo').val();
   var SFPARTNAME = $('#txt_SFPartName').val();
   var SFFILMAMOUNT =$('#txt_SFFilmAmount').val();
   var BOTTLELOT = $('#txtBottleLot').val();
   var BOTTLEAMOUNT =$('#txt_BottleAmount').val();
   var CAVIITYNO = $('#txt_CavityNo').val();
   var CURINGLINE = $('[id*=ddl_CuringMachine]').val();
    $.ajax({
        url: "IBPP_Curing.aspx/UpdateIBPPCuring",
        type: "POST",
        data: JSON.stringify({
            id: ID, sflotno: SFLOTNO, sfpartname: SFPARTNAME,
            sfamount: SFFILMAMOUNT, bottlelotno: BOTTLELOT, bottleamount: BOTTLEAMOUNT,
            cavityno: CAVIITYNO, curingline: CURINGLINE
        }),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (e) {
            console.log(e);
            Display();
            $('#ModalEdit').modal('hide');
            updateAlert();        
        },
        error: function (errormessage) {
            console.log(errormessage);
        }
    });

}
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}