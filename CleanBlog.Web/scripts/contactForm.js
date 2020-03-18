var contactFor = contactForm ||
{
    init: function () {
        this.listeners();
    },
    listeners: function()
    {
        $(document).on("click", ".contact-submit", function (e)
        {
            e.preventDefault();
            var form = $("contact-form");
            form.submit();
        }); 
    },
    //OnSuccess = "contactForm.showResult", OnFailure = "contactForm.showResult"
    showResult: function()
    {
        $("#form-outer").hide("slow");
        $("#form-result").show("slow");
    }
}