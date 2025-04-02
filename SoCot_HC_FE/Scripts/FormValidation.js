function validateForm(result) {
	console.log("sdasdasdasdasdasdasdasdasdasdasd", result);
	if (result && result.errors) {
		for (var key in result.errors) {
			if (result.errors.hasOwnProperty(key)) {
				var errorMessage = result.errors[key].join(", ");
				var validationMessageElement = $('[data-valmsg-for="' + key + '"]');
				if (validationMessageElement) {
					validationMessageElement.text(errorMessage).show();
				}
			}
		}
	}
}

function showToast(text, type) {
	const toastData = {
		text: text,
		gravity: "top", // `top` or `bottom`
		position: "right", // `left`, `center` or `right`
		className: type === "success" ? "bg-info" : "bg-danger", // Bootstrap class for background color
		offset: true, // enables offset for x and y
		duration: 3000, // duration in milliseconds
		close: "close", // enables close button
		style: type === "success"
			? { background: "#4BACC7", color: "#fff" } // Green background for success
			: { background: "#FA896B", color: "#fff" }
	};

	Toastify({
		text: toastData.text,
		gravity: toastData.gravity,
		position: toastData.position,
		stopOnFocus: true,
		offset: {
			x: toastData.offset ? 50 : 0, // horizontal axis offset
			y: toastData.offset ? 10 : 0, // vertical axis offset
		},
		duration: toastData.duration,
		close: toastData.close === "close",
		style: toastData.style
	}).showToast();
}
