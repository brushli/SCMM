<%@ Page language="c#" AutoEventWireup="false" Inherits="Infocom.Allegro.SC.SC_MM_05_S01" Codebehind="SC_MM_05_S01.aspx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="Infocom.Allegro.Web.WebControls" Assembly="AllegroClassLibrary" %>
<!DOCTYPE html>
<html>
	<head runat="server">
<!--#include virtual="inc/CM_meta.inc" -->
		<script src="js/Resources.<%= this.LanguageSetting %>.js" type="text/javascript"></script>
		<script src="js/SC_MM_05_S01.js" type="text/javascript"></script>
		<script src="js/CM_MS_SearchWindow.js" type="text/javascript"></script>
		<script src="js/SC_MS_SearchWindow.js" type="text/javascript"></script>
	</head>
	<body>
		<a name="pagetop"></a>
		<form id="Form1" runat="server" method="post">
			<table>
				<tr>
					<td>
<%-- 
						<cc1:Header id="Header1" runat="server" Title="仕入一覧"
							F01ButtonText="ヘルプ"
							F02ButtonText="リセット"
							F04ButtonText="新規"
							F05ButtonText="参照"
							F06ButtonText="検索"
							F07ButtonText="ページダウン"
							F08ButtonText="ページアップ"
							F09ButtonText="仕入確認票"
							F10ButtonText="仕入明細表"
							F11ButtonText="画面印刷"
							F12ButtonText="閉じる">
 --%>
						<cc1:Header id="Header1" runat="server" Title="<%$ Resources:Web, SC_CS000771 %>"
							F01ButtonText="<%$ Resources:Web, ZZ_FC000026 %>"
							F02ButtonText="<%$ Resources:Web, ZZ_FC000029 %>"
							F04ButtonText="<%$ Resources:Web, ZZ_FC000115 %>"
							F05ButtonText="<%$ Resources:Web, ZZ_FC000074 %>"
							F06ButtonText="<%$ Resources:Web, ZZ_FC000052 %>"
							F07ButtonText="<%$ Resources:Web, ZZ_FC000025 %>"
							F08ButtonText="<%$ Resources:Web, ZZ_FC000024 %>"
							F09ButtonText="<%$ Resources:Web, ZZ_FC000076 %>"
							F10ButtonText="<%$ Resources:Web, ZZ_FC000080 %>"
							F11ButtonText="<%$ Resources:Web, ZZ_FC000040 %>"
							F12ButtonText="<%$ Resources:Web, ZZ_FC000165 %>"
							MultiLanguageMode="true">
						</cc1:Header>
						<div class="msg_container">
							<asp:Label id="MessageLabel" runat="server" Width="100%"></asp:Label>
						</div>
						<table class="bd_table_bg grid_container overline" style="width: 1170px; margin-top: 10px;">
							<tr>
								<td class="bd_item_ttl_bg" style="width: 110px;"><%-- 仕入日 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000806 %>" /></td>
								<td class="bd_item_val_bg" style="width: 210px;">
									<cc1:DateBox id="PuDateFromText" runat="server"
										NextControlID="PuDateToText"
										ClientF05Script="openCalendarWindow"
										ClientFocusScript="defaultFunctionKeyHeader">
									</cc1:DateBox><%-- ～ --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000060 %>" />
									<cc1:DateBox id="PuDateToText" runat="server"
										NextControlID="PuNoFromText"
										ClientF05Script="openCalendarWindow"
										ClientFocusScript="defaultFunctionKeyHeader">
									</cc1:DateBox>
								</td>
								<td class="bd_item_ttl_bg" style="width: 100px;"><%-- 仕入番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000809 %>" /></td>
								<td class="bd_item_val_bg" style="width: 180px;">
									<cc1:CustomTextBox id="PuNoFromText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="PuNoToText"
										Width="78px" MaxLength="10"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase">
									</cc1:CustomTextBox>
									<%-- ～ --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000060 %>" />
									<cc1:CustomTextBox id="PuNoToText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="SuplCodeText"
										Width="78px" MaxLength="10"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase">
									</cc1:CustomTextBox>
								</td>
								<td class="bd_item_ttl_bg" style="width: 110px;"><%-- 仕入先 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000784 %>" /></td>
								<td class="bd_item_val_bg" colspan="2">
									<cc1:CustomTextBox id="SuplCodeText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientF05Script="searchSuplCode"
										NextControlID="SuplSlipNo"
										Width="87px" MaxLength="11"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase"
										AutoPostBack="True">
									</cc1:CustomTextBox>
									<cc1:EncodeLabel id="SuplShortNameLabel" runat="server">
									</cc1:EncodeLabel>
								</td>
								<td class="bd_item_ttl_bg" style="width: 95px;"><%-- 仕入先伝票番号 --%><cc1:EncodeLabel runat="server" id="SuplSlipNoLabel" Text="<%$ Resources:Web, SC_CS006219 %>" /></td>
								<td class="bd_item_val_bg" colspan="2" style="width: 100px;">
									<cc1:CustomTextBox id="SuplSlipNo" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="DeptCodeText"
										Width="90px" MaxLength="10"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase">
									</cc1:CustomTextBox>
								</td>
							</tr>
							<tr>
								<td class="bd_item_ttl_bg">
									<span class="lbl_hit_adj" style="width: 34px;"><%-- 部門 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001858 %>" /></span>
									<span class="lbl_hit_adj" style="width: 30px; text-align: right;">
										<cc1:CustomCheckBox id="SubDeptSearchCheckBox" runat="server"
											ClientFocusScript="defaultFunctionKeyHeader"
											NextControlID="DeptCodeText">
										</cc1:CustomCheckBox>
									</span>
								</td>
								<td class="bd_item_val_bg">
									<cc1:CustomTextBox id="DeptCodeText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientF05Script="searchDeptCode"
										NextControlID="EmpCodeText"
										Width="80px" MaxLength="10"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase"
										AutoPostBack="True">
									</cc1:CustomTextBox>
									<cc1:EncodeLabel id="DeptShortNameLabel" runat="server">
									</cc1:EncodeLabel>
								</td>
								<td class="bd_item_ttl_bg"><%-- 担当者 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001476 %>" /></td>
								<td class="bd_item_val_bg">
									<cc1:CustomTextBox id="EmpCodeText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientF05Script="searchEmpCode"
										NextControlID="ProjCodeText"
										Width="80px" MaxLength="10"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase"
										AutoPostBack="True">
									</cc1:CustomTextBox>
									<cc1:EncodeLabel id="EmpShortNameLabel" runat="server">
									</cc1:EncodeLabel>
								</td>
								<td class="bd_item_ttl_bg">
									<cc1:EncodeLabel id="ProjTitleLabel" runat="server" Text="<%$ Resources:Web, SC_CS000232 %>" /><%-- プロジェクト --%>
								</td>
								<td class="bd_item_val_bg" colspan="5">
									<cc1:CustomTextBox id="ProjCodeText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="PoDateFromText"
										ClientF05Script="searchProjCode"
										Width="190px" MaxLength="23"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase"
										AutoPostBack="True">
									</cc1:CustomTextBox>
									<cc1:EncodeLabel id="ProjShortNameLabel" runat="server">
									</cc1:EncodeLabel>
								</td>
							</tr>
							<tr>
								<td class="bd_item_ttl_bg" ><%-- 発注日 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001788 %>" /></td>
								<td class="bd_item_val_bg">
									<cc1:DateBox id="PoDateFromText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientF05Script="openCalendarWindow"
										NextControlID="PoDateToText">
									</cc1:DateBox>
									<%-- ～ --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000060 %>" />
									<cc1:DateBox id="PoDateToText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientF05Script="openCalendarWindow"
										NextControlID="PoNoFromText">
									</cc1:DateBox>
								</td>
								<td class="bd_item_ttl_bg"><%-- 発注番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001795 %>" /></td>
								<td class="bd_item_val_bg">
									<cc1:CustomTextBox id="PoNoFromText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="PoNoToText"
										Width="78px"  MaxLength="10"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase">
									</cc1:CustomTextBox>
									<%-- ～ --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000060 %>" />
									<cc1:CustomTextBox id="PoNoToText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="SuplBillSlipNoText"
										Width="78px" MaxLength="10"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase">
									</cc1:CustomTextBox>
								</td>
								<td class="bd_item_ttl_bg"><%-- 請求書番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001342 %>" /></td>
								<td class="bd_item_val_bg" colspan="5">
									<cc1:CustomTextBox id="SuplBillSlipNoText" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										Width="145px" MaxLength="15"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase"
										NextControlID="ProdCodeText">
									</cc1:CustomTextBox>
								</td>
							</tr>
							<tr>
								<td class="bd_item_ttl_bg"><%-- 商品 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001152 %>" /></td>
								<td class="bd_item_val_bg" colspan="3">
									<cc1:CustomTextBox id="ProdCodeText" runat="server"
										ClientF05Script="searchProdCode"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="PoAdminNo"
										Width="220px" MaxLength="20"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase"
										AutoPostBack="True">
									</cc1:CustomTextBox>
									<cc1:EncodeLabel id="ProdNameLabel" runat="server">
									</cc1:EncodeLabel>
								</td>
								<td class="bd_item_ttl_bg"><%-- 発注管理番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS006200 %>" /></td>
								<td class="bd_item_val_bg" colspan="2">
									<cc1:CustomTextBox id="PoAdminNo" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="OriginTypeDrop"
										Width="235px" MaxLength="30"
										ImeMode="Inactive">
									</cc1:CustomTextBox>
								</td>
								<td class="bd_item_ttl_bg"><%-- 発生元 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS006220 %>" /></td>
								<td class="bd_item_val_bg" colspan="2">
									<cc1:CustomDropDownList id="OriginTypeDrop" runat="server"
										Width="78px"
										NextControlID="PuModeTypeDrop"
										ClientFocusScript="defaultFunctionKeyHeader">
									</cc1:CustomDropDownList>
								</td>
							</tr>
							<tr>
								<td class="bd_item_ttl_bg"><%-- 仕入形態 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000777 %>" /></td>
								<td class="bd_item_val_bg">
									<cc1:CustomDropDownList id="PuModeTypeDrop" runat="server"
										Width="150px"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="BookBasisTypeDrop">
									</cc1:CustomDropDownList>
								</td>
								<td class="bd_item_ttl_bg"><%-- 仕入計上基準 --%><cc1:EncodeLabel runat="server" text="<%$ Resources:Web, SC_CS000778 %>"></cc1:EncodeLabel></td>
								<td class="bd_item_val_bg">
									<cc1:CustomDropDownList id="BookBasisTypeDrop" runat="server"
										NextControlID="DealTypeDrop"
										ClientFocusScript="defaultFunctionKeyHeader"
										Width="150px">
									</cc1:CustomDropDownList>
								</td>
								<td class="bd_item_ttl_bg"><%-- 取引区分 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS006354 %>" /></td>
								<td class="bd_item_val_bg">
									<cc1:CustomDropDownList id="DealTypeDrop" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="PriceUndecidedRadio"
										Width="150px">
									</cc1:CustomDropDownList>
								</td>
								<td class="bd_item_ttl_bg" style="width: 95px">
									<cc1:EncodeLabel id="PriceUndecidedTitleLabel" runat="server"></cc1:EncodeLabel>
								</td>
								<td class="bd_item_val_bg" colspan="3">
									<cc1:CustomRadioButtonList id="PriceUndecidedRadio" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader" 
										NextControlID="HoldFlgRadio" Width="170px">
										<%-- <asp:ListItem Value="1" Selected="True" Text="仮単価のみ" /> --%>
										<asp:ListItem Value="1" Selected="True" Text="<%$ Resources:Web, SC_CS000371 %>" />
										<%-- <asp:ListItem Value="0" Text="全て" /> --%>
										<asp:ListItem Value="0" Text="<%$ Resources:Web, SC_CS001371 %>" />
									</cc1:CustomRadioButtonList>
								</td>
							</tr>
							<tr>
								<td class="bd_item_ttl_bg"><%-- 支払保留 --%><cc1:EncodeLabel runat="server" Width="100px" Text="<%$ Resources:Web, SC_CS000850 %>" /></td>
								<td class="bd_item_val_bg">
									<cc1:CustomRadioButtonList id="HoldFlgRadio" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="ApprovalStatusTypeDrop">
										<%-- <asp:ListItem Value="1" Selected="True" Text="保留のみ" /> --%>
										<asp:ListItem Value="1" Selected="True" Text="<%$ Resources:Web, SC_CS001898 %>" />
										<%-- <asp:ListItem Value="0" Text="全て" /> --%>
										<asp:ListItem Value="0" Text="<%$ Resources:Web, SC_CS001371 %>" />
									</cc1:CustomRadioButtonList>
								</td>
								<td class="bd_item_ttl_bg">
									<%-- 承認状態 --%>
									<cc1:EncodeLabel id="ApprovalStatusTypeTitleLabel" runat="server" Text="<%$ Resources:Web, SC_CS001206 %>" />
								</td>
								<td class="bd_item_val_bg">
									<cc1:CustomDropDownList id="ApprovalStatusTypeDrop" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="RedSlipRadio"
										Width="95px">
									</cc1:CustomDropDownList>
								</td>
								<td class="bd_item_ttl_bg"><%-- 履歴伝票表示 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001986 %>" /></td>
								<td class="bd_item_val_bg">
									<cc1:CustomRadioButtonList id="RedSlipRadio" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										NextControlID="InputEmpCodeText">
										<%-- <asp:ListItem Value="0" Selected="True" Text="しない" /> --%>
										<asp:ListItem Value="0" Selected="True" Text="<%$ Resources:Web, SC_CS000187 %>" />
										<%-- <asp:ListItem Value="1" Text="する" /> --%>
										<asp:ListItem Value="1" Text="<%$ Resources:Web, SC_CS000190 %>" />
									</cc1:CustomRadioButtonList>
								</td>
								<td class="bd_item_ttl_bg"><%-- 入力者 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001657 %>" /></td>
								<td class="bd_item_val_bg">
									<cc1:CustomTextBox id="InputEmpCodeText" runat="server"
										Width="95px"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientF05Script="searchInputEmpCode"
										NextControlID="HeadCustomItemPanel"
										MaxLength="10"
										ImeMode="Inactive" CheckOption="SingleByte" TextTransform="UpperCase"
										AutoPostBack="True">
									</cc1:CustomTextBox>
									<cc1:EncodeLabel id="InputEmpNameLabel" runat="server">
									</cc1:EncodeLabel>
								</td>
								<td class="bd_item_ttl_bg">運送業者</td>
								<td class="bd_item_val_bg">
									<cc1:CustomDropDownList id="CarrierDrop" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader">
									</cc1:CustomDropDownList>
								</td>
							</tr>
						</table>
						<div id="HeadCustomItemPanelRow" runat="server" class="ac-container-div" style='<%# this.GetHeadCustomControlCount() == 0 ? "display: none" : "width: 1170px; position: relative;"%>'>
							<%-- 汎用項目 --%>
							<cc1:CustomItemPanel id="HeadCustomItemPanel" runat="server" class="bd_table_bg grid_container" style="width: 100%; border-spacing: 1px; table-layout: fixed;"
								DisplayType="ListHead"
								FunctionCode="SCMM05_PU"
								NextControlID="DtilCustomItemPanel"
								ClientFocusScriptTextBox="defaultFunctionKeyHeader"
								ClientFocusScriptListBox="defaultFunctionKeyHeader"
								UseBasisDateFlg="true"
								FirstBasisDate="PuDateToText"
								SecondBasisDate="PuDateFromText"
								HeadClass="bd_item_ttl_bg"
								BodyClass="bd_item_val_bg"
								TitleWidth="11"
								MaxCharacter="36"
								UseAccordionFlg="true"
								TitleName="<%$ Resources:Web, SC_CS006277 %>"
							/>
						</div>
						<div id="DtilCustomItemPanelRow" runat="server" class="ac-container-div" style='<%# this.GetDtilCustomControlCount() == 0 ? "display: none" : "width: 1170px; position: relative;"%>'>
							<%-- 明細汎用項目 --%>
							<cc1:CustomItemPanel id="DtilCustomItemPanel" runat="server" class="bd_table_bg grid_container" style="width: 100%; border-spacing: 1px; table-layout: fixed;"
								DisplayType="ListDetail"
								FunctionCode="SCMM05_PU"
								NextControlID="DisplayRecordsDrop"
								ClientFocusScriptTextBox="defaultFunctionKeyHeader"
								ClientFocusScriptListBox="defaultFunctionKeyHeader"
								UseBasisDateFlg="true"
								FirstBasisDate="PuDateToText"
								SecondBasisDate="PuDateFromText"
								HeadClass="bd_item_ttl_bg"
								BodyClass="bd_item_val_bg"
								TitleWidth="11"
								MaxCharacter="36"
								UseAccordionFlg="true"
								TitleName="<%$ Resources:Web, SC_CS006278 %>"
							/>
						</div>
						<table class="bd_table_bg grid_container" style="width: 1170px; position: relative; top: -2px; margin-bottom: 8px;">
							<tr>
								<td class="bd_td_bg_1" colspan="7">
									<table class="layout_container" style="width: 100%;">
										<tr>
											<td><cc1:EncodeLabel id="FindRecordsLabel" runat="server"></cc1:EncodeLabel></td>
											<td class="btn_list_container">
												<%-- 表示件数 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001826 %>" />
												<cc1:CustomDropDownList id="DisplayRecordsDrop" runat="server"
													Width="44px"
													ClientFocusScript="defaultFunctionKeyHeader"
													NextControlID="SearchButton">
													<asp:ListItem Value="6" Text="6" />
													<asp:ListItem Value="20" Text="20" />
													<asp:ListItem Value="50" Text="50" />
												</cc1:CustomDropDownList>
												<%-- ZZ_BN000063: 検索 --%>
												<cc1:StyledButton id="SearchButton" runat="server"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientClickScript="checkSerch"
													Text="<%$ Resources:Web, ZZ_BN000063 %>"
													CssClass="normal"
												/>
												<%-- ZZ_BN000062: リセット --%>
												<cc1:StyledButton id="ResetButton" runat="server"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientClickScript="clickResetButton"
													Text="<%$ Resources:Web, ZZ_BN000062 %>"
													CssClass="normal"
												/>
												<%-- ZZ_BN000051: 新規 --%>
												<cc1:StyledButton id="NewButton" runat="server"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientClickScript="showSC_MM_05_S02"
													Text="<%$ Resources:Web, ZZ_BN000051 %>"
													CssClass="normal"
												/>
												<%-- ZZ_BN000185: 仕入確認票 --%>
												<cc1:StyledButton id="PuListButton" runat="server"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientClickScript="reportPrint"
													Text="<%$ Resources:Web, ZZ_BN000185 %>"
													CssClass="normal icon_printer"
												/>
												<%-- ZZ_BN000186: 仕入一覧表 --%>
												<cc1:StyledButton id="PuListOutputButton" runat="server"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientClickScript="reportPrint"
													Text="<%$ Resources:Web, ZZ_BN000186 %>"
													CssClass="normal icon_printer"
												/>
												<%-- ZZ_BN000180: 商品別仕入明細表 --%>
												<cc1:StyledButton id="PuDetailListButton" runat="server"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientClickScript="reportPrint"
													Text="<%$ Resources:Web, ZZ_BN000180 %>"
													CssClass="normal icon_printer"
												/>
												<%-- ZZ_BN000019: 閉じる --%>
												<cc1:StyledButton id="CloseButton" runat="server"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientClickScript="closeWindow"
													Text="<%$ Resources:Web, ZZ_BN000019 %>"
													CssClass="normal"
												/>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<cc1:CustomDataGrid id="DataGrid1" runat="server"
							AutoGenerateColumns="False"
							Width="1170px"
							AllowSorting="True"
							AllowPaging="True"
							DataKeyField="PU_NO"
							ShowFooter="True">
							<FooterStyle CssClass="bd_item_val_bg_1"></FooterStyle>
							<Columns>
