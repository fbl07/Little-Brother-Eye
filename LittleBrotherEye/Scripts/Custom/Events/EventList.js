$(document).ready(function () {

    $("#btnRefreshCurrentEvents").click(function () {
        refreshCurrentEvents();
    });

    $("#btnRefreshPastEvents").click(function () {
        refreshPastEvents();
    });

    function refreshCurrentEvents() {
        $("#btnRefreshCurrentEvents").attr("disabled", "disabled");
        $.ajax({
            url: "/Event/GetCurrentEvents",
            method: "POST",
            success: function (data) {
                $("#CurrentEventGrid").html(data);
                $("#refreshTime").text(moment().format("h:mm:ss a"));
                $("#btnRefreshCurrentEvents").removeAttr("disabled");
                //RefreshDeleteButtons();
            }
        });
    }

    function refreshPastEvents() {
        $("#btnRefreshPastEvents").attr("disabled", "disabled");

        var pastDays = $("#txtPastDays").val();
        if (pastDays && parseInt(pastDays) >= 0) {
            $("#fgPastDays").removeClass("has-error");
            $.ajax({
                url: "/Event/GetPastEvents",
                data: { pastDays: pastDays },
                method: "POST",
                success: function (data) {
                    $("#PastEventGrid").html(data);
                    $("#btnRefreshPastEvents").removeAttr("disabled");
                    //RefreshDeleteButtons();
                }
            });
        }
        else {
            $("#fgPastDays").addClass("has-error");
            $("#btnRefreshPastEvents").removeAttr("disabled");
        }
    }

    //function RefreshDeleteButtons() {
    //    alert("TEST1");
    //    $(".remove").click(function () {
    //        alert("TEST2");
    //        $('#deleteModal').modal({
    //            show:true
    //        });
    //    });
    //}

    $('#deleteModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var id = button.data('event-id') // Extract info from data-* attributes
        
        $("#btnRemoveConfirm").click(function () {
            $.ajax({
                url: '/Event/Delete',
                data: { eventId: id },
                method:'POST',
                success: function (data) {
                    $("#deleteModal").modal('hide');
                }
            });
        });

    })

    $("#deleteModal").on('hide.bs.modal', function () {
        $("#btnRemoveConfirm").off('click');
        refreshCurrentEvents();
        refreshPastEvents();
    });

    refreshCurrentEvents();
    refreshPastEvents();
});