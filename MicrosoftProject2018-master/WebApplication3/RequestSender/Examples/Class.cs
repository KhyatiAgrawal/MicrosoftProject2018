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

            // Inspect the Record
            Console.WriteLine(src.Name + " " + src.University + " " + src.GraduationY);
            Console.ReadLine();
            
            //Serialize the Record into Json format
            var jsonString = new StringBuilder();
            var jsonWriter = new SimpleJsonWriter(new StringWriter(jsonString));

            Serialize.To(jsonWriter, src);
            jsonWriter.Flush();

            //Return the serialized Record
            return jsonString.ToString();
        }

        public static Record Deserializer(string responseBody)
        {
            //Deserialize a Json string Record and return thedeserialized Record back
            var reader = new SimpleJsonReader(new StringReader(responseBody));
            var readRecord = Deserialize<Record>.From(reader);

            return readRecord;
        }
    }
}
