window.globalStyle = [];
window.slides = [];
window.isEdit = false;
window.currentRowIndex = '';
window.currentRowEditIndex = null;
window.currentFile = '';
window.animation = [];
window.count = 0;
window.previousSlideEditIndex = null;
var typingTimer;                //timer identifier
var doneTypingInterval = 1000;




$(function () {
    for (var count = 1; count < 15; count++) {
        $('#fontsizeSelect').append(new Option(count, count));
    }
});


$(document).ready(function () {
    $("#fontsizeSelect").change(function () {
        changeFontSize($(this).val());
        //clearTimeout(typingTimer);
        //typingTimer = setTimeout(doneTyping, doneTypingInterval);

    });
    $("#centerAnchor").on("click", function () {
        document.execCommand('justifyCenter');
        //clearTimeout(typingTimer);
        //typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });
    $("#leftAnchor").on("click", function () {
        document.execCommand('justifyLeft');
        //clearTimeout(typingTimer);
        //typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });
    $("#rightAnchor").on("click", function () {

        document.execCommand('justifyRight');
        //clearTimeout(typingTimer);
        //typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });
    $("#justifyAnchor").on("click", function () {

        document.execCommand('justifyFull');
        //clearTimeout(typingTimer);
        //typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });
    var selectedText = "";
    $("#copyAnchor").on("click", function () {
        selectedText = getSelectionText();
        //  var a = document.execCommand('copy');
        $("#pasteDiv").removeClass("disabled");
    });
    function getSelectionText() {
        var text = "";
        if (window.getSelection) {
            text = window.getSelection().toString();
        } else if (document.selection && document.selection.type != "Control") {
            text = document.selection.createRange().text;
        }
        return text;
    }
      $("#pasteAnchor").on("click", function () {
        //  var a = document.execCommand('paste');
        var caretPos = document.getElementById("slideMainDiv").selectionStart;
        var textAreaTxt = $("#slideMainDiv").val();
        $("#slideMainDiv").val(textAreaTxt.substring(0, caretPos) + selectedText + textAreaTxt.substring(caretPos));
        clearTimeout(typingTimer);
        typingTimer = setTimeout(doneTyping, doneTypingInterval);

    });
    $("#filesTable").on("click", "td", function () {
        window.currentFile = $(this).attr('data-item');
        window.location.href = "../Home/TimeLine/" + window.currentFile + "";

    });
    $("#boldAnchor").on("click", function () {
        callFormatting('Bold');
        //clearTimeout(typingTimer);
        //typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });
    $("#italicsAnchor").on("click", function () {
        callFormatting('Italic');
        //clearTimeout(typingTimer);
        //typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });
    $("#underlineAnchor").on("click", function () {
        callFormatting('Underline');
        //clearTimeout(typingTimer);
        //typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });
    function callFormatting(sFormatString) {
        document.execCommand(sFormatString);
    }
    getSystemFonts();
    $("#fontfamilySelect").change(function () {
        ChangeFont($(this).val());
        //clearTimeout(typingTimer);
        //typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });

});
function changeFontSize(value) {
    var sSelected = value;
    //  var t = document.getSelection();
    //  $(t).css({ 'font-size': sSelected });
    // alert(document.getSelection());
    document.execCommand("FontSize", false, sSelected);
}
function ChangeFont(name) {
    document.execCommand("FontName", false, name);
}

function getSystemFonts() {
    var fonts = [
             'Arial,Arial',
             'Arial Black,Arial Black',
             'Comic Sans MS,Comic Sans MS',
             'Courier New,Courier New',
             'Georgia,Georgia',
             'Impact,Charcoal',
             'Lucida Console,Monaco',
             'Lucida Sans Unicode,Lucida Grande',
             'Palatino Linotype,Book Antiqua',
             'Tahoma,Geneva',
             'Times New Roman,Times',
             'Trebuchet MS,Helvetica',
             'Verdana,Geneva',
             'Gill Sans,Geneva'
    ];
    $(fonts).each(function (index, value) {
        var sp = value.split(",");
        $('#fontfamilySelect').append('<option style="font-family:' + sp[1] + '" value=' + sp[1] + '>' + sp[0] + '</option>');
    });
}









