

function validatePhoneNo() {
    var patternPhone = /^(()?\d{3}())?(-|\s)?\d{3}(-|\s)?\d{4}$/;
    var phoneNo = $('#VerifyphoneNo').val();
    var valid = phoneNo.match(patternPhone)
    if (valid == null) {
        $('#phoneerror').html('Enter valid mobile number').show().fadeOut(10000);
        return false;
    }
}

function CheckMail(email) {
    $.get("/Account/CheckEmailExist", { "Email": email }, function (data) {
        var getResponse = JSON.parse(data);

        if (getResponse.Status == 1) {
            $('#msgspan').html("Email already exists please choose another");
            return false;
        } else {
            $('#msgspan').html("");
        }
    });
}

function CheckMobile(mobile) {
    $.get("/Account/CheckMobileExist", { "Mobile": mobile }, function (data) {
        var getResponse = JSON.parse(data);

        if (getResponse.Status == 1) {
            $('#msgspanPhone').html("Mobile number already exists please choose another");
            return false;
        } else {
            $('#msgspanPhone').html("");
        }
    });
}

function setISD() {
    var code = $(".selected-flag").attr("title");
    if (code) {
        var codeArr = code.split(":");
        if (codeArr) {
            $('#isdCode').val(codeArr[1]);
        }
    }
}

function checkPost() {
    // setISD();
    // var phoneNo = $('#VerifyphoneNo').val();
    var EmailID = $('#EmailID').val();
    var VerifyOTP = $('#VerifyOTP').text();
    var messageCount = $('#msgspan').text();

    if (VerifyOTP != 'Verified' && EmailID.length > 0) {
        $('#msgspan1').html("Please Verify Your OTP");
        return false;
    }
    else if (messageCount.length > 0) {
        return false;
    }
    /* else if (CheckMobile(phoneNo)) {
        return false;
    } */
    else if (CheckMail(EmailID)) {
        return false;
    }
    else {
        $('#msgspan1').html('');
        return true;
    }
}

function previewFile() {
    //  var preview = document.querySelector('#StreamIconImage');

    var file = document.querySelector('#ProfilePicture').files[0];

    var reader = new FileReader();

    reader.onloadend = function () {
        //  preview.src = reader.result;
        // alert($('#Picture').val(reader.result));
        $('#Picture').val(reader.result);
    }

    if (file) {
        reader.readAsDataURL(file);
    }

}

//$('#state').change(


//);

function StateBind() {
    var CountryID = $('#Country').val();
    if (CountryID != "") {
        $.ajax({
            type: "POST",
            url: "/Account/StateLoad",
            dataType: "json",
            async: false,
            timeout: 3000,
            success: function (msg) {
                console.log(msg);
                if (msg && msg.statelist.length > 0) {
                    //var options = "<option value='0'>Select</option>";
                    var options = "<option>--Select State--</option>";
                    $.each(msg.statelist, function (key, value) {
                        console.log(value.Id);
                        options += "<option value=" + value.ID + ">" + value.StateName + "</option>";
                    });
                    $('#state').html(options);
                    $('#state').on("change", function () {

                        CityBind($(this).val());
                    });
                    $('#state option').eq(1).attr("selected", "selected");
                    $('#state').trigger('change');
                }
                else {
                    var options = "<option>--Select State--</option>";
                    $('#state').html(options);
                }
            },
            failure: function (msg) {
                console.log(msg);

            },
            data: { 'CountryID': CountryID },
        });
    } else {
        $('#state').html("<option value>--Select State--</option>");
    }
}

function CityBind() {
    var StateID = $('#state').val();
    if (StateID != "") {
        $.ajax({
            type: "POST",
            url: "/Account/CityLoad",
            dataType: "json",
            async: false,
            timeout: 3000,
            success: function (msg) {
                console.log(msg);
                if (msg && msg.citylist.length > 0) {
                    //var options = "<option value='0'>Select</option>";
                    var options = "<option>--Select City--</option>";
                    $.each(msg.citylist, function (key, value) {
                        console.log(value.Id);
                        options += "<option value=" + value.ID + ">" + value.CityName + "</option>";
                    });
                    $('#City').html(options);
                }
                else {
                    $('#City').html("<option value>--Select City--</option>");
                }
            },
            failure: function (msg) {
                console.log(msg);

            },
            data: { 'StateID': StateID },
        });
    } else {
        $('#City').html("<option value>--Select City--</option>");
    }
}

