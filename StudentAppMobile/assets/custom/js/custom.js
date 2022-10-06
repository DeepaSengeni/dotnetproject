//$.noConflict();


jQuery(document).ready(function () {

  //jQuery('.home-item').find('textarea').each(function () {
  //  jQuery(this).attr('readonly', 'readonly');
  //});

  //jQuery('.add-notebook-editor').attr('disabled', true);
  ////jq(answer_span).find('textarea').attr('readonly', 'readonly');

  //jQuery('.KeyboardKey').on('click', function () {
  //  jQuery('.add-notebook-editor').find('div').each(function () {
  //    jQuery(this).attr('disabled', true);
  //  });

  //})

 
})

jQuery(document).ready(function () {
    Calculator.init();
    Calculator.initKeyboard();
    Calculator.attachEvent();

})

jQuery(document).ready(function () {
    if (jQuery('#hdnPageType').val() == 'Text') {
        if (jQuery('#editorDiv').find('.childEditor').length == 0) {
            jQuery('#editorDiv').append('<div class="childEditor" ><div contenteditable="true" id="editor"  style="min-height:100%;width:100%;float:left;display:inline-block;z-index:999;position:relative;height:770px;"><div></div>');
        }
        else {
            jQuery('#editorDiv').find('.childEditor').css('height', '100%');
            var textHtml = jQuery('#editorDiv').find('.childEditor').html();
            jQuery('#editorDiv').find('.childEditor').html('<div contenteditable="true" id="editor"  style="min-height:100%;width:100%;float:left;display:inline-block;z-index:999;position:relative;height:770px;">' + textHtml + '<div>');
        }
        var lineHeight = parseInt(jQuery('#editor').css('line-height'));
        //var ce = jQuery('#editable')[0].getClientRects();
        var ce = jQuery('#editor').offset();

        jQuery('#editor').bind('keypress', function (e) {
            var lineCount = jQuery('#editor').height() / lineHeight;
            //alert(jQuery(window).scrollTop());
            if (window.getSelection) {
                var save = window.getSelection();
                var s = window.getSelection();
                //s.modify('extend', 'forward', 'character');
                // s.modify('extend','forward','line');
                range = s.getRangeAt(0);
                var p = range.getClientRects();
                var top;
                //console.log(p);
                if (typeof p[1] != "undefined") {
                    top = p[1].top + jQuery(window).scrollTop();
                } else if (typeof p[0] != "undefined") {
                    top = p[0].top + jQuery(window).scrollTop();
                }
                else {
                    // sigh... let's make a real work around then
                    range.insertNode(jQuery('<canvas />').attr('id', 'tempCaretFinder')[0]);
                    var p = jQuery('canvas#tempCaretFinder').offset();
                    jQuery('canvas#tempCaretFinder').remove();
                    top = p.top;

                }

                // console.log(top-ce.top);
                var lineNumber = (Math.ceil((top - ce.top) / lineHeight));

                if ((lineNumber + 1) > 26 || lineNumber > 25) {
                    alert('You can not write more on this page. Try adding a new page.');
                    return false;
                }

                console.log("Caret line: " + (Math.ceil((top - ce.top) / lineHeight)));



            } else if (document.selection) {
                // the IE way, which should be relatively easier. as TextRange objects return offsets directly.
                range = document.selection.createRange();
            }

        });
    }

    // var lineNumber = 0;
    //  $set = "true";
    jQuery('.slider').slider()
    jQuery("#divProcessing").hide();

    jQuery(".key").click(function () {

        jQuery(".popx").toggle();
        gotoQWETY();
    });

    jQuery('.write').click(function () {
        if (jQuery('#editorDiv').find('.childEditor').length == 0) {
            jQuery('#editorDiv').append('<div class="childEditor" ><div contenteditable="true" id="editor" style="min-height:100%;width:100%;float:left;display:inline-block;z-index:999;position:relative;height:770px;"><div></div>');
        }
        var lineHeight = parseInt(jQuery('#editor').css('line-height'));
        //var ce = jQuery('#editable')[0].getClientRects();
        var ce = jQuery('#editor').offset();

        jQuery('#editor').bind('keypress', function (e) {
            var lineCount = jQuery('#editor').height() / lineHeight;
            //alert(jQuery(window).scrollTop());
            if (window.getSelection) {
                var save = window.getSelection();
                var s = window.getSelection();
                //s.modify('extend', 'forward', 'character');
                // s.modify('extend','forward','line');
                range = s.getRangeAt(0);
                var p = range.getClientRects();
                var top;
                //console.log(p);
                if (typeof p[1] != "undefined") {
                    top = p[1].top + jQuery(window).scrollTop();
                } else if (typeof p[0] != "undefined") {
                    top = p[0].top + jQuery(window).scrollTop();
                }
                else {
                    // sigh... let's make a real work around then
                    range.insertNode(jQuery('<canvas />').attr('id', 'tempCaretFinder')[0]);
                    var p = jQuery('canvas#tempCaretFinder').offset();
                    jQuery('canvas#tempCaretFinder').remove();
                    top = p.top;

                }

                // console.log(top-ce.top);
                var lineNumber = (Math.ceil((top - ce.top) / lineHeight));

                if ((lineNumber + 1) > 26 || lineNumber > 25) {
                    alert('You can not write more on this page. Try adding a new page.');
                    return false;
                }

                console.log("Caret line: " + (Math.ceil((top - ce.top) / lineHeight)));
                //save.modify('move', 'backward', 'character');
                /*
                range = s.getRangeAt(0);
               range.insertNode(jQuery('<canvas />').attr('id','tempCaretFinder')[0]);
                var p = jQuery('canvas#tempCaretFinder').position();
                jQuery('canvas#tempCaretFinder').remove();
                console.log("Caret line: "+(Math.ceil((p.top-ce.top)/lineHeight)+1));
                console.log(e.which);

                switch(e.which){
                    case 40:
                      s.modify("move", "forward","line");

                      break;
                             case 38:
                      s.modify("move", "backward","lineboundary");

                      break;
                }
                */


            } else if (document.selection) {
                // the IE way, which should be relatively easier. as TextRange objects return offsets directly.
                range = document.selection.createRange();
            }

        });
        //jQuery("#editor").keypress(function (event) {
        //    var key = event.key;

        //    if (key == 'Enter') {
        //        lineNumber++;
        //    }
        //    var divheight = jQuery("#editor").height();
        //    var lineheight = jQuery("#editor").css('line-height').replace("px", "");
        //    var lineCount = Math.round(divheight / parseInt(lineheight));
        //    if (lineCount > 25) {

        //        if (lineNumber > 25) {

        //            alert('You can not write more on this page. Try adding a new page.');
        //            return false;
        //        }



        //    }
        //});
        //jQuery(document).on("click", "#editor", function (event) {
        //    var thisEl = jQuery(this);
        //    var clickOffset = event.pageY - thisEl.offset().top;
        //    var lineHeight = thisEl.height() / thisEl.find('br').length;
        //    lineNumber = Math.floor(clickOffset / lineHeight);
        //    alert(lineNumber);

        //});
        jQuery('.childEditor').css('max-width', jQuery(window).width() + 'px');
        //jQuery('#editorDiv').css('max-width', jQuery(window).width() + 'px !important');
        //jQuery('.childEditor').attr('contenteditable', true);
        jQuery('.write').attr('disabled', 'disabled');
        jQuery('.key').removeAttr('disabled');
        // placeCaretAtEnd(document.getElementsByClassName("childEditor"));
    });

    jQuery('.exit').click(function () {
        window.location = "/Home/Home";
    });
    //jQuery(document).on('keyup', function () {
    //    if (jQuery('#editor').text().length == 0) {
    //        jQuery('#editor').empty();
    //    }
    //});

    jQuery('.Save').click(function () {

        //alert();
        if (jQuery('#model_content_page').val().length == 0) {

            jQuery('#content_PageNo_error').html('page no is required')
            return false;
        }
        else {

            jQuery('#content_PageNo_error').html('')
            jQuery('.close').click();

        }
    });
    jQuery('#submit_head').click(function () {

        if (jQuery('#model_content_heading').val().length == 0) {

            jQuery('#content_heading_error').html('Heading is required');
            return false;
        }
        else {
            // return true;
            jQuery('#content_heading_error').html('');

        }

        var heading = '<h2 style="font-size:28px;color:#3ba9e0;text-transform:capitalize;">' + jQuery('#model_content_heading').val() + '' + '</h2>';
        jQuery('#editor').append(heading);
        jQuery('#editor').append('<br>');


        jQuery('#model_content_heading').val('');
        jQuery('#close').click();
        // alert(jQuery('#model_content_heading').length);

    });

    jQuery('#submit_Chapter').click(function () {
        // alert(jQuery('#model_content_Chapter').val());

        if (jQuery('#model_content_Chapter').val().length == 0) {

            //jQuery('#content_Chapter_error').html('Chapter Name is required');
            //return false;
        }
        else {
            jQuery('#content_Chapter_error').html('');
            jQuery('#ChapterTitle').html(jQuery('#model_content_Chapter').val());
            jQuery('#ChapterName').val(jQuery('#model_content_Chapter').val());
        }
        jQuery('#closeChapter').click();
    });



    var validFileExtensions = [".png", ".gif", ".bmp", ".jpeg", ".jpg", ".tif", ".tiff", ".jif", ".jfif", ".jp2", ".jpx", ".j2k", ".j2c", ".psd", ".pspimage", ".thm", ".yuv", ".ai", ".drw", ".eps", ".ps", ".svg", ".fpx", ".pcd"];

    jQuery('#model_content_image').on('change', function (ev) {
        jQuery('#ImageClose').click();
        jQuery('#ImageName').val(this.files[0].name);
        var extension = '.' + this.files[0].name.replace(/^.*\./, '');
        if (validFileExtensions.indexOf(extension) != -1) {
            var reader = new FileReader();
            reader.onload = function (e) {
                jQuery('#ImageSrc').val(e.target.result);
                loadImgInCanvas(e.target.result, 0, 0);
                // $set = "true";
                //jQuery('#ImageSrc').val(e.target.result);
                //jQuery('#Tools').click();
                //jQuery('#canvasDiv').html('');
                //jQuery('#canvasDiv').html('<canvas id="CanvasImage" style="max-width: 100%;"></canvas>');
                //Caman("#CanvasImage", e.target.result, function () { });
                //alert(jQuery('#ImageName').val());


            }
            reader.readAsDataURL(jQuery(this)[0].files[0]);
        }
        else {
            alert('Please choose valid image file, Allowed file types are \n\n' + validFileExtensions.join(' , '))
            return false;
        }
    });











    jQuery('#model_content_Chapter').on("blur", function () {
        checkpageExistence();

    });


    jQuery('.submit').click(function () {

        checksubmitformcount = 1;
        jQuery('#PageNumber').val(jQuery('#model_content_page').val());
        if (jQuery('#PageNumber').val().length == 0) {
            alert('Please add a page number');
            return false;
        }
        else if (jQuery('#hdnPageType').val() == "Text") {
            //if (jQuery('#ChapterName').val().length == 0) {
            //    // jQuery('#content_Chapter_error').html('Chapter Name is required')
            //    alert('Please add a Chapter');
            //    return false;
            //}
            //else {
            TakeScreenShot();
            while (jQuery(".childEditor").find('div:not(.imageContainer )').length > 0) {
                jQuery(".childEditor").find('div:not(.imageContainer )').each(function () {
                    var data = jQuery(this).html();

                    jQuery(this).replaceWith(data);

                });

            }
            datahtml = jQuery(".childEditor").html();

            var chapter = jQuery('#editorDiv').find('div').eq(0).html();
            jQuery('#Content').val('<div>' + chapter + '</div><div class="childEditor" style="height:100%">' + datahtml + '</div>');

            return true;
            //}
        }
        else {
            jQuery('#NotebookForm').submit();
        }

    });
    jQuery('#editorDiv').bind("DOMSubtreeModified", function () {
        jQuery('#type').val('change');
    });

    jQuery('.new').click(function () {
        jQuery('#ChapterName').val(jQuery('#model_content_Chapter').val());
        if (jQuery('#type').val() == 'change') {
            var cnfrm = confirm("Do you want to Save Current Detail before opening new page?");
            if (cnfrm) {
                jQuery('#Content').val(jQuery('#editor').html());
                jQuery('#PageNumber').val(jQuery('#model_content_page').val());
                if (jQuery('#PageNumber').val().length == 0) {
                    alert('Please add a page number');
                    return false;
                }
                else if (jQuery('#ChapterName').val().length == 0) {
                    // jQuery('#content_Chapter_error').html('Chapter Name is required')
                    alert('Please add a Chapter');
                    return false;
                }
                else {
                    jQuery('div').removeAttr('contenteditable');
                    TakeScreenShot();

                    //return true;
                }

            }
            else {

                window.location = "/User/AddNotebook?bookId=" + jQuery('#NotebookId').val() + "";
                return false;
            }
        }
        else {
            alert('You are already have new page!');
            return false;
        }
    });

    jQuery('#model_content_page').on('change', function () {

        if (jQuery.isNumeric(jQuery(this).val())) {
            checkpageExistence();
        }
        else {
            jQuery(this).val('');
        }
    });
    jQuery('#model_content_page').on('blur', function () {

        if (jQuery.isNumeric(jQuery(this).val())) {
            checkpageExistence();
        }
        else {
            jQuery(this).val('');
        }
    });

    // jQuery('#startwriting').trigger('click');

    if (jQuery('input[name=pageType]:checked').val() == "Text") {
        setCaret();
    }
});