<%-- 
								<asp:TemplateColumn HeaderStyle-Width="20px"
									ItemStyle-HorizontalAlign="Center"
									HeaderText="承認">
 --%>
								<asp:TemplateColumn HeaderStyle-Width="52px"
									ItemStyle-HorizontalAlign="Center"
									HeaderText="<%$ Resources:Web, SC_CS001203 %>">
									<ItemTemplate>
										<cc1:EncodeLabel id="DetailApprovalStatusTypeLabel" runat="server"
											Text='<%# setApprovalStatusText((string) DataBinder.Eval(Container, "DataItem.[APPROVAL_STATUS_TYPE]"), (string) DataBinder.Eval(Container, "DataItem.[APPROVAL_CANCEL_FLG]")) %>'>
										</cc1:EncodeLabel>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderStyle-Width="124px" ItemStyle-HorizontalAlign="Center">
									<HeaderTemplate>
<%-- 
										<cc1:CustomLinkButton id="PuNoLinkButton" runat="server"
											oncommand="DataGrid1_Sort"
											CommandName="[PU_NO]"
											text="仕入番号">
 --%>
										<cc1:CustomLinkButton id="PuNoLinkButton" runat="server"
											oncommand="DataGrid1_Sort"
											CommandName="[PU_NO]"
											text="<%$ Resources:Web, SC_CS000809 %>">
										</cc1:CustomLinkButton><br/>
										<%-- 売上番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001713 %>" />
									</HeaderTemplate>
									<ItemTemplate>
										<table class="bd_table_bg layout_container" style="width: 120px;">
											<tr>
												<td class="bd_item_val_bg">
													<span style="width: 16px">
													<%-- 添付資料あり --%>
														<cc1:CustomImage ID="AttachmentFileImg" runat="server"
															ImageUrl="<%$ Resources:Web, SC_IM000187 %>"
															Visible='<%# DataBinder.Eval(Container, "DataItem.[ATTACHMENT_EXISTS_FLG]").ToString()=="1" %>'
															AlternateText="<%$ Resources:Web, SC_CS006232 %>">
														</cc1:CustomImage>
													</span>
												</td>
												<td class="bd_item_val_bg">
													<span style="width: 84px;">
														<cc1:CustomLinkButton id="PuNoCodeLinkButton" runat="server"
															CommandName="PU_NO"
															CssClass="bd_item_val_link"
															Text='<%# DataBinder.Eval(Container, "DataItem.[PU_NO]").ToString() %>'
															ClientFocusScript="defaultFunctionKeyHeader">
														</cc1:CustomLinkButton>
													</span>
													<cc1:EncodeLabel id="PrgUpdateDateTime" runat="server"
														visible="false"
														Text='<%# ((DateTime)(DataBinder.Eval(Container, "DataItem.[PRG_UPDATE_DATETIME]"))).ToString("yyyyMMddHHmmssfff") %>'>
													</cc1:EncodeLabel>
													<cc1:EncodeLabel id="RefPrgUpdateDateTime" runat="server"
														visible="false"
														Text='<%# ((DateTime)(DataBinder.Eval(Container, "DataItem.[REF_PRG_UPDATE_DATETIME]"))).ToString("yyyyMMddHHmmssfff") %>'>
													</cc1:EncodeLabel><br/>
													<span>
														<cc1:EncodeLabel id="SaNoLabel" runat="server"
															Text='<%# DataBinder.Eval(Container, "DataItem.[SA_NO]").ToString() %>'>
														</cc1:EncodeLabel>
													</span>
												</td>
												<td class="bd_item_val_bg" style="width: 16px; text-align: center;">
