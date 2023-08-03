<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator_V2.aspx.cs" Inherits="Calculator_V2.Calculator_V2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kalkulačka</title>
    <style type="text/css">
        .container {
            display: flex;
            justify-content: center;
            font-family: Arial, sans-serif;
            padding: 20px;
            background-color: #f4f4f4;
        }
        .calculator, .history {
            margin: 10px;
            border: 1px solid #e4e4e4;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
        }
        .calculator button, .calculator p {
            margin: 5px;
            padding: 10px;
            font-size: 18px;
        }
        .calculator input[type="text"] {
            font-size: 18px;
        }
        .history {
            text-align: center;
        }
        .auto-style2 {
            resize: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="calculator">
                <asp:TextBox ID="TextBoxVysledek" runat="server" Height="40px" Width="100%" BackColor="#CFE2A4" BorderStyle="Solid" BorderWidth="4px" ViewStateMode="Disabled" ClientIDMode="Static"></asp:TextBox>
                <p>
                    <asp:Button ID="Button1" runat="server" OnClick="Button_Click" Text="1" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button_Click" Text="2" />
                    <asp:Button ID="Button3" runat="server" OnClick="Button_Click" Text="3" />
                    <asp:Button ID="ButtonPlus" runat="server" OnClick="Operator_click" Text="+" />
                    <asp:CheckBox ID="CheckBoxWholeNumbers" runat="server" Text="Cela Cisla" />
                </p>
                <p>
                    <asp:Button ID="Button4" runat="server" OnClick="Button_Click" Text="4" />
                    <asp:Button ID="Button5" runat="server" OnClick="Button_Click" Text="5" />
                    <asp:Button ID="Button6" runat="server" OnClick="Button_Click" Text="6" />
                    <asp:Button ID="ButtonMinus" runat="server" OnClick="Operator_click" Text="-" />
                </p>
                <p>
                    <asp:Button ID="Button7" runat="server" OnClick="Button_Click" Text="7" />
                    <asp:Button ID="Button8" runat="server" OnClick="Button_Click" Text="8" />
                    <asp:Button ID="Button9" runat="server" OnClick="Button_Click" Text="9" />
                    <asp:Button ID="ButtonMultiplication" runat="server" OnClick="Operator_click" Text="*" />
                </p>
                <p>
                    <asp:Button ID="Button0" runat="server" OnClick="Button_Click" Text="0" />
                    <asp:Button ID="ButtonDot" runat="server" OnClick="Button_Click" Text="." />
                    <asp:Button ID="ButtonC" runat="server" OnClick="ButtonC_Click" Text="C" />
                    <asp:Button ID="ButtonDivision" runat="server" OnClick="Operator_click" Text="/" />
                </p>
                <p>
                    <asp:Button ID="ButtonSpocitat" runat="server" OnClick="ButtonSpocitat_Click" Text="Spocitat" Width="100%" />
                </p>
            </div>
            <div class="history">
                <p>Historie:</p>
                <asp:TextBox ID="TextBoxHistory" runat="server" CssClass="auto-style2" TextMode="MultiLine" Height="165px" Width="250px"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
</html>
