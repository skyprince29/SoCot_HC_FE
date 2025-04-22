// modal-handler.js

$(document).ready(function () {

    // Generic modal loader with optional callback
    window.showModal = function (modalId, contentUrl, data = {}, onShownCallback = null) {
        const $modal = $(modalId);
        const $modalBody = $modal.find('.modal-body');

        $.ajax({
            url: contentUrl,
            type: 'GET',
            data: data,
            success: function (response) {
                $modalBody.html(response);
               

                $modal.on('shown.bs.modal', function () {
                    // ✅ Run passed callback
                    if (typeof onShownCallback === 'function') {
                        onShownCallback($modalBody);
                    }
                });

                $modal.modal('show');
            },
            error: function () {
                alert("Failed to load modal content.");
            }
        });
    };

    // Clear modal content and avoid aria-hidden issue
    $('.modal').on('hidden.bs.modal', function () {
        document.activeElement.blur();
        $(this).find('.modal-body').html('');
    });
});
