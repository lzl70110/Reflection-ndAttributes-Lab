using System.Reflection;
using System.Text;

namespace Stealer;

    public class Spy
    {
        private string username { get; set; }

        public static string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type clasType = Type.GetType(investigatedClass);
            FieldInfo[] fields = clasType.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                                    BindingFlags.Instance | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();
            Object instance = Activator.CreateInstance(clasType, new object?[] { });
            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (var item in fields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(instance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }

    