<%-- 
													<asp:Image id="Image1" runat="server"
														ImageUrl="img/SC_c1_canceled_order.gif"
														visible='<%# DataBinder.Eval(Container, "DataItem.[CANCELED_ORDER_FLG]").ToString()=="1" %>'>
 --%>
													<cc1:CustomImage id="Image1" runat="server"
														ImageUrl="<%$ Resources:Web, SC_IM000163 %>"
														visible='<%# DataBinder.Eval(Container, "DataItem.[CANCELED_ORDER_FLG]").ToString()=="1" %>'>
													</cc1:CustomImage>
												</td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:TemplateColumn>
<%-- 
								<asp:TemplateColumn HeaderStyle-Width="80px"
									ItemStyle-HorizontalAlign="Center"
									SortExpression="[PU_DATE]"
									HeaderText="仕入日">
 --%>
								<%--<asp:TemplateColumn HeaderStyle-Width="67px"
									ItemStyle-HorizontalAlign="Center"
									SortExpression="[PU_DATE]"
									HeaderText="<%$ Resources:Web, SC_CS000806 %>">
									<ItemTemplate>
										<cc1:EncodeLabel id="DetailPuDateLabel" runat="server"
											Text='<%# ((DateTime) DataBinder.Eval(Container, "DataItem.[PU_DATE]")).ToString("yyyy/MM/dd") %>'>
										</cc1:EncodeLabel>
									</ItemTemplate>
								</asp:TemplateColumn>--%>
								<asp:TemplateColumn HeaderStyle-Width="93px" ItemStyle-HorizontalAlign="Center">
									<HeaderTemplate>
										<span class="lbl_hit_adj"><cc1:EncodeLabel runat="server" Text="仕入日" /><br/>
											<cc1:CustomLinkButton id="CustomLinkButton1" runat="server"
												OnCommand="DataGrid1_Sort"
												CommandName="[CARRIER_CODE]"
												Text="運送業者">
											</cc1:CustomLinkButton>
										</span>
									</HeaderTemplate>
									<ItemTemplate>
										<span class="lbl_hit_adj">
											<cc1:EncodeLabel id="DetailPuDateLabel" runat="server"
												Text='<%# ((DateTime) DataBinder.Eval(Container, "DataItem.[PU_DATE]")).ToString("yyyy/MM/dd") %>'>
											</cc1:EncodeLabel>
										</span><br/>
										<span class="lbl_hit_adj">
											<cc1:EncodeLabel id="DetailCarrierNameLabel" runat="server"
												Text='<%# (string) DataBinder.Eval(Container, "DataItem.[CARRIER_NAME]") %>'>
											</cc1:EncodeLabel>
										</span>
									</ItemTemplate>
									<FooterTemplate>
										<%-- <cc1:EncodeLabel id="TotalKeyGrandTtlNameLabel" Runat="server" Width="105px" Text="(基軸換算金額合計)"> --%>
										<cc1:EncodeLabel id="EncodeLabel3" Runat="server" Width="150px" Text="<%$ Resources:Web, SC_CS000014 %>">
										</cc1:EncodeLabel>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderStyle-Width="157px" ItemStyle-HorizontalAlign="Left">
									<HeaderTemplate>
										<span class="lbl_hit_adj">
