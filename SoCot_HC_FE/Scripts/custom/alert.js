// Scripts/custom/alert.js
function showAlert(type, message) {
    var alertHtml = `
        <div class="alert alert-${type} alert-dismissible show position-fixed top-0 end-0 m-3 zindex-dropdown" role="alert" style="min-width: 300px; z-index: 9999;">
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>`;

    $('body').append(alertHtml);

    // Auto-dismiss after 5 seconds
    setTimeout(() => {
        $('.alert').alert('close');
    }, 5000);
}
