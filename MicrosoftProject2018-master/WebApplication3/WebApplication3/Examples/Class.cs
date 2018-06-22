namespace Examples
{
    using Bond;
    using Bond.Protocols;
    using Bond.IO.Safe;
   public class pro
{
    public static OutputBuffer Serializer(string name, string uni, double year)
    {
            var src = new Record
            {
                Name = name,
                University = uni,
                GraduationY = year
        };

        var output = new OutputBuffer();
        var writer = new CompactBinaryWriter<OutputBuffer>(output);

        // The first calls to Serialize.To and Deserialize<T>.From can take
        // a relatively long time because they generate the de/serializer
        // for a given type and protocol.
        Serialize.To(writer, src);

            // var input = new InputBuffer(output.Data);
            // var reader = new CompactBinaryReader<InputBuffer>(input);

            // var dst = Deserialize<Record>.From(reader);

            return output;
    }
}
}
