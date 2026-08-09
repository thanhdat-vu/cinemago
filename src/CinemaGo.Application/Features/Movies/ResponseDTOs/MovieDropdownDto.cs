namespace CinemaGo.Application.Features
{
    /// <summary>
    /// Lightweight DTO for movie dropdowns.
    /// </summary>
    public sealed record MovieDropdownDto(
        Guid Id,
        string Name
    );
}
