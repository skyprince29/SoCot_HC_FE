// ~/Scripts/custom/select2-init.js

// Initializes Select2 with search
function initSelect2WithSearch(container) {
    $(container).find('.select2-searchable').each(function () {
        const placeholder = $(this).data('placeholder') || 'Select an option';
        $(this).select2({
            placeholder: placeholder,
            allowClear: true,
            width: '100%',
            dropdownParent: $(container)
        });
    });
}

// Initializes Select2 without search (for static/select-only dropdowns)
function initSelect2NoSearch(container) {
    $(container).find('.select2-no-search').each(function () {
        const placeholder = $(this).data('placeholder') || 'Select an option';
        $(this).select2({
            minimumResultsForSearch: Infinity,
            placeholder: placeholder,
            allowClear: true,
            width: '100%',
            dropdownParent: $(container)
        });
    });
}

// Optional: initialize both searchable and non-searchable Select2 in one call
function initAllSelect2(container) {
    initSelect2WithSearch(container);
    initSelect2NoSearch(container);
}
