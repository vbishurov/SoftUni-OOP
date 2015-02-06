namespace WordDocumentGenerator
{
    using System.Drawing;
    using Novacode;

    public static class WordDocumentGenerator
    {
        public static void Main()
        {
            const string FileName = "../../SoftUni-OOP-Game-Contest.docx";

            using (var doc = DocX.Create(FileName))
            {
                var titleFormat = new Formatting { Bold = true, Size = 25D };

                var banner = doc.AddImage(@"../../Content/rpg-game.png").CreatePicture();
                banner.Width = 600;
                banner.Height = 250;

                var title = doc.InsertParagraph("SoftUni OOP Game Contest", false, titleFormat);
                title.Alignment = Alignment.center;

                var img = doc.InsertParagraph(string.Empty, false);
                img.InsertPicture(banner);

                var text = doc.InsertParagraph("SoftUni is organizing a contest for the best ", false);
                text.Append("role playing game ").Bold();
                text.Append("from the OOP teamwork ");
                text.Append("projects. The winnig teams will receive a ");
                text.Append("grand prize").Bold().UnderlineColor(Color.Black);
                text.Append("!");
                text.AppendLine("The game shoud be: ");
                text.IndentationAfter = 2.0f;

                var criteriasList = doc.AddList("Properly structured and follow all good OOP practices", 1, ListItemType.Bulleted);
                doc.AddListItem(criteriasList, "Awesome", 1);
                doc.AddListItem(criteriasList, "..Very Awesome", 1);
                doc.InsertList(criteriasList);

                var results = doc.AddTable(4, 3);
                results.Alignment = Alignment.center;
                results.AutoFit = AutoFit.Window;

                results.Rows[0].Cells[0].FillColor = Color.FromArgb(84, 141, 212);
                results.Rows[0].Cells[0].Paragraphs[0].Append("Team").Color(Color.White).Bold().Alignment = Alignment.center;

                results.Rows[0].Cells[1].FillColor = Color.FromArgb(84, 141, 212);
                results.Rows[0].Cells[1].Paragraphs[0].Append("Game").Color(Color.White).Bold().Alignment = Alignment.center;

                results.Rows[0].Cells[2].FillColor = Color.FromArgb(84, 141, 212);
                results.Rows[0].Cells[2].Paragraphs[0].Append("Points").Color(Color.White).Bold().Alignment = Alignment.center;

                results.Rows[1].Cells[0].Paragraphs[0].Append("-").Alignment = Alignment.center;
                results.Rows[2].Cells[0].Paragraphs[0].Append("-").Alignment = Alignment.center;
                results.Rows[3].Cells[0].Paragraphs[0].Append("-").Alignment = Alignment.center;

                results.Rows[1].Cells[1].Paragraphs[0].Append("-").Alignment = Alignment.center;
                results.Rows[2].Cells[1].Paragraphs[0].Append("-").Alignment = Alignment.center;
                results.Rows[3].Cells[1].Paragraphs[0].Append("-").Alignment = Alignment.center;

                results.Rows[1].Cells[2].Paragraphs[0].Append("-").Alignment = Alignment.center;
                results.Rows[2].Cells[2].Paragraphs[0].Append("-").Alignment = Alignment.center;
                results.Rows[3].Cells[2].Paragraphs[0].Append("-").Alignment = Alignment.center;

                doc.InsertTable(results);

                var ending = doc.InsertParagraph("The top 3 teams will receive a ");
                ending.Append("Spectacular ").Bold().CapsStyle(CapsStyle.caps);
                ending.Append("prize:");
                ending.Alignment = Alignment.center;

                var handshake = doc.InsertParagraph("A handshake from Nakov");
                handshake.Bold();
                handshake.Color(Color.FromArgb(23, 54, 93));
                handshake.UnderlineColor(Color.FromArgb(23, 54, 93));
                handshake.CapsStyle(CapsStyle.caps);
                handshake.FontSize(24D);
                handshake.Alignment = Alignment.center;

                doc.Save();
            }

            // Process.Start("WINWORD.EXE", fileName);
        }
    }
}
