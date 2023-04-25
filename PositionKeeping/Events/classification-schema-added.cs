namespace PositionKeeping.Events
{
    public record ClassificationSchemaAdded(
        int SchemaId,
        string SchemaCode,
        string SchemaName
    );

    public record PostingEntryAdded(
        long AccountingUnitId
        );
}
