﻿using Newtonsoft.Json;
using SimpleCompiler.CodeGenerator;
using SimpleCompiler.Services;

public class Program
{
    public static void Main()
    {
        string json = @"{
            ""name"": ""files/fib.rinha"",
            ""expression"": {
                ""kind"": ""Let"",
                ""name"": {
                    ""text"": ""fib"",
                    ""location"": { ""start"": 4, ""end"": 7, ""filename"": ""files/fib.rinha"" }
                },
                ""value"": {
                    ""kind"": ""Function"",
                    ""parameters"": [
                        {
                            ""text"": ""n"",
                            ""location"": { ""start"": 14, ""end"": 15, ""filename"": ""files/fib.rinha"" }
                        }
                    ],
                    ""value"": {
                        ""kind"": ""If"",
                        ""condition"": {
                            ""kind"": ""Binary"",
                            ""lhs"": {
                                ""kind"": ""Var"",
                                ""text"": ""n"",
                                ""location"": {
                                    ""start"": 28,
                                    ""end"": 29,
                                    ""filename"": ""files/fib.rinha""
                                }
                            },
                            ""op"": ""Lt"",
                            ""rhs"": {
                                ""kind"": ""Int"",
                                ""value"": 2,
                                ""location"": {
                                    ""start"": 32,
                                    ""end"": 33,
                                    ""filename"": ""files/fib.rinha""
                                }
                            },
                            ""location"": { ""start"": 28, ""end"": 33, ""filename"": ""files/fib.rinha"" }
                        },
                        ""then"": {
                            ""kind"": ""Var"",
                            ""text"": ""n"",
                            ""location"": { ""start"": 41, ""end"": 42, ""filename"": ""files/fib.rinha"" }
                        },
                        ""otherwise"": {
                            ""kind"": ""Binary"",
                            ""lhs"": {
                                ""kind"": ""Call"",
                                ""callee"": {
                                    ""kind"": ""Var"",
                                    ""text"": ""fib"",
                                    ""location"": {
                                        ""start"": 58,
                                        ""end"": 61,
                                        ""filename"": ""files/fib.rinha""
                                    }
                                },
                                ""arguments"": [
                                    {
                                        ""kind"": ""Binary"",
                                        ""lhs"": {
                                            ""kind"": ""Var"",
                                            ""text"": ""n"",
                                            ""location"": {
                                                ""start"": 62,
                                                ""end"": 63,
                                                ""filename"": ""files/fib.rinha""
                                            }
                                        },
                                        ""op"": ""Sub"",
                                        ""rhs"": {
                                            ""kind"": ""Int"",
                                            ""value"": 1,
                                            ""location"": {
                                                ""start"": 66,
                                                ""end"": 67,
                                                ""filename"": ""files/fib.rinha""
                                            }
                                        },
                                        ""location"": {
                                            ""start"": 62,
                                            ""end"": 67,
                                            ""filename"": ""files/fib.rinha""
                                        }
                                    }
                                ],
                                ""location"": {
                                    ""start"": 58,
                                    ""end"": 68,
                                    ""filename"": ""files/fib.rinha""
                                }
                            },
                            ""op"": ""Add"",
                            ""rhs"": {
                                ""kind"": ""Call"",
                                ""callee"": {
                                    ""kind"": ""Var"",
                                    ""text"": ""fib"",
                                    ""location"": {
                                        ""start"": 71,
                                        ""end"": 74,
                                        ""filename"": ""files/fib.rinha""
                                    }
                                },
                                ""arguments"": [
                                    {
                                        ""kind"": ""Binary"",
                                        ""lhs"": {
                                            ""kind"": ""Var"",
                                            ""text"": ""n"",
                                            ""location"": {
                                                ""start"": 75,
                                                ""end"": 76,
                                                ""filename"": ""files/fib.rinha""
                                            }
                                        },
                                        ""op"": ""Sub"",
                                        ""rhs"": {
                                            ""kind"": ""Int"",
                                            ""value"": 2,
                                            ""location"": {
                                                ""start"": 79,
                                                ""end"": 80,
                                                ""filename"": ""files/fib.rinha""
                                            }
                                        },
                                        ""location"": {
                                            ""start"": 75,
                                            ""end"": 80,
                                            ""filename"": ""files/fib.rinha""
                                        }
                                    }
                                ],
                                ""location"": {
                                    ""start"": 71,
                                    ""end"": 81,
                                    ""filename"": ""files/fib.rinha""
                                }
                            },
                            ""location"": { ""start"": 58, ""end"": 81, ""filename"": ""files/fib.rinha"" }
                        },
                        ""location"": { ""start"": 24, ""end"": 85, ""filename"": ""files/fib.rinha"" }
                    },
                    ""location"": { ""start"": 10, ""end"": 87, ""filename"": ""files/fib.rinha"" }
                },
                ""next"": {
                    ""kind"": ""Print"",
                    ""value"": {
                        ""kind"": ""Call"",
                        ""callee"": {
                            ""kind"": ""Var"",
                            ""text"": ""fib"",
                            ""location"": { ""start"": 97, ""end"": 100, ""filename"": ""files/fib.rinha"" }
                        },
                        ""arguments"": [
                            {
                                ""kind"": ""Int"",
                                ""value"": 10,
                                ""location"": {
                                    ""start"": 101,
                                    ""end"": 103,
                                    ""filename"": ""files/fib.rinha""
                                }
                            }
                        ],
                        ""location"": { ""start"": 97, ""end"": 104, ""filename"": ""files/fib.rinha"" }
                    },
                    ""location"": { ""start"": 90, ""end"": 105, ""filename"": ""files/fib.rinha"" }
                },
                ""location"": { ""start"": 0, ""end"": 105, ""filename"": ""files/fib.rinha"" }
            },
            ""location"": { ""start"": 0, ""end"": 105, ""filename"": ""files/fib.rinha"" }
        }";

        dynamic dynamicAst = JsonConvert.DeserializeObject(json);
        var ast = TypedAstGenerator.Generate(dynamicAst.expression);
        //TypedAstReader.Read(ast);

        var js = JavascriptCodeGenerator.GenerateJavaScript(ast);
        Console.WriteLine(js);
        File.WriteAllText(Directory.GetCurrentDirectory() + "/generated_code.js", js);
    }
}
