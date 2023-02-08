<script>
    $(document).ready(function() {
        $('#Price, #Quantity').on('input', function () {
            var price = parseFloat($('#Price').val()) || 0;
            var quantity = parseInt($('#Quantity').val()) || 0;
            var Total = Price * Quantity;
            $('#Total').text(Total);
        };
};
</script>