<%-- 
											<cc1:CustomLinkButton id="SuplNameLinkButton" runat="server"
												OnCommand="DataGrid1_Sort"
												CommandName="[SUPL_SHORT_NAME]"
												Text="仕入先">
 --%>
											<cc1:CustomLinkButton id="SuplNameLinkButton" runat="server"
												OnCommand="DataGrid1_Sort"
												CommandName="[SUPL_SHORT_NAME]"
												Text="<%$ Resources:Web, SC_CS000784 %>">
											</cc1:CustomLinkButton><br/>
											<%-- 仕入先請求書番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000791 %>" />
										</span>
									</HeaderTemplate>
									<ItemTemplate>
										<span class="lbl_hit_adj">
											<cc1:EncodeLabel id="DetailSuplShortNameLabel" runat="server"
												Text='<%# (string) DataBinder.Eval(Container, "DataItem.[SUPL_SHORT_NAME]") %>'>
											</cc1:EncodeLabel>
										</span><br/>
										<span class="lbl_hit_adj">
											<cc1:EncodeLabel id="DetailSuplBillSlipNoLabel" runat="server"
												width="153px"
												Text='<%# (string) DataBinder.Eval(Container, "DataItem.[SUPL_BILL_SLIP_NO]") %>'>
											</cc1:EncodeLabel>
										</span>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderStyle-Width="235px" ItemStyle-HorizontalAlign="Left">
									<HeaderTemplate>
										<span class="lbl_hit_adj">
