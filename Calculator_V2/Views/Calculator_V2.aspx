<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator_V2.aspx.cs" Inherits="Calculator_V2.Calculator_V2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <link href="~/Styles/calculator.css" rel="stylesheet" />

</head>
<body>
    <script src="~/Scripts/calculator.js"></script>
    <form id="form1" runat="server">
        <div class="container">
            <div class="calculator">
                <div class="display">
                    <asp:TextBox ID="TextBoxVysledek" runat="server" ViewStateMode="Disabled" ClientIDMode="Static"></asp:TextBox>
                </div>

                <div class="checkbox-container">
                    <asp:CheckBox ID="CheckBoxWholeNumbers" runat="server" />
                    <label for="<%= CheckBoxWholeNumbers.ClientID %>">Round to whole numbers</label>
                </div>

                <div class="button-grid">
                    <asp:Button ID="Button7" runat="server" OnClick="Button_Click" Text="7" CssClass="btn-number" />
                    <asp:Button ID="Button8" runat="server" OnClick="Button_Click" Text="8" CssClass="btn-number" />
                    <asp:Button ID="Button9" runat="server" OnClick="Button_Click" Text="9" CssClass="btn-number" />
                    <asp:Button ID="ButtonDivision" runat="server" OnClick="Operator_click" Text="/" CssClass="btn-operator" />

                    <asp:Button ID="Button4" runat="server" OnClick="Button_Click" Text="4" CssClass="btn-number" />
                    <asp:Button ID="Button5" runat="server" OnClick="Button_Click" Text="5" CssClass="btn-number" />
                    <asp:Button ID="Button6" runat="server" OnClick="Button_Click" Text="6" CssClass="btn-number" />
                    <asp:Button ID="ButtonMultiplication" runat="server" OnClick="Operator_click" Text="*" CssClass="btn-operator" />

                    <asp:Button ID="Button1" runat="server" OnClick="Button_Click" Text="1" CssClass="btn-number" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button_Click" Text="2" CssClass="btn-number" />
                    <asp:Button ID="Button3" runat="server" OnClick="Button_Click" Text="3" CssClass="btn-number" />
                    <asp:Button ID="ButtonMinus" runat="server" OnClick="Operator_click" Text="-" CssClass="btn-operator" />

                    <asp:Button ID="Button0" runat="server" OnClick="Button_Click" Text="0" CssClass="btn-number" />
                    <asp:Button ID="ButtonDot" runat="server" OnClick="Button_Click" Text="." CssClass="btn-number" />
                    <asp:Button ID="ButtonC" runat="server" OnClick="ButtonC_Click" Text="C" CssClass="btn-clear" />
                    <asp:Button ID="ButtonPlus" runat="server" OnClick="Operator_click" Text="+" CssClass="btn-operator" />
                </div>

                <asp:Button ID="ButtonSpocitat" runat="server" OnClick="ButtonSpocitat_Click" Text="Equals" CssClass="btn-calculate" />
            </div>

            <div class="history">
                <h3>📊 Calculation history</h3>
                <asp:TextBox ID="TextBoxHistory" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
</html>