function setCaret() {
    var el = document.getElementById("editor");
    placeCaretAtEnd(el);

}


function backspaceFunction() {
    if (jQuery("#editor").text().length == 0) {
        jQuery('#editor').empty();
    }
    jQuery("#editor").sendkeys("{backspace}");
}
function deleteFunction() {
    if (jQuery("#editor").text().length == 0) {
        jQuery('#editor').empty();
    }
    jQuery("#editor").sendkeys("{del}");
}


function selectText(hexColor) {
    var selection = window.getSelection().getRangeAt(0);
    var selectedText = selection.extractContents();
    var span = document.createElement('span');
    span.style.backgroundColor = hexColor;
    span.className = 'selected-text';
    span.appendChild(selectedText);

    selection.insertNode(span);

    if (jQuery(span)[0].nextSibling.nodeValue.charAt(0) == '') {
        jQuery(span).after("&nbsp;");
    }

}

function unselectText() {
    jQuery('#editor').find('.selected-text').contents().unwrap();;
}

jQuery('.marker').on('click', function () {
    selectText('#f90');

});



function placeCaretAtEnd(el) {
    el.focus();
    if (typeof window.getSelection != "undefined"
        && typeof document.createRange != "undefined") {
        var range = document.createRange();
        range.selectNodeContents(el);
        range.collapse(false);
        var sel = window.getSelection();
        sel.removeAllRanges();
        sel.addRange(range);
    } else if (typeof document.body.createTextRange != "undefined") {
        var textRange = document.body.createTextRange();
        textRange.moveToElementText(el);
        textRange.collapse(false);
        textRange.select();
    }
}

var charactersInLine = 0;
function checkMaxLen(e) {
    var x = e.which || e.keyCode;

    if ((jQuery('#editor').prop('scrollHeight') > 772) && x != 8) {
        //    alert('max Number of lines reached.');
        //    return false;
        e.preventDefault();
        //    //jQuery('#editor').prop('contenteditable', 'false');

    }


}