<%-- 
											<cc1:CustomLinkButton id="DeptNameLinkButton" runat="server"
												OnCommand="DataGrid1_Sort"
												CommandName="[DEPT_SHORT_NAME]" Text="部門">
 --%>
											<cc1:CustomLinkButton id="DeptNameLinkButton" runat="server"
												OnCommand="DataGrid1_Sort"
												CommandName="[DEPT_SHORT_NAME]" Text="<%$ Resources:Web, SC_CS001858 %>">
											</cc1:CustomLinkButton>
											&nbsp;
											<%-- 担当者 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001476 %>" /><br/>
											<%-- 発注管理番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS006200 %>" />
										</span>
									</HeaderTemplate>
									<ItemTemplate>
										<span class="lbl_hit_adj">
											<cc1:EncodeLabel id="DetailDeptNameLabel" runat="server"
												Text='<%# DataBinder.Eval(Container, "DataItem.[DEPT_SHORT_NAME]") != DBNull.Value ? (string) DataBinder.Eval(Container, "DataItem.[DEPT_SHORT_NAME]") : "" %>'>
											</cc1:EncodeLabel>
											<asp:Label id="PuDeptCode" runat="server" style="display:none;"
												Text='<%# (string) DataBinder.Eval(Container, "DataItem.[DEPT_CODE]") %>'>
											</asp:Label>
										</span>&nbsp;
										<span class="lbl_hit_adj">
											<cc1:EncodeLabel id="DetailEmpNameLabel" runat="server"
												Text='<%# (string) DataBinder.Eval(Container, "DataItem.[EMP_SHORT_NAME]") %>'>
											</cc1:EncodeLabel>
										</span><br/>
										<span class="lbl_hit_adj">
											<cc1:EncodeLabel id="DetailPoAdminNo" runat="server" width="230px"
												Text='<%# (DataBinder.Eval(Container, "DataItem.[PO_ADMIN_NO]")).ToString()  %>'>
											</cc1:EncodeLabel>
										</span>
									</ItemTemplate>
								</asp:TemplateColumn>
								<%-- <asp:TemplateColumn HeaderStyle-Width="145px" ItemStyle-HorizontalAlign="Right" HeaderText="仕入金額"> --%>
								<asp:TemplateColumn HeaderStyle-Width="154px" ItemStyle-HorizontalAlign="Right" HeaderText="<%$ Resources:Web, SC_CS000775 %>">
									<ItemTemplate>
										<span style="text-align: left; width: 34px;">
											<cc1:EncodeLabel id="DetailCurCode" runat="server"
												Text='<%# DataBinder.Eval(Container,"DataItem.[CUR_CODE]") %>'>
											</cc1:EncodeLabel>
										</span>
										<span style="text-align: right; width: 112px;">
											<cc1:EncodeLabel id="DetailGrandTtlLabel" runat="server"
												Text='<%# DataBinder.Eval(Container,"DataItem.[GRAND_TTL]") != DBNull.Value ? formatAmt((Decimal) DataBinder.Eval(Container.DataItem, "[GRAND_TTL]"), (DataBinder.Eval(Container.DataItem,"[CUR_CODE]")).ToString()) : "" %>'>
											</cc1:EncodeLabel>
										</span>
									</ItemTemplate>
									<FooterTemplate>
    									<cc1:EncodeLabel id="TotalGrandTtlLabel" Runat="server" Width="144px">
										</cc1:EncodeLabel>
									</FooterTemplate>
								</asp:TemplateColumn>
								<%-- <asp:TemplateColumn HeaderStyle-Width="55px" ItemStyle-HorizontalAlign="Center" HeaderText="仕入形態"> --%>
								<asp:TemplateColumn HeaderStyle-Width="61px" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ Resources:Web, SC_CS000777 %>">
									<ItemTemplate>
										<cc1:EncodeLabel id="PuModeTypeLabel" runat="server"
											Text='<%# (string) DataBinder.Eval(Container, "DataItem.[PU_MODE_TYPE_NAME]") %>'>
										</cc1:EncodeLabel>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderStyle-Width="93px" ItemStyle-HorizontalAlign="Center">
									<HeaderTemplate>
										<span class="lbl_hit_adj"><%-- 発注番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001795 %>" /><br/>