function InstituteBind() {

    var CityID = $('#City').val();

    if (CityID != "") {
        $.ajax({
            type: "POST",
            url: "/Account/InstituteLoadByCity",
            dataType: "json",
            async: false,
            timeout: 3000,
            success: function (msg) {
                console.log(msg);
                if (msg && msg.InstituteModelList.length > 0) {
                    //var options = "<option value='0'>Select</option>";
                    var options = "<option>--Select Institute--</option>";
                    $.each(msg.InstituteModelList, function (key, value) {
                        console.log(value.Id);
                        options += "<option value=" + value.Id + ">" + value.InstituteName + "</option>";
                    });
                    $('#CollegeID').html(options);
                }
                else {
                    $('#CollegeID').html("<option value>--Select Institute--</option>");
                }
            },
            failure: function (msg) {
                console.log(msg);

            },
            data: { 'CityId': CityID },
        });
    } else {
        $('#City').html("<option value>--Select City--</option>");
    }
}

function getLocation() {
    alert(geoplugin_city());
    alert(geoplugin_region());
    alert(geoplugin_countryName());
}

var geoData = [];

function geoplugin_countryName() {
    return geoData.country_name;
}
function geoplugin_region() {
    return geoData.region;
}
function geoplugin_city() {
    return geoData.city;
}
var country = "";
var state = "";
var city = "";


