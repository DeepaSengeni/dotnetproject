$(document).ready(function () {
    var messagesCount = $('#count').val();
    if (messagesCount == 1500)
        $('#MaxCountAlert').show();

    $('#errorMessage').hide();
    $('#successMessage').hide();

    $('#CancelButton').click(function () {

        location.reload(true);

    });

    var messagesCount = $('#count').val();

    $('#msg_txt').click(function () {
        var counts = messagesCount;
        counts = parseInt(counts) + parseInt($('.msg').length);

        if (parseInt(counts) < 1500) {
            if ($('.msg').length < 10) {
                var isVisible = $('#openContact').css('display');
                if (isVisible == 'none') {

                    $('#msgDiv').append('<div class="mainbtnSubmitDiv"><div class="row"><div class="col-md-5 col-sm-8 col-xs-8 input-width txtdiv" style="display:block;"><input type="text" id="input' + $('.msg').length + '" class="form-control msg sendSms" placeholder = "Please Enter Mobile Number"/></div><div class="icon-img"><img onclick="HtmlViewer.pickAContactNumber(&#39;input' + $('.msg').length + '&#39;);" src="/Content/images/contacts3.png" class="img-responsive logo-design icon-logo" style="width:30px;height:30px;display:none" ></div><div class="addnew-btn"><a href="javascript:void(0);"  onclick="GetTextValue(this)" class="btn btn-danger add-icn-res"><i class="fa fa-times"></i></a></div></div></div>')
                }
                else {

                    $('#msgDiv').append('<div class="mainDiv"><div class="row"><div class="col-md-5 col-sm-8 col-xs-8 input-width txtdiv" style="display:block;"><input type="text" id="input' + $('.msg').length + '" class="form-control msg sendSms" placeholder = "Please Enter Mobile Number"/></div><div class="icon-img"><img onclick="HtmlViewer.pickAContactNumber(&#39;input' + $('.msg').length + '&#39;);" src="/Content/images/contacts3.png" class="img-responsive logo-design icon-logo" style="width:30px;height:30px;display:block" ></div><div class="addnew-btn"><a href="javascript:void(0);"  onclick="GetTextValue(this)" class="btn btn-danger add-icn-res"><i class="fa fa-times"></i></a></div></div></div>')
                }
                // Add Country Code To Input
                var InputId = parseInt($('.msg').length) - 1;
                CountrySync('input' + InputId);
            }
        }
        else {
            alert('You have reached your max limit of 1500 messages.');
            //if (!$('#MaxCountAlert').hasClass('showing')) {
            //    $('#MaxCountAlert').show();
            //    //$('#MaxCountAlert').html(' You can send only ' + (1500 - messagesCount) + ' messages now')
            //    $('#MaxCountAlert').addClass('showing');
            //}

        }

    });


    var input = document.querySelector(".sendSms");
    window.intlTelInput(input, {
        utilsScript: "PhoneCountrySync/js/utils.js",
        initialCountry: "auto",
        geoIpLookup: function (success, failure) {          
            $.getJSON("https://api6.ipify.org/?format=json", function (ipresp) {
                $.get("http://ip-api.com/json/" + ipresp.ip + "", function () { }, "jsonp").always(function (resp) {
                    var countryCode = (resp && resp.countryCode) ? resp.countryCode : "";
                    success(countryCode);
                });
            });
        },
    });
});
//$(".sendSms").on("keyup", function () {

//    var VAL = $(this).val();

//    var mobileno = /^(\d{10})$/;
//     if (mobileno.test(VAL)) {
//         //alert(1);
//        $(this).parent().find('.validationmsg').remove();
//        return true;
//    }


//});


//$('#MobileNo').click(function () {
//    HtmlViewer.pickAContactNumber();
//});





function GetTextValue(obj) {

    $(obj).closest('.mainbtnSubmitDiv').remove();
    $(obj).remove();

}

function validateInput() {
    var count = 0;
    $('.msg').each(function () {

        var VAL = $(this).val();

        var mobileno = /^(\+91|0|91)?\d{10}$/;
        $(this).on("keyup", function () {

            if ($(this).val().length == 0) {
                count++;

                if ($(this).parent().find('.validationmsg').length == 0) {

                    $(this).after('<span class="text-danger validationmsg" >  Mobile No. is required.</span>')

                }
            }
            else if (!mobileno.test(VAL)) {
                count++;
                $(this).parent().find('.validationmsg').remove();
                $(this).after('<span class="text-danger validationmsg">Please Enter Valid Moblie Number.</span>');
            }
            else {

                $(this).parent().find('.validationmsg').remove();
            }
        });

        if ($(this).val().length == 0) {
            count++;

            if ($(this).parent().find('.validationmsg').length == 0) {

                $(this).after('<span class="text-danger validationmsg" > Mobile No. is required.</span>')

            }
        }
        else if (!mobileno.test(VAL)) {
            count++;
            $(this).parent().find('.validationmsg').remove();
            $(this).after('<span class="text-danger validationmsg">Please Enter Valid Moblie Number.</span>');
        }
        else {

            $(this).parent().find('.validationmsg').remove();
        }
    });

    if (count > 0) {

        return false;
    }
    else {

        $('#loaderDiv2').show();
        var values = new Array();
        var a;
        $(".sendSms").each(function () {
            var code = $(this).parent('div').find(".selected-flag").attr("title");
            code = code.split(':');
            values.push(code[1] + $(this).val());
            a = values.join(",");


        });

        var phonenumber = a;
        var Phonetext = document.getElementById("textSms").innerHTML;

        var messageCount = $('#count').val();
        //console.log(Phonetext);
        if (Phonetext != null && Phonetext != "") {
            $.ajax({
                url: "/User/SendSMSToMobile",
                type: 'get',
                dataType: 'json',
                contentType: 'application/json;',
                data: { mobileNumbers: phonenumber, messageBody: Phonetext, messageCount: messageCount },
                success: function (data) {

                    if (data.length > 0) {
                        $('#successMessage').show();
                        $('#errorMessage').hide();
                    } else {
                        $('#successMessage').hide();
                        $('#errorMessage').show();
                    }
                    //console.log(json.messages[0].status);
                    //$('#loaderDiv2').hide();
                    //if (json.messages[0].status != 0) {
                    //    $('#successMessage').hide();
                    //    $('#errorMessage').show();
                    //}
                    //else if (json.messages[0].status == null) {
                    //    $('#errorMessage').show();
                    //    $('#successMessage').hide();
                    //}
                    //else {
                    //    $('.sendSms').val('');
                    //    $('#successMessage').show();
                    //    $('#errorMessage').hide();

                    //}
                },
                error: function (xhr, status, error) {
                    $('#loaderDiv2').hide();
                    console.log(xhr.responseText);
                },
                complete: function () {
                    $('#loaderDiv2').hide();
                }
            });
        }
        else {
            alert('Please first set a message.');
        }
        return true;
    }
}

//$('#btnSubmit').on('click', function () {


//});
function CountrySync(selector) {
    selector = document.querySelector("#" + selector);
    window.intlTelInput(selector, {
        utilsScript: "PhoneCountrySync/js/utils.js",
        initialCountry: "auto",
        geoIpLookup: function (success, failure) {
            $.getJSON("https://api6.ipify.org/?format=json", function (ipresp) {
                $.get("http://ip-api.com/json/" + ipresp.ip + "", function () { }, "jsonp").always(function (resp) {
                    var countryCode = (resp && resp.countryCode) ? resp.countryCode : "";
                    success(countryCode);
                });
            });
        },
    });
}