<%-- 
											<cc1:CustomLinkButton id="DetailPoDateLinkButton" runat="server"
												OnCommand="DataGrid1_Sort"
												CommandName="[PO_DATE]"
												Text="発注日">
 --%>
											<cc1:CustomLinkButton id="DetailPoDateLinkButton" runat="server"
												OnCommand="DataGrid1_Sort"
												CommandName="[PO_DATE]"
												Text="<%$ Resources:Web, SC_CS001788 %>">
											</cc1:CustomLinkButton>
										</span>
									</HeaderTemplate>
									<ItemTemplate>
										<span class="lbl_hit_adj">
											<cc1:EncodeLabel id="DetailPoNoLabel" runat="server"
												Text='<%# DataBinder.Eval(Container, "DataItem.[PO_NO]") %>' >
											</cc1:EncodeLabel>
										</span><br/>
										<span class="lbl_hit_adj">
											<cc1:EncodeLabel id="DetailPoDateLabel" runat="server"
												Text='<%# DataBinder.Eval(Container, "DataItem.[PO_DATE]") != DBNull.Value ? ((DateTime) DataBinder.Eval(Container, "DataItem.[PO_DATE]")).ToString("yyyy/MM/dd") : string.Empty %>'>
											</cc1:EncodeLabel>
										</span>
									</ItemTemplate>
									<FooterTemplate>
										<%-- <cc1:EncodeLabel id="TotalKeyGrandTtlNameLabel" Runat="server" Width="105px" Text="(基軸換算金額合計)"> --%>
										<cc1:EncodeLabel id="TotalKeyGrandTtlNameLabel" Runat="server" Width="150px" Text="<%$ Resources:Web, SC_CS000014 %>">
										</cc1:EncodeLabel>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderStyle-Width="152px" ItemStyle-HorizontalAlign="Center">
									<HeaderTemplate>
										<span class="lbl_hit_adj">
