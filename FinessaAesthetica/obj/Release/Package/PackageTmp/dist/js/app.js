function CloseDropDownFromToggle(elem) {
    $(elem).find('div.col-md-1').find('.dropdown.open').removeClass('open');
}
function CloseDropDown(nav, e) {
    $(nav).toggleClass('open');
    $(nav).parents('div').siblings().find('.dropdown.open').removeClass('open');
    e.stopPropagation();
}
function OpenDropDown(nav, e) {
    $(nav).removeClass('open');
    $(nav).addClass('open');
    $(nav).parents('div').siblings().find('.dropdown.open').removeClass('open');
    e.stopPropagation();
}

function OpenRecord(url) {
    window.location.href = url;
}