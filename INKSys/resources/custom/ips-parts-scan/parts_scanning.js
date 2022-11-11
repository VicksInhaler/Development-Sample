$(document).ready(function (e) {
    GetIPSPart();
    $('[id*=btnUpdate]').hide();
    $('[id*=txtID]').attr('disabled', true);
    $('[id*=txtID]').hide();

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    function EndRequestHandler(sender, args) {
        GetIPSPart();
        $('[id*=btnUpdate]').hide();
        $('[id*=txtID]').attr('disabled', true);
        $('[id*=txtID]').hide();
    }
});
var MainTable = $('.partscan').DataTable({
    columnDefs: [
        { 'visible': false, 'targets': [0] }
    ],
    columns: [
        { data: 'ID', title: 'ID' },
        { data: 'BALN', title: 'BOTTLE ASSY LOT' },
        { data: 'BALNAMOUNT', title: 'ASSY AMOUNT' },
        { data: 'CAPLOTNO', title: 'CAP LOT ' },
        { data: 'CAPAMOUNT', title: 'CAP AMOUNT ' },
        { data: 'SPOUTLOTNO', title: 'SPOUT LOT ' },
        { data: 'SPOUTAMOUNT', title: 'SPOUT AMOUNT ' },
        { data: 'SVLN', title: 'SLITVALVE LOT' },
        { data: 'SLITAMOUNT', title: 'SLITVALVE AMOUNT' },
        { data: 'INKLOTNO', title: 'INK LOT' },
        { data: 'PBLN', title: 'PACKBOTTLE' },
        { data: 'LINEMACHINE', title: 'LINE MACHINE' },
   
        {
            data: 'UPDATEDDATE', title: 'Date Time',
            render: function (d) {
                return moment(d).format("MM/DD/YYYY hh:mm:ss A");
            }
        },
        { data: 'UPDATEDBY', title: 'In Charge' },
        {
            data: null,
            title: 'Action',
            className: "dt-center editor-edit",
            defaultContent: '<button type="button" class="btn-xs btn-info"><i class="fas fa-pencil-alt"></i></button>',
            orderable: false
        }
    ],
    searching: true,
    paging: true,
    info: true,
    ordering: false,
    scrollX: true
});
$('.partscan').DataTable();

function GetIPSPart() {
    $.ajax({
        type: "POST",
        url: "IPS_Dashboard.aspx/GetIPSPart",
        data: "{}",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (e) {
            var d = JSON.parse(e.d);
            //console.log(d);
            $('.partscan').DataTable().clear().destroy();
            if ($.fn.dataTable.isDataTable('.partscan')) {
                $('.partscan').DataTable().clear();
                $('.partscan').DataTable().destroy();
                $('.partscan').empty();
                $('.partscan').addClass("table  table-bordered table-hover");
                $('.partscan').css("width", "100%")
            }

            MainTable = $('.partscan').DataTable({

                data: d,
            
                columns: [
                
                    { data: 'ID', title: 'ID' },
                    {
                        data: null,
                        title: 'Action',
                        className: "dt-center editor-edit",
                        defaultContent: '<button type="button" class="btn-xs btn-info"><i class="fas fa-pencil-alt"></i></button>',
                        orderable: false
                    },
                    { data: 'BALN', title: 'BOTTLE ASSY LOT' },             
                    { data: 'BALNAMOUNT', title: 'ASSY AMOUNT' },             
                    { data: 'CAPLOTNO', title: 'CAP LOT ' },
                    { data: 'CAPAMOUNT', title: 'CAP AMOUNT ' },
                    { data: 'SPOUTLOTNO', title: 'SPOUT LOT ' },
                    { data: 'SPOUTAMOUNT', title: 'SPOUT AMOUNT ' },
                    { data: 'SVLN', title: 'SLITVALVE LOT' },     
                    { data: 'SLITAMOUNT', title: 'SLITVALVE AMOUNT' },     
                    { data: 'INKLOTNO', title: 'INK LOT' },
                    { data: 'PBLN', title: 'PACKBOTTLE' },
                    { data: 'LINEMACHINE', title: 'LINE MACHINE' },
         
                    {  
                        data: 'UPDATEDDATE', title: 'Date Time',
                        render: function (d) {
                            return moment(d).format("MM/DD/YYYY hh:mm:ss A");
                        }
                    },
                    { data: 'UPDATEDBY', title: 'In Charge' }, 
                    
                ],      
                searching: true,
                paging: true,
                info: true,
                ordering: false,
                scrollX: true
            });

            $('.partscan').on('click', 'td.editor-edit', function (e) {
                $('[id*=btnUpdate]').show();
                var table = $('.partscan').DataTable();
                var data = MainTable.row($(this).closest('tr')).data();
                var id = data[Object.keys(data)[0]];
                var bottleassy = data[Object.keys(data)[1]];
                var balnamount = data[Object.keys(data)[2]];
                var cap = data[Object.keys(data)[3]];
                var capamount = data[Object.keys(data)[4]];
                var spout = data[Object.keys(data)[5]];
                var spoutamount = data[Object.keys(data)[6]];
                var slitvalve = data[Object.keys(data)[7]];
                var slitamount = data[Object.keys(data)[8]];
                var ink = data[Object.keys(data)[9]];
                var packbottle = data[Object.keys(data)[10]];
                var linemachine = data[Object.keys(data)[11]];
    
                $('[id*=btnSave]').hide();
                $('[id*=btnUpdate]').show();
                $('[id*=txtID]').val(id);
                $('[id*=txtBottleAssy]').val(bottleassy);
                $('[id*=txtBaAmount]').val(balnamount);
                $('[id*=txtCap]').val(cap);
                $('[id*=txtCapAmount]').val(capamount);
                $('[id*=txtSpout]').val(spout);
                $('[id*=txtSpoutAmount]').val(spoutamount);
                $('[id*=txtSlitvalve]').val(slitvalve);
                $('[id*=txtSlitAmount]').val(slitamount);
                $('[id*=txtPackBottle]').val(packbottle);
                $('[id*=txtInk]').val(ink);
                $('[id*=ddlLineMachine]').val(linemachine).trigger('change');
       
            })
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
