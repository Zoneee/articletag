using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;
using Entity.Entities;

namespace ExtractOutput
{
    class Program
    {
        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, @"server=deepbio-prod.sqlserver.rds.aliyuncs.com,1433;database=ArticleTag;uid=deepbioweb;pwd=7m*6Rkr2ip")
            .Build(); //请务必定义成 Singleton 单例模式 
        static void Main(string[] args)
        {
            var taskIdPath = "任务ID列表.txt";
            if (!File.Exists(taskIdPath))
            {
                Console.WriteLine("请将要处理的 任务ID 存储在本程序所在文件夹中的 任务ID列表.txt 文件中，每行一个。");
                Console.Read();
                return;
            }

            var taskIdList = File.ReadAllLines(taskIdPath).ToList().Select(p => long.Parse(p)).ToList();

            var count = taskIdList.Count;
            Console.WriteLine($"开始处理，共{count}个");

            var folder = Path.GetFullPath("output");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            for (var index = 0; index < count; index++)
            {
                var taskId = taskIdList[index];
                var record = fsql.Select<ArticleTaggedRecord>().Where(p => p.TaskID == taskId).First();
                var html = record.TaggedContent;
                var htmlFilePath = $"{folder}\\raw_{taskId}.html";
                File.WriteAllText(htmlFilePath, html);

                html = $"<html>{html}</html>";
                html = html.Replace("<sup>", "**").Replace("</sup>", "**").Replace("<sub>", "*").Replace("</sub>", "*");
                var text_mark = new PlainTextConverter(new List<string>() { "mark" }, null).Convert(html);
                var extractor = new Common.ExtractOutput(text_mark);

                string plain;
                string output;
                extractor.Extract(out plain, out output);

                var plainFilePath = $"{folder}\\plain_{taskId}.txt";
                var outputFilePath = $"{folder}\\output_{taskId}.txt";

                File.WriteAllText(plainFilePath, plain);
                File.WriteAllText(outputFilePath, output);

                Console.WriteLine($"已输出 {taskId} , {index + 1}/{count}");
            }

            Console.WriteLine($"处理完成, {folder}");

            Console.Read();
        }
    }
}
