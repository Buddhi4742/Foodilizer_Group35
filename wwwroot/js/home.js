// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var swiper = new Swiper(".mySwiper", {
	slidesPerView: 4,
	spaceBetween: 10,
	freeMode: true,
	loop: true,
	autoplay: {
		delay: 5000,
		disableOnInteraction: false,
		pauseOnMouseEnter: true,
	},
	pagination: {
		el: ".swiper-pagination",
		clickable: true,
	}, navigation: {
		nextEl: ".swiper-button-next",
		prevEl: ".swiper-button-prev",
	},
});

$(document).ready(function () {
	

	// Close modal on button click
	$("#login-modal-btn").click(function () {
		$("#loginModal .close").click()
	});
	

	// Close modal on button click
	$("#reg-modal-btn").click(function () {
		$("#regModal .close").click()
	});
});


$(document).ready(function () {

	$("#reg-form").validate({
		rules: {
			firstName: "required",
			lastName: "required",
			email: {
				required: true,
				email: true,
			},
			//location: "required",
			//mobile: "required",
			password: {
				required: true,
				minLength: 5,
			},
			password2: {
				required: true,
				minLength: 5,
				equalTo: "#password2",
			},
		},
		messages: {
			firstName: "Please enter your First name",
			lastName: "Please enter your Last name",
			//location: "required",
			//mobile: "required",
			password: {
				required: "Please enter your First name",
				minLength: "<h1>Your Password must be atleat 5 charactors long</h1>",
			},
			password2: {
				required: "Please enter your First name",
				minLength: "<h1>Your Password must be atleat 5 charactors long</h1>",
				equalTo: "Passwords does not match",
			},
		}
	})
	
});


