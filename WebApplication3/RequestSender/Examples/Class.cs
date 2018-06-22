namespace Examples
{
    using Bond;
    using Bond.Protocols;
    using Bond.IO.Safe;
    using System.Text;
    using System.IO;
    using System;

    public class pro
{
    public static string Serializer(string name, string uni, double year)
    {
        var src = new Record
        {
            Name = name,
            University = uni,
            GraduationY = year
        };

            var jsonString = new StringBuilder();
            var jsonWriter = new SimpleJsonWriter(new StringWriter(jsonString));

            Serialize.To(jsonWriter, src);
            jsonWriter.Flush();

            // For Debugging
            // Console.WriteLine(jsonString);
            // Console.ReadLine();

            // The first calls to Serialize.To and Deserialize<T>.From can take
            // a relatively long time because they generate the de/serializer
            // for a given type and protocol.
            //Serialize.To(writer, src);

            // var input = new InputBuffer(output.Data);
            // var reader = new CompactBinaryReader<InputBuffer>(input);

            // var dst = Deserialize<Record>.From(reader);

        return jsonString.ToString();
    }
}
}
