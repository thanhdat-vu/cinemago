namespace CinemaGo.Application.Features
{
    public record VerifyPaymentResponse(
        Guid BookingId,
        Guid PaymentTransactionId,
        bool IsSuccess,
        string? CheckinQrCode,
        string Status,
        string? ErrorMessage = null,
        bool CanRetry = false,
        IReadOnlyList<PaymentGatewayOptionDto>? AvailableGateways = null);
}