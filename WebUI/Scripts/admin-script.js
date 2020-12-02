// JS Product

$(document).on("click", ".tab-title", function SetActiveTab() {
    var TabName = $(this).attr("id");
    switch (TabName) {
        case "tab1":
            $(".tab2, .tab3").removeClass("active-tab");
            $("#tab2, #tab3").removeClass("active-title");
            $(".tab1").addClass("active-tab");
            $("#tab1").addClass("active-title");
            break;
        case "tab2":
            $(".tab1, .tab3").removeClass("active-tab");
            $("#tab1, #tab3").removeClass("active-title");
            $(".tab2").addClass("active-tab");
            $("#tab2").addClass("active-title");
            break;
        case "tab3":
            $(".tab2, .tab1").removeClass("active-tab");
            $("#tab2, #tab1").removeClass("active-title");
            $(".tab3").addClass("active-tab");
            $("#tab3").addClass("active-title");
            break;
    }
})
//$(document).on("click", ".options-head", function () {
//    var parentTab = $(this).parents(".options-block");
//    bodyTab = parentTab.find(".options-body");

//    if (parentTab.hasClass("active_block")) {
//        parentTab.removeClass("active_block");
//        bodyTab.slideUp();
//    } else {
//        parentTab.addClass("active_block");
//        bodyTab.slideDown();
//    }

//})
$(".opt-head:first").addClass("active-tab-head");
$(".opt-body:first").addClass("active-tab-body");

$(document).on("click", ".opt-head", function SetActiveTab() {
    var TabName = $(this).attr("id");
    $(".opt-head").removeClass("active-tab-head");
    $(".opt-body").removeClass("active-tab-body");
    $(this).addClass("active-tab-head");
    $(".options-tabs").find("." + TabName).addClass("active-tab-body");
})

$(document).on("click", "#Submit", function () {
    $('#SelectedGame').val($('#Game_Name').val())
    $('#SelectedCategory').val($('#Category_Name').val())
    $('#SelectedMetaTagTitle').val($('#Meta_tag_title').val())
})
$(document).on("click", "#goToProdOptions", function () {
    $(this).closest("form").attr("action", "/admin/SaveProduct?navigateToProdOpt=true");
    $('#SelectedGame').val($('#Game_Name').val())
    $('#SelectedCategory').val($('#Category_Name').val())
    $('#SelectedMetaTagTitle').val($('#Meta_tag_title').val())
})
$(document).on("click", ".option-add", function () {
    $.ajax({
        cache: false,
        type: 'POST',
        url: '/admin/AddOption',
        data: {
            optionName: $("#Template_Options").val(),
            prodId: $("#ProductId").val()
        },
        success: function (data) {
            $(".tab3 .newOptions").before(data);
            window.location.reload();

        },
        error: function (ex) {
            alert('Failed to add option.' + ex);
        }
    });
})
$(document).on("click", ".remove-option", function () {
    var confirm = confirm("Are you sure you want to delete" );
    if (confirm == true) {
        $.ajax({
            cache: false,
            type: 'POST',
            url: '/admin/RemoveOption',
            data: {
                optionId: $(this).closest('.options-tabs').find("#OptionId").val(),
                prodId: $("#ProductId").val()
            },
            success: function (data) {
                window.location.reload();
            },
            error: function (ex) {
                alert('Failed to remove option.' + ex);
            }
        });
    } 

})
$(document).on("click", ".remove-param", function () {
    $.ajax({
        cache: false,
        type: 'POST',
        url: '/admin/RemoveParam',
        data: {
            optionId: $(this).closest('.options-tabs').find("#OptionId").val(),
            paramId: $(this).find("#paramId").val()
        },
        success: function (data) {
            window.location.reload();
        },
        error: function (ex) {
            alert('Failed to remove param.' + ex);
        }
    });
})
$(document).on("click", ".param-add", function () {
    if ($(this).closest(".add-param-block").find("#Parameter_Parent").val().toString() != "") {
        $.ajax({
            cache: false,
            type: 'POST',
            url: "/admin/AddParam",
            data: {
                optionName: $(this).closest('.add-param-block').find("#OptionName").val(),
                paramName: $(this).closest(".add-param-block").find("#Parameter_Parent").val(),
                ProdOptId: $(this).closest('.options-tabs').find("#OptionId").val()
            },
            success: function (data) {
                $(".param-list").append(data);
                window.location.reload();
            },
            error: function (ex) {
                alert('Failed to add option.' + ex);
            }
        });
    }
    else {
        alert("Can't add Empty Option");
    }
})
$(document).ready(function () {
    $('select').selectpicker({
        liveSearch: true
    });
});


