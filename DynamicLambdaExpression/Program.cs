using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLambdaExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> selectedFields = new List<string> { "Type", "Content" };

            // 创建输入参数
            var parameter = Expression.Parameter(typeof(MyClass), "x");

            // 构建Lambda表达式的主体部分
            var body = BuildGroupByExpression(parameter, selectedFields);

            // 构建Lambda表达式
            var lambdaExpression = Expression.Lambda(body, parameter);

            // 输出Lambda表达式的字符串表示
            Console.WriteLine(lambdaExpression);

            // 编译Lambda表达式并执行
            var compiledExpression = (Func<MyClass, object[]>)lambdaExpression.Compile();

            // 使用Lambda表达式进行GroupBy
            var groupedData = GetData().GroupBy(compiledExpression);

            // 打印结果
            foreach (var group in groupedData)
            {
                Console.WriteLine($"Group Key: {string.Join(", ", group.Key)}");
                foreach (var item in group)
                {
                    Console.WriteLine($"  {item.Type}, {item.Content}");
                }
            }
        }

        // 构建Lambda表达式的主体部分
        static NewExpression BuildGroupByExpression(ParameterExpression parameter, List<string> selectedFields)
        {
            // 创建MemberInitExpression
            var memberBindings = selectedFields.Select(field =>
            {
                var property = typeof(MyClass).GetProperty(field);
                var member = Expression.Property(parameter, property);
                return Expression.Bind(property, member);
            });

            return Expression.New(typeof(MyClass).GetConstructor(Type.EmptyTypes), (IEnumerable<Expression>)memberBindings);
        }

        // 示例数据生成方法
        static IEnumerable<MyClass> GetData()
        {
            return new List<MyClass>
            {
                new MyClass { Type = "A", Content = "Text 1" },
                new MyClass { Type = "B", Content = "Text 2" },
                new MyClass { Type = "A", Content = "Text 3" },
                new MyClass { Type = "B", Content = "Text 4" },
                new MyClass { Type = "A", Content = "Text 5" },
            };
        }
    }

    // 示例数据类
    class MyClass
    {
        public string Type { get; set; }
        public string Content { get; set; }
    }


}