<%-- 
											<cc1:CustomLinkButton id="DetailCutoffDateLinkButton" runat="server"
												OnCommand="DataGrid1_Sort"
												CommandName="[CUTOFF_DATE]"
												Text="支払処理日">
 --%>
											<cc1:CustomLinkButton id="DetailCutoffDateLinkButton" runat="server"
												OnCommand="DataGrid1_Sort"
												CommandName="[CUTOFF_DATE]"
												Text="<%$ Resources:Web, SC_CS000847 %>">
											</cc1:CustomLinkButton><br/>
<%-- 
											<cc1:CustomLinkButton id="DetailOriginPuNoLinkButton" runat="server"
												oncommand="DataGrid1_Sort"
												CommandName="[ORIGIN_PU_NO]"
												text="発生伝票番号">
 --%>
											<cc1:CustomLinkButton id="DetailOriginPuNoLinkButton" runat="server"
												oncommand="DataGrid1_Sort"
												CommandName="[ORIGIN_PU_NO]"
												text="<%$ Resources:Web, SC_CS001724 %>">
											</cc1:CustomLinkButton>
										</span>
									</HeaderTemplate>
									<ItemTemplate>
										<span class="lbl_hit_adj" style="text-align: center;">
											<cc1:EncodeLabel id="DetailCutoffDateLabel" runat="server"
												Text='<%# DataBinder.Eval(Container, "DataItem.[CUTOFF_DATE]") %>'>
											</cc1:EncodeLabel>
										</span><br/>
										<span class="lbl_hit_adj" style="text-align: center;">
											<cc1:EncodeLabel id="DetailOriginalPuNoLabel" runat="server"
												Text='<%# DataBinder.Eval(Container, "DataItem.[ORIGIN_PU_NO]") %>'>
											</cc1:EncodeLabel>
										</span>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<%-- ZZ_BN000022: コピー --%>
										<cc1:StyledButton id="CopyButton" runat="server"
											ClientFocusScript="defaultFunctionKeyHeader"
											Text="<%$ Resources:Web, ZZ_BN000022 %>"
											CssClass="small icon_copy"
											CommandName="Copy"
										/>
										<%-- ZZ_BN000084: 削除 --%>
										<cc1:StyledButton id="DeleteButton" runat="server"
											ClientFocusScript="defaultFunctionKeyHeader"
											ClientClickScript="clickDeleteButton"
											Text="<%$ Resources:Web, ZZ_BN000084 %>"
											CssClass="small icon_delete"
											CommandName="Delete"
										/>
										<input id="poDeptCodeFlgHidden" type="hidden" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "[PO_DEPT_CODE_FLG]") %>' name="poDeptCodeFlgHidden" />
										<cc1:EncodeLabel id="ImportSlipNoFlg" runat="server"
											visible="false"
											Text='<%# ((DataBinder.Eval(Container, "DataItem.[IMPORT_SLIP_NO_FLG]")).ToString()) %>'>
										</cc1:EncodeLabel>
										<cc1:EncodeLabel id="SuplSlipNo" runat="server"
											visible="false"
											Text='<%# ((DataBinder.Eval(Container, "DataItem.[SUPL_SLIP_NO]")).ToString()) %>'>
										</cc1:EncodeLabel>
										<cc1:EncodeLabel id="SuplSlipNoFlg" runat="server"
											visible="false"
											Text='<%# ((DataBinder.Eval(Container, "DataItem.[SUPL_SLIP_NO_FLG]")).ToString()) %>'>
										</cc1:EncodeLabel>
									</ItemTemplate>
									<FooterTemplate>
										<cc1:EncodeLabel id="TotalKeyGrandTtlLabel" Runat="server" Width="148px">
										</cc1:EncodeLabel>
									</FooterTemplate>
								</asp:TemplateColumn>
							</Columns>
						</cc1:CustomDataGrid>
						<div class="btn_list_container" style="width: 1170px;">
							<%-- ZZ_BN000051: 新規 --%>
							<cc1:StyledButton id="NewButton2" runat="server"
								ClientFocusScript="defaultFunctionKeyHeader"
								ClientClickScript="showSC_MM_05_S02"
								Text="<%$ Resources:Web, ZZ_BN000051 %>"
								CssClass="normal"
							/>
							<%-- ZZ_BN000019: 閉じる --%>
							<cc1:StyledButton id="CloseButton2" runat="server"
								ClientFocusScript="defaultFunctionKeyHeader"
								ClientClickScript="closeWindow"
								Text="<%$ Resources:Web, ZZ_BN000019 %>"
								CssClass="normal"
							/>
						</div>
						<input id="deleteDate" type="hidden" runat="server" />
						<input id="postCountHidden" type="hidden" runat="server" />
						<input id="searchRetryHidden" type="hidden" runat="server" />
					</td>
				</tr>
<!--#include virtual="inc/CM_footer.inc" -->
			</table>
			<input id="clickHidden" type="hidden" runat="server" name="clickHidden" />
		</form>
	</body>
</html>
