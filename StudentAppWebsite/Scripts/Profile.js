$(document).ready(function () {
    setTimeout(function () {
        $('#example-4_wrapper').find('.row').eq(1).addClass('secondRow');
    }, 1000);


    $('.friendUnfriend').one('click', function () {
        $(this).hide();
    });



});

function RemoveFriend(obj) {
    var FriendRequestId = $(obj).attr('data-FriendRequestId');
    var FriendName = $(obj).attr('data-FriendName');

    if (!confirm('Are you sure to remove this person from your friend list?'))
        return false;

    $.ajax({
        url: '/User/RemoveFriend',
        type: 'Post',
        data: '{"Id":"' + FriendRequestId + '"}',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var jsonData = JSON.parse(data);
            if (jsonData.Status == 1) {
                $('#MsgDiv').addClass('alert alert-success').html('You and ' + FriendName + ' are not friend any more.').fadeIn().fadeOut(10000);
                $(obj).removeAttr('onclick').attr('onclick', 'Addtofriendlst(this)').removeClass('btn btn-danger').addClass('btn btn-primary').html('Send friend request');
                $(obj).parents('div.col-md-6:first').remove();

            }
            else {
                $('#MsgDiv').addClass('alert alert-danger').html('Some error occured during removing ' + FriendName + ' from your friendlist.').fadein().fadeOut(10000);
            }
        },
        error: function () { },
        complete: function () { }
    })
}

function Addtofriendlst(obj) {
    //var QuestionerId = $(obj).attr("data-FriendRequestId");
    var invitedUserId = $(obj).attr('data-id');

    $.ajax({
        url: '/Home/FriendList_InsertUpdate?InvitedId=' + invitedUserId,
        data: {},
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            var jsonData = JSON.parse(data);
            if (jsonData.Status == 1) {
                var jsonData = JSON.parse(data);
                if (jsonData.Status == '1') {
                    if (jsonData.result == '-10')
                        alert('Already added to your friendList.');
                    else {
                        if (jsonData.result == '-100')
                            alert('This user have blocked you.You can not add this user to your friend List.');
                        else
                            if (jsonData.result == '-15')
                                alert('Invitation Already sent.');
                            else {
                                $(obj).removeAttr('onclick').removeClass('btn btn-primary').addClass('btn btn-success').html('Friend request sent');
                                alert('Friend request sent successfully.');
                            }
                    }

                }
                else {
                    alert('Some error occured during sending invitation!');
                }
            }
        },
        error: function () { },
        complete: function () { }

    })
}

//function UpdateInvitationStatus(obj, status) {
//    //alert('hi');
//    var pageid = '@ViewBag.PageId';
//    var invitedUserId = $(obj).attr('data-Id');
//    //alert(invitedUserId + ' / ' + status+' // '+ pageid);
//    if (status == 1) {
//        $.ajax({
//            type: 'POST',
//            url: '/User/InvitationList_InsertUpdate',
//            data: '{ "InvitedUserId" : "' + invitedUserId + '","pageId":"' + pageid + '"}',
//            contentType: 'application/json; charset=utf-8',
//            dataType: 'json',
//            success: function (data) {
//                var jsonData = JSON.parse(data);
//                if (jsonData.Status == 1) {
//                    $(obj).html('Invitation Sent');
//                    $(obj).addClass('disabledbtn');
//                    $('#MsgDiv').addClass('alert alert-success').html('Invitation send successfully.').fadeIn().fadeOut(10000);
//                    //$('li[data-Id="' + Id + '"]').html('<a href="#" class="notification-msg clearfix"><div class="col-md-2"> <img src="' + image + '" class="img-circle img-inline userpic-32" style="width:35px;margin-top: 10px;"></div> <div class="col-md-10" style="text-align: justify;">' + name + ' and you are now friends.</div>');


//                    //$('li[data-Id="' + Id + '"]').html('<a href="#" class="notification-msg clearfix"><div class="col-md-2"> <img src="' + image + '" class="img-circle img-inline userpic-32" style="width:35px;margin-top: 10px;"></div><div class="col-md-10" style="text-align: justify;">You have rejected the request of ' + name + '.</div>');

//                }
//                else {
//                    $('#MsgDiv').addClass('alert alert-danger').html('Some error occured during sending invitation.').fadeIn().fadeOut(10000);
//                }
//            },
//            error: function () { },
//            complete: function () { }
//        })
//    }

//}