$(document).ready(function () {
    $('#DOB').mask("99/99/9999");
    $('#DOB').datepicker({
        format: "dd/mm/yyyy"
    });

    $.getJSON("https://ipapi.co/" + $('#ip').val() + "/json/", function () {
    }).done(function (resp) {
        geoData = resp;
    });


    $('input').on('focusout', function () {
        var str = $(this).val();
        $(this).val($.trim(str));
    });


    $('[name=Country] option').filter(function () {
        var ddCountry = $(this).text();
        return (ddCountry.toLowerCase() == country.toLowerCase());
    }).prop('selected', true);

    StateBind();
    $('[name=state] option').filter(function () {
        var ddstate = $(this).text();
        return (ddstate.toLowerCase() == state.toLowerCase());
    }).prop('selected', true);
    setTimeout(function () {
        $('[name=state] option').filter(function () {
            var ddstate = $(this).text();
            return (ddstate.toLowerCase() == state.toLowerCase());
        }).prop('selected', true);
    }, 1000);

    CityBind();
    $('[name=City] option').filter(function () {
        var ddcity = $(this).text();
        return (ddcity.toLowerCase() == city.toLowerCase());
    }).prop('selected', true);
    setTimeout(function () {
        $('[name=City] option').filter(function () {
            var ddcity = $(this).text();
            return (ddcity.toLowerCase() == city.toLowerCase());
        }).prop('selected', true);
    }, 1500);


    $('#UserPhoneEmail').on('blur', function () {
        if ($(this).val().length == 0) {
            // $('#error_username').html('Email or Phone is required');
            $('#error_username').html('Email is required');
        }
        else {
            $('#error_username').html('');
            var email = $('#UserPhoneEmail').val();
            // var pattern = /^([_a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,5}))|\d+$/;
            // var pattern = new RegExp(/^([\w-\.]+@@([\w-]+\.)+[\w-]{2, 4})?$/);

            var pattern = new RegExp(/\S+@\S+\.\S+/);
            var valid = pattern.test(email);//.match(patternEmail);
            console.log(valid);
            if (valid == false) {
                $('#error_username').html('Enter valid Email');
                // $('#error_username').html('Enter valid Email or Phone');
            } 
        }
    });
    $('#UserPhoneEmail1').on('blur', function () {
        if ($(this).val().length == 0) {
            // $('#error_username1').html('Email or Phone is required');
            $('#error_username1').html('Email is required');
        }
        else {
            $('#error_username1').html('');
            var email = $('#UserPhoneEmail1').val();
            // var patternEmail = new RegExp(/^([\w-\.]+@@([\w-]+\.)+[\w-]{2, 4})?$/);
            var patternEmail = new RegExp(/\S+@\S+\.\S+/);
            // var patternPhone = /^(()?\d{3}())?(-|\s)?\d{3}(-|\s)?\d{4}$/;
            var valid = patternEmail.test(email);//.match(patternEmail);

            if (valid == false) {
                $('#error_username1').html('Enter valid Email');
            }

            /* if (!valid) {

                valid = patternPhone.test(email);
                if (valid == null || valid == false) {
                    $('#error_username1').html('Enter valid Email or Phone');
                }
                else {

                }
            }
            else {

            } */
        }
    });

    /* $('#VerifyphoneNo').on('blur', function () {
        return validatePhoneNo();
    }); */


    $('.btn-block').click(function () {

        if ($('#UserPhoneEmail').val().length == 0) {
            $('#error_username').html('Email is required');
            // $('#error_username').html('Email or Phone is required');
            return false;
        }
        else if ($('#LoginPassword').val().length == 0) {
            $('#error_password').html('Password is required');
            return false;
        }
    });

    $('.btn-block1').click(function () {

        if ($('#UserPhoneEmail1').val().length == 0) {
            $('#error_username1').html('Email is required');
            // $('#error_username1').html('Email or Phone is required');
            return false;
        }
        else if ($('#LoginPassword1').val().length == 0) {
            $('#error_password1').html('Password is required');
            return false;
        }
    });
    $('#btnSubmit').click(function () {

        if ($('#ProfilePicture').val().length == 0) {

            $('#errormsg').html('Picture is required');
            return false;
        }
        else {
            $('#errormsg').html('');

        }
        //if ($('#EmailID').val().length == 0 && $('#VerifyphoneNo').val().length == 0) {

        //    $('#msgspan').html('Email or Mobile number is required');
        //    return false;

        //}
        //else {
        //    $('#msgspan').html('');

        //}
        /* if ($('#VerifyphoneNo').val().length > 0) {
            return validatePhoneNo();
            return checkPost();
        } */

        if ($('#EmailID').val().length > 0) {
            return checkPost();
        }
    });

    $("#EmailID").on("blur", function () {

        if ($(this).val() != "") {
            CheckMail($('#EmailID').val());
        }
    });

    /* $('#VerifyphoneNo').on("blur", function () {
        if ($(this).val() != "") {
            CheckMobile($(this).val());
        }
    });
    $('#VerifyphoneNo').keyup(function () {
        $('#msgspanPhone').html('');
    }); */

    $('#otp').keyup(function () {
        $('#msgspan1').html('');
    });

    $('#ProfilePicture').on("change", function () {

        previewFile();
        $('#errormsg').html('');
    });

    $('#SendOTP').on('click', function () {
        var messageBody = "Verification";
        // var Code = $(".selected-flag").attr("title");
        // Code = Code.split(":");

        $.ajax({
            url: "/Account/SendOTPEmail",
            type: "GET",
            dataType: "json",
            contentType: "application/json",
            // data: { mobileNumber: Code[1] + $('#VerifyphoneNo').val(), messageBody: messageBody },
            data: { emailId: $('#EmailID').val(), messageBody: messageBody },
            success: function (data) {

                if (data != null) {
                    $('#SendOTP').html('Resend OTP');
                }
                else {

                }


            },
            error: function (xhr, status, error) {
                var err = eval("(" + xhr.responseText + ")");

            },
            complete: function (data) {

            }
        });

    });

    $('#VerifyOTP').on('click', function () {
        var OTP = $('#otp').val();
        if (OTP.length > 0) {
            $('#msgspan1').html('');

        }
        else {
            $('#msgspan1').html("Please Enter OTP");
            return false;
        }
        $.ajax({
            url: "/Account/VerifyPhone",
            type: "GET",
            dataType: "json",
            contentType: "application/json",
            data: { OTP: OTP, requestId: $('#hdnRequest').val() },
            success: function (data) {
                if (data == "0") {
                    $('#msgspan1').html("Please Enter Valid OTP");
                }
                else if (data == null) {
                    $('#msgspan1').html("Please Enter Valid OTP");
                }
                else {
                    $('#msgspan1').html('');
                    var verifyotp = $('#VerifyOTP').text();
                    if (verifyotp.length > 0) {
                        $('#VerifyOTP').text('Verified');
                        document.getElementById('checkVerified').style.display = "block";
                    }
                    else {
                        document.getElementById('checkVerified').style.display = "none";
                    }
                }


            },
            error: function () { }
        });
    });

    $('#Country').on("change", function () {
        StateBind();
    });

    $('#state').on("change", function () {

        CityBind();
    });

    $('#City').on("change", function () {

        InstituteBind();
    });

    /* var input = document.querySelector("#VerifyphoneNo");
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
    }); */

    var autocomplete = new google.maps.places.Autocomplete($("#address")[0], {});
    var componentForm = {
        street_number: 'short_name',
        route: 'long_name',
        locality: 'long_name',
        administrative_area_level_1: 'long_name',
        country: 'long_name',
        postal_code: 'short_name'
    };

    google.maps.event.addListener(autocomplete, 'place_changed', function () {
        var place = autocomplete.getPlace();
        console.log(place);
        console.log(place.address_components);
        for (var i = 0; i < place.address_components.length; i++) {
            var addressType = place.address_components[i].types[0];
            console.log(addressType);
            if (componentForm[addressType]) {
                var val = place.address_components[i][componentForm[addressType]];
                document.getElementById(addressType).value = val;
                console.log(val);
            }
        }
    });

});

//test