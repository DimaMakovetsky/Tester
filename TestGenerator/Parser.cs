using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace TestGenerator
{
    public class Parser
    {
        public Files GetFileData(string source)
        {
            CompilationUnitSyntax tree = CSharpSyntaxTree.ParseText(source).GetCompilationUnitRoot();
            List<Classes> classes = new List<Classes>();
            foreach (var classDeclaration in tree.DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                Classes data = GetClassData(classDeclaration);
                if (data.Methods.Count != 0)
                {
                    classes.Add(data);
                }
            }

            return new Files(classes);
        }

        private Classes GetClassData(ClassDeclarationSyntax syntax)
        {

            List<Constructors> ctors = new List<Constructors>();
            foreach (var ctor in syntax.DescendantNodes()
                .OfType<ConstructorDeclarationSyntax>()
                .Where((cd) => cd.Modifiers
                .Any((c) => c.IsKind(SyntaxKind.PublicKeyword))))
            {
                ctors.Add(GetConstructorData(ctor));
            }

            List<Methods> methods = new List<Methods>();
            foreach (var method in syntax.DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Where((md) => md.Modifiers
                .Any((m) => m.IsKind(SyntaxKind.PublicKeyword))))
            {
                methods.Add(GetMethodData(method));
            }

            return new Classes(syntax.Identifier.ValueText, ctors, methods);
        }

        private Constructors GetConstructorData(ConstructorDeclarationSyntax syntax)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (var param in syntax.ParameterList.Parameters)
            {
                parameters.Add(param.Identifier.Text, param.Type.ToString());
            }

            return new Constructors(syntax.Identifier.Text, parameters);
        }

        private Methods GetMethodData(MethodDeclarationSyntax syntax)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (var param in syntax.ParameterList.Parameters)
            {
                parameters.Add(param.Identifier.Text, param.Type.ToString());
            }

            return new Methods(syntax.Identifier.Text, parameters, syntax.ReturnType.ToString());
        }
    }
}

