function populateDropdown({ url, dropdownSelector, valueField, textField, placeholder, data = {}, selectedId = null }) {
    $.ajax({
        url: url,
        type: 'GET',
        data: data,
        success: function (response) {
            // If response is an error format
            if (response.success === false && response.message) {
                showAlert('danger', errorMessage || 'Error loading dropdown datas.');
                return;
            }

            let options = `<option value="">${placeholder}</option>`;

            $.each(response, function (index, item) {
                options += `<option value="${item[valueField]}">${item[textField]}</option>`;
            });

            const $dropdown = $(dropdownSelector);
            $dropdown.html(options);

            if (selectedId !== null && selectedId !== undefined) {
                $dropdown.val(selectedId).trigger('change');
            }
        },
        error: function (xhr) {
            let errorMessage = "An unexpected error occurred.";
            try {
                const response = JSON.parse(xhr.responseText);
                if (response && response.message) {
                    errorMessage = response.message;
                }
            } catch (e) {
                // Keep default errorMessage
            }
            showAlert('danger', errorMessage);
        }
    });
}
