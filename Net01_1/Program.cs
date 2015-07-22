using System;
using System.Text;
using Net01_1.Model;
using Net01_1.Extensions;

namespace Net01_1
{
    class Program
    {
        static void Main(string[] args)
        {

            VideoMaterial video = new VideoMaterial
            {
                VideoUri = new Uri(@"http://someVideoUri"),
                HeadBandUri = new Uri(@"http://someheadBand"),
                VideoFormat = VideoFormat.Asf,
                Description = "Material fo first lesson about .Net: video material"
            };

            video.CreateEntityGuid();



            var text = new TextMaterial
            {
                Description = "Mterial about string: Text material",
                Text ="In C#, you can use strings as array of characters, However, more common practice is to use the string keyword to declare a string variable. The string keyword is an alias for the System.String class.",
                Id = Guid.NewGuid()
            };

            text.CreateEntityGuid();


            var reference = new ReferenceMaterial
            {
                ContentUri = new Uri(@"http://someContent"),
                ContentType = TypeOfReferenceMaterial.Picture,
                Description = "Some ...: Reference material"

            };

            reference.CreateEntityGuid();

            if (video.Equals(reference))
            {
                Console.WriteLine("Equal material");
            }
            TrainigLesson lessons = new TrainigLesson(2)
            {
                Version = new byte[] {0, 1, 2, 3, 4, 5, 6, 7},
                Description = "Material abou .Net"
            };

            lessons.AddMaterial(text);
            lessons.AddMaterial(video);
            lessons.AddMaterial(reference);


            while (!lessons.IsEmpty)
            {  
                var mat = lessons.RemoveMaterial();
                Console.WriteLine(mat);
            }

            TrainigLesson lessons2 = (TrainigLesson)lessons.Clone();
    

          Console.WriteLine(lessons2);

            Console.ReadKey();
        }
    }
 
}
