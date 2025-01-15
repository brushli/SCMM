<%@ Page language="c#" AutoEventWireup="false" Inherits="Infocom.Allegro.SC.SC_MM_05_S02" Codebehind="SC_MM_05_S02.aspx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="Infocom.Allegro.Web.WebControls" Assembly="AllegroClassLibrary" %>
<%@ Import Namespace="Infocom.Allegro.SC.MS" %>
<%@ Import Namespace="Infocom.Allegro.Web" %>
<!DOCTYPE html>
<html>
	<head runat="server">
		<!--#include virtual="inc/CM_meta.inc" -->
		<script src="js/Resources.<%= this.LanguageSetting %>.js" type="text/javascript"></script>
		<script src="js/CM_MS_SearchWindow.js" type="text/javascript"></script>
		<script src="js/SC_MS_SearchWindow.js" type="text/javascript"></script>
		<script src="js/SC_MM_SearchWindow.js" type="text/javascript"></script>
		<script src="js/SC_MM_05_S02.js" type="text/javascript"></script>
	</head>
	<body>
		<a name="pagetop"></a>
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td>
<%-- 
						<cc1:Header id="Header" Title="仕入入力" runat="server"
							F01ButtonText="ヘルプ"
							F02ButtonText="キャンセル"
							F03ButtonText="削除"
							F04ButtonText="行更新"
							F05ButtonText="参照"
							F06ButtonText="更新"
							F09ButtonText="タブ切換"
							F10ButtonText="伝票印刷"
							F11ButtonText="画面印刷"
							F12ButtonText="閉じる">
 --%>
						<cc1:Header id="Header1" Title="<%$ Resources:Web, SC_CS000807 %>" runat="server"
							F01ButtonText="<%$ Resources:Web, ZZ_FC000026 %>"
							F02ButtonText="<%$ Resources:Web, ZZ_FC000013 %>"
							F03ButtonText="<%$ Resources:Web, ZZ_FC000073 %>"
							F04ButtonText="<%$ Resources:Web, ZZ_FC000063 %>"
							F05ButtonText="<%$ Resources:Web, ZZ_FC000074 %>"
							F06ButtonText="<%$ Resources:Web, ZZ_FC000058 %>"
							F09ButtonText="<%$ Resources:Web, ZZ_FC000019 %>"
							F10ButtonText="<%$ Resources:Web, ZZ_FC000146 %>"
							F11ButtonText="<%$ Resources:Web, ZZ_FC000040 %>"
							F12ButtonText="<%$ Resources:Web, ZZ_FC000165 %>"
							MultiLanguageMode="true">
						</cc1:Header>
						<div class="msg_container" style="width: 1170px; position: relative;">
							<asp:Label id="MessageLabel" runat="server"
								style="width: 80%;"
								EnableViewState="False">
							</asp:Label>
							<cc1:EncodeLabel id="LastSlipNoLabel" runat="server"
								Width="20%" style="position: absolute; right: 0; bottom: 0;">
							</cc1:EncodeLabel>
						</div>
						<table class="layout_container" style="width: 1170px; margin-top: 1px;">
							<tr>
								<td>
									<table class="bd_table_bg grid_container overline" style="width: 1170px;">
										<tr>
											<td class="bd_item_ttl_bg" style="width: 82px;"><%-- 仕入番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000809 %>" /></td>
											<td class="bd_item_val_bg" style="width: 154px;">
												<cc1:CustomTextBox id="PuNoText" runat="server"
													Width="80px" MaxLength="10"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="PoRefText"
													ClientChangeScript="puNoTextChanged"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientF05Script="openModWindow"
													Texttransform="UpperCase"
													DisregardsMode="True">
												</cc1:CustomTextBox>
												<cc1:EncodeLabel id="ModeLabel" runat="server">
												</cc1:EncodeLabel>
											</td>
											<td class="bd_item_ttl_bg" style="width: 73px;"><%-- 発注参照 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001766 %>" /></td>
											<td class="bd_item_val_bg" style="width: 144px;">
												<cc1:CustomTextBox id="PoRefText" runat="server"
													Width="80px" MaxLength="10"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="RcptRefText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="poNoTextChanged"
													ClientF05Script="openPoNoWindow"
													Texttransform="UpperCase">
												</cc1:CustomTextBox>
											</td>
											<td class="bd_item_ttl_bg" style="width: 125px;"><%-- 入荷参照 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001613 %>" /></td>
											<td class="bd_item_val_bg" style="width: 110px;">
												<cc1:CustomTextBox id="RcptRefText" runat="server"
													Width="80px" MaxLength="10"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="PuDateText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="rcptNoTextChanged"
													ClientF05Script="openRcptNoWindow"
													Texttransform="UpperCase">
												</cc1:CustomTextBox>
											</td>
											<td class="bd_item_ttl_bg" style="width: 105px;"><%-- 仕入日 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000806 %>" /></td>
											<td class="bd_item_val_bg" style="width: 125px;">
												<cc1:DateBox id="PuDateText" runat="server"
													NextControlID="SuplCodeText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="makeWithChange"
													ClientF05Script="openCalenderWindow"
													AutoPostBack="True"
													ValidatesRange="true"
													MinValue="1900-01-01"
													MaxValue="9998-12-31"
													IsRequiredField="True">
												</cc1:DateBox>
												<asp:Label id="OriginPuDate" runat="server" style="display:none;" />
											</td>
											<td class="bd_item_ttl_bg" style="width: 106px;">
<%-- 
												<cc1:EncodeLabel id="StatusTitleLabel" runat="server"
													Text="承認状態" Visible="false">
 --%>
												<cc1:EncodeLabel id="StatusTitleLabel" runat="server"
													Text="<%$ Resources:Web, SC_CS001206 %>" Visible="false">
												</cc1:EncodeLabel>
												<span>&nbsp;</span>
											</td>
											<td class="bd_item_val_bg" style="width: 135px;">
												<cc1:CustomDropDownList id="StatusDropdownlist" runat="server"
													Width="95px"
													NextControlID="SuplCodeText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="statusChange"
													AutoPostBack="True">
												</cc1:CustomDropDownList>
											</td>
										</tr>
										<tr>
											<td class="bd_item_ttl_bg"><%-- 仕入先 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000784 %>" /></td>
											<td class="bd_item_val_bg" colspan="3">
												<cc1:CustomTextBox id="SuplCodeText" runat="server"
													Width="87px" MaxLength="11"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="SuplNameText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="makeWithChange"
													ClientF05Script="openSuplCodeWindow"
													Texttransform="UpperCase"
													AutoPostBack="true"
													IsRequiredField="True">
												</cc1:CustomTextBox>
												<cc1:CustomTextBox id="SuplNameText" runat="server"
													Width="125px" MaxLength="50"
													ImeMode="active"
													NextControlID="DealDateText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="makeWithChange">
												</cc1:CustomTextBox>
												<%-- ZZ_BN000087: 詳細 --%>
												<cc1:StyledButton
													id="SuplDtilButton" runat="server"
													ClientFocusScript="defaultFunctionKeyHeader"
													Text="<%$ Resources:Web, ZZ_BN000087 %>"
													CssClass="tiny"
													DisregardsMode="True"
												/>
											</td>
											<td class="bd_item_ttl_bg"><%-- 取引日 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000939 %>" /></td>
											<td class="bd_item_val_bg">
												<cc1:DateBox id="DealDateText" runat="server"
													NextControlID="PoAdminNoText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="makeWithChange"
													ClientF05Script="openCalenderWindow"
													ValidatesRange="true"
													MinValue="1900-01-01"
													MaxValue="9998-12-31"
													AutoPostBack="True"
													IsRequiredField="True">
												</cc1:DateBox>
											</td>
											<td class="bd_item_ttl_bg"><%-- 発注管理番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS006200 %>" /></td>
											<td class="bd_item_val_bg" colspan="3">
												<cc1:CustomTextBox id="PoAdminNoText" runat="server"
													Width="360px" MaxLength="30"
													ImeMode="inactive"
													NextControlID="PuModeTypeList"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="makeWithChange">
												</cc1:CustomTextBox>
											</td>
										</tr>
										<tr>
											<td class="bd_item_ttl_bg"><%-- 仕入形態 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000777 %>" /></td>
											<td class="bd_item_val_bg">
												<cc1:CustomDropDownList id="PuModeTypeList" runat="server"
													Width="150px"
													NextControlID="RefPuText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="puModeTypeChange"
													AutoPostBack="True">
												</cc1:CustomDropDownList>
											</td>
											<td class="bd_item_ttl_bg"><%-- 仕入参照 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000781 %>" /></td>
											<td class="bd_item_val_bg">
												<cc1:CustomTextBox id="RefPuText" runat="server"
													Width="80px" MaxLength="10"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="SuplBillSlipNoText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="refPuNoTextChange"
													ClientF05Script="openRefPuNoWindow"
													Texttransform="UpperCase">
												</cc1:CustomTextBox>
											</td>
											<td class="bd_item_ttl_bg"><%-- 仕入先請求書番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000791 %>" /></td>
											<td class="bd_item_val_bg" colspan="2">
												<cc1:CustomTextBox id="SuplBillSlipNoText" runat="server"
													Width="180px" MaxLength="15"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="CurCodeList"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="makeWithChange"
													Texttransform="UpperCase">
												</cc1:CustomTextBox>
											</td>
											<td class="bd_item_ttl_bg" ><%-- 通貨 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001520 %>" /></td>
											<td class="bd_item_val_bg" colspan="2">
												<cc1:CurrencyList id="CurCodeList" runat="server"
													Width="57px"
													ClientChangeScript="curCodeChange"
													ClientFocusScript="defaultFunctionKeyHeader"
													NextControlID="EmpCodeText"
													AutoPostBack="True">
												</cc1:CurrencyList>
											</td>
										</tr>
									</table>
									<table class="bd_table_bg grid_container" style="width: 1170px; position: relative; top: -2px">
										<tr>
											<td class="bd_item_ttl_bg" style="width: 82px;"><%-- 担当者 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001476 %>" /></td>
											<td class="bd_item_val_bg" style="width: 228px;">
												<cc1:CustomTextBox id="EmpCodeText" runat="server"
													Width="80px" MaxLength="10"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="DeptCodeText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="makeWithChange"
													ClientF05Script="openEmpCodeWindow"
													Texttransform="UpperCase"
													AutoPostBack="true"
													IsRequiredField="True">
												</cc1:CustomTextBox>
												<cc1:EncodeLabel id="EmpNameLabel" runat="server">
												</cc1:EncodeLabel>
											</td>
											<td class="bd_item_ttl_bg" style="width: 144px;"><%-- 部門 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001858 %>" /></td>
											<td class="bd_item_val_bg" style="width: 236px;">
												<cc1:CustomTextBox id="DeptCodeText" runat="server"
													Width="80px" MaxLength="10"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="ProjCodeText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="makeWithChange"
													ClientF05Script="openDeptCodeWindow"
													Texttransform="UpperCase"
													AutoPostBack="true"
													IsRequiredField="True">
												</cc1:CustomTextBox>
												<cc1:EncodeLabel id="DeptNameLabel" runat="server">
												</cc1:EncodeLabel>
												<input id="OrgDeptCodeHdn" type="hidden" runat="server" />
												<input id="OrgDeptNameHdn" type="hidden" runat="server" />
											</td>
											<td class="bd_item_ttl_bg" style="width: 105px;">
												<cc1:EncodeLabel id="ProjTitleLabel" runat="server">
												</cc1:EncodeLabel>
												<span>&nbsp;</span>
											</td>
											<td class="bd_item_val_bg">
												<cc1:CustomTextBox id="ProjCodeText" runat="server"
													Width="190px" MaxLength="23"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="WhCodeText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="makeWithChange"
													ClientF05Script="openProjCodeWindow"
													Texttransform="UpperCase"
													AutoPostBack="true">
												</cc1:CustomTextBox>
												<cc1:EncodeLabel id="ProjNameLabel" runat="server">
												</cc1:EncodeLabel>
												<input id="OrgProjCodeHdn" type="hidden" runat="server" />
												<input id="OrgProjNameHdn" type="hidden" runat="server" />
											</td>
										</tr>
									</table>
									<table class="bd_table_bg grid_container" style="width: 1170px; position: relative; top: -4px;">
										<tr>
											<td class="bd_item_ttl_bg" style="width: 82px;"><%-- 納入区分 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001672 %>" /></td>
											<td class="bd_item_val_bg" style="width: 154px;">
<%-- 
												<cc1:CustomRadioButton id="DeliTypeWRadio" runat="server"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientClickScript="makeWithChange"
													GroupName="DeliType"
													Text="自社倉庫"
													AutoPostBack="true"
													NextControlID="WhCodeText">
 --%>
												<cc1:CustomRadioButton id="DeliTypeWRadio" runat="server"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientClickScript="makeWithChange"
													GroupName="DeliType"
													Text="<%$ Resources:Web, SC_CS000866 %>"
													AutoPostBack="true"
													NextControlID="WhCodeText">
												</cc1:CustomRadioButton>
											</td>
											<td class="bd_item_val_bg" style="width: 344px;">
												<cc1:CustomTextBox id="WhCodeText" runat="server"
													Width="100px" MaxLength="5"
													ImeMode="inactive"
													NextControlID="DeliCustCodeText"
													ClientFocusScript="setNextCtrlTab"
													ClientChangeScript="makeWithChange"
													ClientF05Script="openWarehouseWindow"
													CheckOption="SingleByte"
													AutoPostBack="true"
													Texttransform="UpperCase">
												</cc1:CustomTextBox>
												<cc1:EncodeLabel id="WhShortNameLabel" runat="server">
												</cc1:EncodeLabel>
											</td>
											<td class="bd_item_val_bg" style="width: 216px;">
<%-- 
												<cc1:CustomRadioButton id="DeliTypeDRadio" runat="server"
													GroupName="DeliType"
													AutoPostBack="True"
													Text="客先直送"
													NextControlID="DeliCustCodeText"
													ClientClickScript="makeWithChange"
													ClientFocusScript="defaultFunctionKeyHeader">
 --%>
												<cc1:CustomRadioButton id="DeliTypeDRadio" runat="server"
													GroupName="DeliType"
													AutoPostBack="True"
													Text="<%$ Resources:Web, SC_CS000489 %>"
													NextControlID="DeliCustCodeText"
													ClientClickScript="makeWithChange"
													ClientFocusScript="defaultFunctionKeyHeader">
												</cc1:CustomRadioButton>
											</td>
											<td class="bd_item_val_bg" style="width:230px"><%-- 納入先 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001673 %>" />
												<cc1:CustomTextBox id="DeliCustCodeText" runat="server"
													Width="87px" MaxLength="11"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="InputEmpCodeText"
													ClientFocusScript="setNextCtrlTab"
													ClientChangeScript="makeWithChange"
													ClientF05Script="openCustCodeWindow"
													Texttransform="UpperCase"
													AutoPostBack="true"
													IsRequiredField="true">
												</cc1:CustomTextBox>
												<cc1:EncodeLabel id="DeliCustNameLabel" runat="server">
												</cc1:EncodeLabel>
											</td>
											<td class="bd_item_ttl_bg" style="width: 106px;">入力者</td>
											<td class="bd_item_val_bg">
												<cc1:CustomTextBox id="InputEmpCodeText" runat="server"
													Width="80px" MaxLength="10"
													ImeMode="inactive"
													CheckOption="SingleByte"
													NextControlID="PuNameText"
													ClientFocusScript="defaultFunctionKeyHeader"
													ClientChangeScript="makeWithChange"
													ClientF05Script="openEmpCodeWindow"
													Texttransform="UpperCase"
													AutoPostBack="true">
												</cc1:CustomTextBox>
												<cc1:EncodeLabel id="InputEmpNameLable" runat="server">
												</cc1:EncodeLabel>

											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td style="height: 10px;"></td>
							</tr>
							<tr>
								<td>
									<div style="width: 1170px;">
										<cc1:TabSelector id="TabSelector1" runat="server">
<%-- 
											<cc1:TabItem id="TabItem1" runat="server"
												TabPageID="BasicTab"
												ClientClickScript="clickBase"
												Text="基本">
 --%>
											<cc1:TabItem id="TabItem1" runat="server"
												TabPageID="BasicTab"
												ClientClickScript="clickBase"
												Text="<%$ Resources:Web, SC_CS000460 %>">
											</cc1:TabItem>
<%-- 
											<cc1:TabItem id="TabItem2" runat="server"
												TabPageID="DetailTab"
												ClientClickScript="clickDetail"
												Text="詳細">
 --%>
											<cc1:TabItem id="TabItem2" runat="server"
												TabPageID="DetailTab"
												ClientClickScript="clickDetail"
												Text="<%$ Resources:Web, SC_CS001211 %>">
											</cc1:TabItem>
										</cc1:TabSelector>
									</div>
									<table class="layout_container" style="width: 1170px;">
										<tr>
											<td class="tab_bg_1">
												<table style="width: 100%; border-spacing: 4px; border-collapse: separate;">
													<tr>
														<td class="tab_bg_2" style="padding: 8px;">
															<div id="BasicTab" style="min-height: 355px;" runat="server">
																<table class="bd_table_bg grid_container" style="width: 100%; margin-top: 10px;">
																	<tr>
																		<td class="bd_item_ttl_bg" style="width: 125px;"><%-- 受注番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000993 %>" /></td>
																		<td class="bd_item_val_bg" style="width: 204px;">
																			<cc1:EncodeLabel id="SoNoLabel" runat="server">
																			</cc1:EncodeLabel>
																		</td>
																		<td class="bd_item_ttl_bg" style="width: 91px;"><%-- 受注日 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000987 %>" /></td>
																		<td class="bd_item_val_bg" style="width: 182px;">
																			<cc1:EncodeLabel id="SoDateLabel" runat="server">
																			</cc1:EncodeLabel>
																		</td>
																		<td class="bd_item_ttl_bg" style="width: 102px;"><%-- 得意先 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001574 %>" /></td>
																		<td class="bd_item_val_bg" style="width: 431px;">
																			<cc1:EncodeLabel id="CustNameLabel" runat="server">
																			</cc1:EncodeLabel>
																		</td>
																	</tr>
																</table>
																<table class="bd_table_bg grid_container" style="width: 100%;">
																	<tr>
																		<td class="bd_item_ttl_bg" style="width: 125px;"><%-- 件名 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000536 %>" /></td>
																		<td class="bd_item_val_bg" style="width: 383px;">
																			<cc1:CustomTextBox id="PuNameText" runat="server"
																				Width="305px" MaxLength="30"
																				ImeMode="Active"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="ExchangeTypeList">
																			</cc1:CustomTextBox>
																		</td>
																		<td class="bd_item_ttl_bg" style="width: 66px;"><%-- 為替区分 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000317 %>" /></td>
																		<td class="bd_item_val_bg" style="width: 207px;">
																			<cc1:CustomDropDownList id="ExchangeTypeList" runat="server"
																				Width="195px"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="exchangeTypeChange"
																				IsRequiredField="True"
																				NextControlID="ExchangeRezNoText"
																				AutoPostBack="True">
																				<asp:ListItem Value="" Selected="true" Text="" />
																				<%-- <asp:ListItem Value="1" Text="予約あり" /> --%>
																				<asp:ListItem Value="1" Text="<%$ Resources:Web, SC_CS001965 %>" />
																				<%-- <asp:ListItem Value="2" Text="予約なし（先方負担）" /> --%>
																				<asp:ListItem Value="2" Text="<%$ Resources:Web, SC_CS001967 %>" />
																				<%-- <asp:ListItem Value="3" Text="予約なし（自社負担）" /> --%>
																				<asp:ListItem Value="3" Text="<%$ Resources:Web, SC_CS001966 %>" />
																			</cc1:CustomDropDownList>
																		</td>
																		<td class="bd_item_ttl_bg" style="width: 97px;"><%-- 為替予約番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000319 %>" /></td>
																		<td class="bd_item_val_bg" style="width: 114px;">
																			<cc1:CustomTextBox id="ExchangeRezNoText" runat="server"
																				Width="100px" MaxLength="10"
																				CheckOption="SingleByte" ImeMode="Inactive" TextTransform="UpperCase"
																				ClientFocusScript="setNextCtrlPuName"
																				ClientF05Script="openRateWindow"
																				ClientChangeScript="makeWithChange"
																				AutoPostBack="true"
																				NextControlID="RateText">
																			</cc1:CustomTextBox>
																		</td>
																		<td class="bd_item_ttl_bg" style="width: 44px;"><%-- レート --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000271 %>" /></td>
																		<td class="bd_item_val_bg">
																			<cc1:NumberBox id="RateText" runat="server"
																				Width="73px" MaxLength="7"
																				AllowDecimal="true"
																				Scale="2" Precision="6"
																				IsRequiredField="True"
																				ClientFocusScript="setNextCtrlPuName"
																				ClientF05Script="openRateWindow"
																				ClientChangeScript="makeWithChange"
																				AutoPostBack="true"
																				NextControlID="DeliPlaceCodeText">
																			</cc1:NumberBox>
																		</td>
																	</tr>
																</table>
																<table class="bd_table_bg grid_container" style="width: 100%;">
																	<tr>
																		<td class="bd_item_ttl_bg"><%-- 受渡場所 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001000 %>" /></td>
																		<td class="bd_item_val_bg" colspan="8">
																			<cc1:CustomTextBox id="DeliPlaceCodeText" runat="server"
																				Width="28px"
																				MaxLength="2"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="deliPlaceChange"
																				ClientF05Script="callDeliPlaceCodeWindow"
																				NextControlID="DeliPlaceNameText"
																				AutoPostBack="True"
																				ImeMode="Inactive"
																				TextTransform="UpperCase"
																				CheckOption="SingleByte"
																				IsRequiredField="True">
																			</cc1:CustomTextBox>
																			<cc1:CustomTextBox id="DeliPlaceNameText" runat="server"
																				Width="370px" MaxLength="30"
																				ImeMode="active"
																				NextControlID="ZipText"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange">
																			</cc1:CustomTextBox>
																			<cc1:EncodeLabel id="DeliPlaceCountryCode" runat="server"
																				Visible="false">
																			</cc1:EncodeLabel>
																		</td>
																	</tr>
																	<tr>
																		<td class="bd_item_ttl_bg" style="width: 125px;"><%-- 郵便番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001958 %>" /></td>
																		<td class="bd_item_val_bg" colspan="2">
																			<cc1:CustomTextBox id="ZipText" runat="server"
																				Width="66px" MaxLength="8"
																				ImeMode="inactive"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="StateText"
																				CheckOption="SingleByte"
																				AutoPostBack="true">
																			</cc1:CustomTextBox>
																		</td>
																		<td class="bd_item_ttl_bg" style="width: 125px;"><%-- 都道府県 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001566 %>" /></td>
																		<td class="bd_item_val_bg" style="width: 181px;">
																			<cc1:CustomTextBox id="StateText" runat="server"
																				Width="58px" MaxLength="4"
																				ImeMode="active"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="CityText">
																			</cc1:CustomTextBox>
																		</td>
																		<td class="bd_item_ttl_bg" style="width: 157px;"><%-- 市区町村 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000827 %>" /></td>
																		<td class="bd_item_val_bg" style="width: 342px;" colspan="3">
																			<cc1:CustomTextBox id="CityText" runat="server"
																				Width="190px" MaxLength="15"
																				ImeMode="active"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="Address1Text">
																			</cc1:CustomTextBox>
																		</td>
																	</tr>
																	<tr>
																		<td class="bd_item_ttl_bg"><%-- 町域名 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001509 %>" /></td>
																		<td class="bd_item_val_bg" colspan="4">
																			<cc1:CustomTextBox id="Address1Text" runat="server"
																				Width="370px" MaxLength="30"
																				ImeMode="active"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="Address2Text">
																			</cc1:CustomTextBox>
																		</td>
																		<td class="bd_item_ttl_bg"><%-- ビル名 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000222 %>" /></td>
																		<td class="bd_item_val_bg" colspan="3">
																			<cc1:CustomTextBox id="Address2Text" runat="server"
																				Width="330px" MaxLength="30"
																				ImeMode="active"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="PhoneText">
																			</cc1:CustomTextBox>
																		</td>
																	</tr>
																	<tr>
																		<td class="bd_item_ttl_bg"><%-- 電話番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001557 %>" /></td>
																		<td class="bd_item_val_bg" colspan="2">
																			<cc1:CustomTextBox id="PhoneText" runat="server"
																				Width="108px" MaxLength="15"
																				ImeMode="inactive"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="FaxText"
																				CheckOption="SingleByte">
																			</cc1:CustomTextBox>
																		</td>
																		<td class="bd_item_ttl_bg"><%-- FAX 番号 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000114 %>" /></td>
																		<td class="bd_item_val_bg">
																			<cc1:CustomTextBox id="FaxText" runat="server"
																				Width="108px" MaxLength="15"
																				ImeMode="inactive"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="DeliUserNameText"
																				CheckOption="SingleByte">
																			</cc1:CustomTextBox>
																		</td>
																		<td class="bd_item_ttl_bg"><%-- 納入先担当者 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001675 %>" /></td>
																		<td class="bd_item_val_bg" colspan="3">
																			<cc1:CustomTextBox id="DeliUserNameText" runat="server"
																				Width="130px" MaxLength="10"
																				ImeMode="active"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="DtTypeList">
																			</cc1:CustomTextBox>
																		</td>
																	</tr>
																	<tr>
																		<td class="bd_item_ttl_bg" style="vertical-align: top" rowspan="2"><%-- 支払条件 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000848 %>" /></td>
																		<td class="bd_item_val_bg" colspan="8">
																			<cc1:CustomRadioButtonlist id="DtTypeList" runat="server"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientClickScript="makeWithChange"
																				NextControlID="Dt1SttlMthdCodeList"
																				AutoPostBack="true">
																				<%-- <asp:ListItem Value="L" Text="一括支払" /> --%>
																				<asp:ListItem Value="L" Text="<%$ Resources:Web, SC_CS000331 %>" />
																				<%-- <asp:ListItem Value="E" Text="都度支払" /> --%>
																				<asp:ListItem Value="E" Text="<%$ Resources:Web, SC_CS001564 %>" />
																			</cc1:CustomRadioButtonlist>
																			<span>&nbsp;</span>
																			<cc1:CustomDropDownList id="Dt1SttlMthdCodeList" runat="server"
																				Width="78px" MaxLength="12"
																				Precision="12" Scale="0"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				IsRequiredField="True"
																				NextControlID="Dt1BasisAmtText"
																				AutoPostBack="true">
																			</cc1:CustomDropDownList>
																			<%-- (ただし金額 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000010 %>" />
																			<cc1:NumberBox id="Dt1BasisAmtText" runat="server"
																				Width="94px" MaxLength="12"
																				Precision="12" Scale="0"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="domesticRequiredCheck"
																				NextControlID="Dt2RatioText">
																			</cc1:NumberBox>
																			<%-- を超えた場合 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000301 %>" />
																			<cc1:NumberBox id="Dt2RatioText" runat="server"
																				Width="31px" MaxLength="3"
																				Precision="3" Scale="0"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="domesticRequiredCheck"
																				NextControlID="Dt2SttlMthdCodeList"
																				MaxValue="100" MinValue="1">
																			</cc1:NumberBox>
																			<%-- ％は --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000005 %>" />
																			<cc1:CustomDropDownList id="Dt2SttlMthdCodeList" runat="server"
																				Width="78px"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="domesticRequiredCheck"
																				NextControlID="Dt3SttlMthdCodeList"
																				AutoPostBack="true">
																			</cc1:CustomDropDownList>
																			<%-- 、残りは --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000056 %>" />
																			<cc1:CustomDropDownList id="Dt3SttlMthdCodeList" runat="server"
																				Width="78px"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="domesticRequiredCheck"
																				NextControlID="DtSightText"
																				AutoPostBack="true">
																			</cc1:CustomDropDownList>
																			)
																			<span>&nbsp;</span>
																			<%-- サイト --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000185 %>" />
																			<cc1:NumberBox id="DtSightText" runat="server"
																				Width="31px" MaxLength="3"
																				Precision="3"
																				Scale="0"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="CutoffDateText">
																			</cc1:NumberBox>
																			<%-- 日 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001595 %>" />
																		</td>
																	</tr>
																	<tr>
																		<td class="bd_item_ttl_bg" style="width: 102px;">
																			<%-- 締日 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001536 %>" />
																		</td>
																		<td class="bd_item_val_bg">
																			<cc1:DateBox id="CutoffDateText" runat="server"
																				ClientFocusScript="defaultFunctionKey"
																				ClientF05Script="searchCalenderWindow"
																				ClientChangeScript="makeWithChange"
																				ValidatesRange="true"
																				ShowPrevNextButton="False"
																				IsRequiredField="True"
																				Enabled="false"
																				NextControlID="PymtPlanDateText">
																			</cc1:DateBox><cc1:StyledButton id="CutoffDateBackButton" runat="server"
																				AutoPostBack="true"
																				CssClass="image back"
																				ToolTip="<%$ Resources:Web, SC_CS001538 %>"
																				ClientFocusScript="defaultFunctionKeyHeader"
																			/><cc1:StyledButton id="CutoffDateAdvanceButton" runat="server"
																				AutoPostBack="true"
																				CssClass="image advance"
																				ToolTip="<%$ Resources:Web, SC_CS001537 %>"
																				ClientFocusScript="defaultFunctionKeyHeader"
																			/>
																		</td>
																		<td class="bd_item_ttl_bg">
																			<%-- 支払期限 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000845 %>" />
																		</td>
																		<td class="bd_item_val_bg">
																			<cc1:DateBox
																				id="PymtPlanDateText"
																				runat="server"
																				ClientFocusScript="defaultFunctionKey"
																				ClientChangeScript="makeWithChange"
																				NextControlID="HoldCheck"
																				IsRequiredField="True"
																				CheckOption="SingleByte"
																				ValidatesRange="true"
																				ClientF05Script="openCalenderWindow">
																			</cc1:DateBox>
																			<span>&nbsp;</span>
																			<cc1:EncodeLabel id="CutOffDateConditionNote" runat="server">
																			</cc1:EncodeLabel>
																		</td>
																		<td class="bd_item_ttl_bg"><%-- 支払保留 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000850 %>" /></td>
																		<td class="bd_item_val_bg">
																			<cc1:CustomCheckBox id="HoldCheck" runat="server"
																			ClientChangeScript="makeWithChange"
																			ClientFocusScript="defaultFunctionKey"
																			NextControlID="CtaxFractionRoundTypeList">
																			</cc1:CustomCheckBox>
																		</td>
																		<td class="bd_item_ttl_bg" style="width: 80px;">消費税端数</td>
																		<td class="bd_item_val_bg">
																			<cc1:CustomRadioButtonlist id="CtaxFractionRoundTypeList" runat="server"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientClickScript="makeWithChange"
																				AutoPostBack="true"
																				NextControlID="DtNoteText">
																				<asp:ListItem Value="R" Text="四捨五入" />
																				<asp:ListItem Value="U" Text="切上げ" />
																				<asp:ListItem Value="C" Text="切捨て" />
																			</cc1:CustomRadioButtonlist>
																		</td>
																	</tr>
																	<tr>
																		<td class="bd_item_ttl_bg"><%-- 支払条件表記 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000849 %>" /></td>
																		<td class="bd_item_val_bg" colspan="4">
																			<cc1:CustomTextBox id="DtNoteText" runat="server"
																				Width="370px" MaxLength="50"
																				ImeMode="active"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				IsRequiredField="True"
																				NextControlID="CarrierCodeDrop">
																			</cc1:CustomTextBox>
																		</td>
																		<td class="bd_item_ttl_bg"><%-- 支払処理日 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000847 %>" /></td>
																		<td class="bd_item_val_bg">
																			<cc1:EncodeLabel id="PaymentDateLabel" runat="server">
																			</cc1:EncodeLabel>
																		</td>
																		<td class="bd_item_ttl_bg" style="width: 65px;">運送業者</td>
																		<td class="bd_item_val_bg" >
																			<cc1:CustomDropDownList id="CarrierCodeDrop" runat="server"
																				Width="100px"
																				NextControlID="RemarksCodeText"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				AutoPostBack="True">
																			</cc1:CustomDropDownList>
																		</td>
																	</tr>
																	<tr>
																		<td class="bd_item_ttl_bg"><cc1:EncodeLabel id="RemarksLabel" runat="server"></cc1:EncodeLabel></td>
																		<td class="bd_item_val_bg" colspan="8">
																			<cc1:CustomTextBox id="RemarksCodeText" runat="server"
																				Width="37px" MaxLength="3"
																				ImeMode="inactive"
																				Texttransform="UpperCase"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				ClientF05Script="openRemarksWindow"
																				AutoPostBack="true"
																				NextControlID="RemarksText">
																			</cc1:CustomTextBox>
																			<cc1:CustomTextBox id="RemarksText" runat="server"
																				style="width: 630px; vertical-align: bottom;" MaxLength="100"
																				ImeMode="active" TextMode="MultiLine" Rows="2"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				MaxRowCount="3"
																				NextControlID="BookBasisTypeList">
																			</cc1:CustomTextBox>
																			<span>&nbsp;</span>
																			<%-- ZZ_BN000072: 管理項目 --%>
																			<cc1:StyledButton id="AdminItemButton" runat="server"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientClickScript="openAdminItemWindow"
																				Text="<%$ Resources:Web, ZZ_BN000072 %>"
																				CssClass="small"
																				DisregardsMode="True"
																			/>
																		</td>
																	</tr>
																	<tr>
																		<td class="bd_item_ttl_bg"><%-- 仕入計上基準 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000778 %>" /></td>
																		<td class="bd_item_val_bg" colspan="2">
																			<cc1:CustomDropDownList id="BookBasisTypeList" runat="server"
																				ClientFocusScript="defaultFunctionKeyHeader"
																				ClientChangeScript="makeWithChange"
																				NextControlID="DealTypeList"
																				Width="150px">
																			</cc1:CustomDropDownList>
																		</td>
																		<td class="bd_item_ttl_bg"><%-- 取引区分 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS006354 %>"/></td>
																		<td class="bd_item_val_bg">
																					<cc1:CustomDropDownList id="DealTypeList" runat="server"
																						Width="150px"
																						IsRequiredField="True"
																						ClientFocusScript="defaultFunctionKeyHeader"
																						ClientChangeScript="makeWithChange"
																						NextControlID="CustomItemPanel">
																					</cc1:CustomDropDownList>
																		</td>
																		<td class="bd_item_ttl_bg">
																		<%-- 仕入先伝票番号 --%><cc1:EncodeLabel id="SuplSlipNoTitleLabel" runat="server" Text="<%$ Resources:Web, SC_CS006219 %>" Visible="false"></cc1:EncodeLabel></td>
																		<td class="bd_item_val_bg" colspan="5">
																			<cc1:EncodeLabel id="SuplSlipNoLabel" runat="server" Visible="false"></cc1:EncodeLabel>
																		</td>
																	</tr>
																</table>
																<cc1:CustomItemPanel id="CustomItemPanel" runat="server" class="bd_table_bg grid_container" style="width: 100%; border-spacing: 1px; table-layout: fixed;"
																	MasterType="SUPL"
																	DisplayType="InputHead"
																	FunctionCode="SCMM05_PU"
																	NextControlID="UpdateButton"
																	ClientFocusScriptTextBox="defaultFunctionKeyHeader"
																	ClientFocusScriptListBox="defaultFunctionKeyHeader"
																	ClientChangeScript="makeWithChange"
																	UseBasisDateFlg="true"
																	FirstBasisDate="PuDateText"
																	HeadClass="bd_item_ttl_bg"
																	BodyClass="bd_item_val_bg"
																	TitleWidth="11"
																	MaxCharacter="35"
																/>
															</div>
															<div id="DetailTab" style="min-height: 355px;" runat="server">
																<table class="layout_container" style="width: 100%;">
																	<tr>
																		<td colspan="8">
																		<div style="text-align: right;"><%-- （レート： --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000012 %>" /><cc1:EncodeLabel id="RateLabel" runat="server"></cc1:EncodeLabel><%-- ）(単価欄 仮は仮単価、金額欄 ＊は税込金額) --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000052 %>" /></div>
																			<table id="HeaderTable" runat="server" class="bd_table_bg grid_container" style="width: 1120px;">
																				<tr style="text-align: center;">
																					<td class="bd_item_ttl_bg" style="width: 39px;"><%-- 行 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000620 %>" /></td>
																					<td class="bd_item_ttl_bg">
																						<span class="lbl_hit_adj"><%-- 商品コード --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001158 %>" /></span><br/>
																						<span class="lbl_hit_adj"><%-- 商品名 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001198 %>" /></span>
																					</td>
																					<td class="bd_item_ttl_bg" style="width: 72px;">
																						<span class='<%# this.ProductSpecUseType == "2" ? "lbl_hit_adj" : "" %>' runat="Server" id="Span1">
																							<cc1:EncodeLabel id="HeaderSpec1NameLabel" runat="server">
																							</cc1:EncodeLabel>
																						</span><br/>
																						<span class='<%# this.ProductSpecUseType == "2" ? "lbl_hit_adj" : "" %>' runat="Server" id="Span2">
																							<cc1:EncodeLabel id="HeaderSpec2NameLabel" runat="server">
																							</cc1:EncodeLabel>
																						</span>
																					</td>
																					<td class="bd_item_ttl_bg" style="width: 206px;">
																						<span class="lbl_hit_adj"><%-- 倉庫 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001387 %>" /></span><br/>
<%-- 
																						<cc1:EncodeLabel id="LotDtilLabel" runat="server"
																							text = "ロット詳細">
 --%>
																						<cc1:EncodeLabel id="LotDtilLabel" runat="server"
																							text = "<%$ Resources:Web, SC_CS000293 %>">
																						</cc1:EncodeLabel>
																					</td>
																					<td class="bd_item_ttl_bg" style="width: 196px;">
																						<%-- 数量 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001259 %>" />
																						<%-- 単位 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001456 %>" />
																					</td>
																					<td class="bd_item_ttl_bg" style="width: 156px;">
																						<span class="lbl_hit_adj"><%-- 仕入単価 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000802 %>" /></span><br/>
																						<span class="lbl_hit_adj"><%-- 仕入金額 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000775 %>" /></span>
																					</td>
																					<td class="bd_item_ttl_bg" style="width: 127px;"><span>&nbsp;</span></td>
																				</tr>
																			</table>
																			<cc1:ClickableDataGrid id="DataGrid1" runat="server"
																				Width="1120px"
																				pagesize="4" ScrollItemsCount="4"
																				ShowHeader="False" AutoGenerateColumns="False"
																				DataKeyField="PU_LINE_ID"
																				AllowPaging="True">
																				<ItemStyle Height="32pt"></ItemStyle>
																				<Columns>
																					<asp:TemplateColumn ItemStyle-Width="39px" Itemstyle-HorizontalAlign="Center">
																						<ItemTemplate>
																							<span class="lbl_hit_adj">
																								<cc1:EncodeLabel id="PuLineNoLabel" runat="server"
																									Text='<%# DataBinder.Eval(Container, "DataItem.[PU_LINE_NO]") %>'>
																								</cc1:EncodeLabel>
																							</span><br/>
																							<div style="text-align: center;">
																							<span class="lbl_hit_adj">
<%-- 
																								<asp:Image id="LineRemarks" runat="server"
																									ImageUrl="img/SC_c1_remarks.gif"
																									alternateText='<%# DataBinder.Eval(Container, "DataItem.[LINE_REMARKS]") %>'
																									visible='<%# DataBinder.Eval(Container, "DataItem.[LINE_REMARKS]").ToString().Length > 0 %>'>
 --%>
																								<cc1:CustomImage id="LineRemarks" runat="server"
																									ImageUrl="<%$ Resources:Web, SC_IM000169 %>"
																									alternateText='<%# this.ConcatenateTag(DataBinder.Eval(Container, "DataItem.[LINE_REMARKS]").ToString(),DataBinder.Eval(Container, "DataItem.[BOOK_DEDUCTION_REASON_NAME]").ToString(),DataBinder.Eval(Container, "DataItem.[CUSTOM_ITEM_TAG]").ToString()) %>'
																									visible='<%# DataBinder.Eval(Container, "DataItem.[LINE_REMARKS]").ToString().Length > 0 || DataBinder.Eval(Container, "DataItem.[BOOK_DEDUCTION_REASON_NAME]").ToString().Length > 0 || DataBinder.Eval(Container, "DataItem.[CUSTOM_ITEM_TAG]").ToString().Length > 0%>'>
																								</cc1:CustomImage>
																							</span>
																							</div>
																						</ItemTemplate>
																						<EditItemTemplate>
																							<span class="lbl_hit_adj">
																								<cc1:EncodeLabel id="EditPuLineNoLabel" runat="server"
																									Text='<%# DataBinder.Eval(Container, "DataItem.[PU_LINE_NO]") %>'>
																								</cc1:EncodeLabel>
																							</span><br/>
																							<div style="text-align: center;">
																								<span class="lbl_hit_adj">
<%-- 
																									<asp:Image id="EditRemarks" runat="server"
																										ImageUrl="img/SC_c1_remarks.gif"
																										alternateText='<%# DataBinder.Eval(Container, "DataItem.[LINE_REMARKS]") %>'
																										visible='<%# DataBinder.Eval(Container, "DataItem.[LINE_REMARKS]").ToString().Length > 0 %>'>
 --%>
																									<cc1:CustomImage id="EditRemarks" runat="server"
																										ImageUrl="<%$ Resources:Web, SC_IM000169 %>"
																										alternateText='<%# this.ConcatenateTag(DataBinder.Eval(Container, "DataItem.[LINE_REMARKS]").ToString(),DataBinder.Eval(Container, "DataItem.[BOOK_DEDUCTION_REASON_NAME]").ToString(),DataBinder.Eval(Container, "DataItem.[CUSTOM_ITEM_TAG]").ToString()) %>'
																										visible='<%# DataBinder.Eval(Container, "DataItem.[LINE_REMARKS]").ToString().Length > 0 || DataBinder.Eval(Container, "DataItem.[BOOK_DEDUCTION_REASON_NAME]").ToString().Length > 0 || DataBinder.Eval(Container, "DataItem.[CUSTOM_ITEM_TAG]").ToString().Length > 0%>'>
																									</cc1:CustomImage>
																								</span>
																							</div>
																						</EditItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn>
																						<ItemTemplate>
																							<span style='<%# this.ProductSpecUseType == "0" ? "width: 361px" : "width: 288px" %>'>
																								<span class="lbl_hit_adj">
																									<cc1:EncodeLabel id="ProdCodeLabel" runat="server"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[PROD_CODE]") %>'>
																									</cc1:EncodeLabel>
																								</span><br/>
																								<span class="lbl_hit_adj">
																									<cc1:EncodeLabel id="ProdNameLabel" runat="server"
																										Width='<%# this.ProductSpecUseType == "0" ? System.Web.UI.WebControls.Unit.Pixel(361) : System.Web.UI.WebControls.Unit.Pixel(288)%>' 
																										WhiteSpace="Normal"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[PROD_SHORT_NAME]") %>'>
																									</cc1:EncodeLabel>
																								</span>
																							</span>
																						</ItemTemplate>
																						<EditItemTemplate>
																							<span style='<%# this.ProductSpecUseType == "0" ? "width: 361px" : "width: 288px" %>'>
																								<span class="lbl_hit_adj">
																									<cc1:CustomTextBox id="EditProdCodeText" runat="server"
																										NextControlID="EditProdNameText"
																										Width='<%# this.ProductSpecUseType == "0" ? System.Web.UI.WebControls.Unit.Pixel(361) : System.Web.UI.WebControls.Unit.Pixel(288)%>' 
																										MaxLength="20"
																										ImeMode="inactive"
																										Texttransform="UpperCase"
																										ClientFocusScript="defaultFunctionKeyBody"
																										ClientF05Script="openEditProdWindow"
																										SearchInMyParent="True"
																										CheckOption="SingleByte"
																										OnTextChanged="ProdCode_TextChanged"
																										AutoPostBack="true"
																										IsRequiredField="True"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[PROD_CODE]") %>'>
																									</cc1:CustomTextBox>
																								</span><br/>
																								<span class="lbl_hit_adj">
																									<cc1:CustomTextBox id="EditProdNameText" runat="server"
																										Width='<%# this.ProductSpecUseType == "0" ? System.Web.UI.WebControls.Unit.Pixel(361) : System.Web.UI.WebControls.Unit.Pixel(288)%>' 
																										MaxLength="30"
																										ImeMode="active"
																										NextControlID='<%# this.ProductSpecUseType == "0" ? "EditWhCodeText" : "EditProdSpec1List"%>'
																										SearchInMyParent="True"
																										ClientFocusScript="defaultFunctionKeyBody"
																										IsRequiredField="True"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[PROD_SHORT_NAME]") %>'>
																									</cc1:CustomTextBox>
																									<cc1:EncodeLabel
																										id="EditProdShortNameLabel" runat="server"
																										Visible="false"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[PROD_SHORT_NAME]") %>'>
																									</cc1:EncodeLabel>
																								</span>
																							</span>
																						</EditItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn ItemStyle-Width="72px" Itemstyle-HorizontalAlign="Center">
																						<ItemTemplate>
																							<span class='<%# this.ProductSpecUseType == "2" ? "lbl_hit_adj" : "" %>' runat="Server" id="Span3">
																								<cc1:EncodeLabel id="Spec1NameLabel" runat="server"
																									Text='<%# DataBinder.Eval(Container, "DataItem.[PROD_SPEC_1_NAME]") %>'
																									visible='<%# this.ProductSpecUseType != "0" %>'>
																								</cc1:EncodeLabel>
																							</span><br/>
																							<span class='<%# this.ProductSpecUseType == "2" ? "lbl_hit_adj" : "" %>' runat="Server" id="Span4">
																								<cc1:EncodeLabel id="Spec2NameLabel" runat="server"
																									Text='<%# DataBinder.Eval(Container, "DataItem.[PROD_SPEC_2_NAME]") %>'
																									visible='<%# this.ProductSpecUseType == "2" %>'>
																								</cc1:EncodeLabel>
																							</span>
																						</ItemTemplate>
																						<EditItemTemplate>
																							<span class='<%# this.ProductSpecUseType == "2" ? "lbl_hit_adj" : "" %>' runat="Server" id="Span5">
																								<cc1:CustomDropDownList id="EditProdSpec1List" runat="server"
																									Width="66px"
																									ClientFocusScript="defaultFunctionKeyBody"
																									ClientChangeScript="spec1CodeChange"
																									NextControlID='<%# this.ProductSpecUseType == "2" ? "EditProdSpec2List" : "EditWhCodeText"%>'
																									SearchInMyParent="True"
																									IsRequiredField="True"
																									OnSelectedIndexChanged="ProdSpec1List_SelectedIndexChanged"
																									visible='<%# this.ProductSpecUseType != "0" %>'
																									AutoPostBack="True">
																								</cc1:CustomDropDownList>
																							</span><br/>
																							<span class='<%# this.ProductSpecUseType == "2" ? "lbl_hit_adj" : "" %>' runat="Server" id="Span6">
																								<cc1:CustomDropDownList id="EditProdSpec2List" runat="server"
																									Width="66px"
																									ClientFocusScript="defaultFunctionKeyBody"
																									ClientChangeScript="spec2CodeChange"
																									NextControlID="EditWhCodeText"
																									SearchInMyParent="True"
																									IsRequiredField="True"
																									OnSelectedIndexChanged="ProdSpec2List_SelectedIndexChanged"
																									visible='<%# this.ProductSpecUseType == "2" %>'
																									AutoPostBack="True">
																								</cc1:CustomDropDownList>
																							</span>
																						</EditItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn ItemStyle-Width="206px">
																						<ItemTemplate>
																							<span class="lbl_hit_adj">
																								<cc1:EncodeLabel id="ItemWarehouseCodeLabel" runat="server"
																									Text='<%# DataBinder.Eval(Container, "DataItem.[WH_CODE]") %>'>
																								</cc1:EncodeLabel>
																								<cc1:EncodeLabel id="ItemWarehouseNameLabel" runat="server"
																									Text='<%# DataBinder.Eval(Container, "DataItem.[WH_SHORT_NAME]") %>'>
																								</cc1:EncodeLabel>
																							</span>
																							<div style="text-align: center;">
																								<span class="lbl_hit_adj">
																									<%-- ZZ_BN000239: ロット詳細 --%>
																									<cc1:StyledButton
																										id="LotDtilButtonItem" runat="server"
																										ClientFocusScript="defaultFunctionKeyItem"
																										Text="<%$ Resources:Web, ZZ_BN000239 %>"
																										CssClass="tiny"
																									/>
<%-- 
																									<asp:Image
																										id="IsRcptExistsItem" runat="server"
																										ImageUrl="img/SC_c1_rcpt_fin.gif"
																										visible='<%# DataBinder.Eval(Container, "DataItem.[IS_RCPT_EXECUTE]").ToString()=="1" %>'>
 --%>
																									<cc1:CustomImage
																										id="IsRcptExistsItem" runat="server" style="vertical-align: bottom;"
																										ImageUrl="<%$ Resources:Web, SC_IM000168 %>"
																										visible='<%# DataBinder.Eval(Container, "DataItem.[IS_RCPT_EXECUTE]").ToString()=="1" %>'>
																									</cc1:CustomImage>
																									<cc1:EncodeLabel id="RcptLineIdItem" runat="server" Visible="false"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[RCPT_LINE_ID]") %>'>
																									</cc1:EncodeLabel>
																								</span>
																							</div>
																						</ItemTemplate>
																						<EditItemTemplate>
																							<span class="lbl_hit_adj">
																								<cc1:CustomTextBox id="EditWhCodeText" runat="server"
																									Width="55px" MaxLength="5"
																									ImeMode="inactive"
																									NextControlID="EditPuQtText"
																									SearchInMyParent="True"
																									ClientFocusScript="defaultFunctionKeyBody"
																									ClientF05Script="openEditWarehouseWindow"
																									CheckOption="SingleByte"
																									AutoPostBack="true"
																									OnTextChanged="RowWhCodeText_TextChanged"
																									IsRequiredField="True"
																									Texttransform="UpperCase"
																									Text='<%# DataBinder.Eval(Container, "DataItem.[WH_CODE]") %>'>
																								</cc1:CustomTextBox>
																								<cc1:EncodeLabel id="EditWhShortNameLabel" runat="server"
																									Text='<%# DataBinder.Eval(Container, "DataItem.[WH_SHORT_NAME]") %>'>
																								</cc1:EncodeLabel>
																							</span>
																							<div style="text-align: center;">
																								<span class="lbl_hit_adj">
																									<%-- ZZ_BN000239: ロット詳細 --%>
																									<cc1:StyledButton
																										id="LotDtilButtonEdit" runat="server"
																										CommandName="LotDtil"
																										ClientFocusScript="defaultFunctionKeyBody"
																										Text="<%$ Resources:Web, ZZ_BN000239 %>"
																										CssClass="tiny"
																									/>
<%-- 
																									<asp:Image
																										id="IsRcptExistsEdit" runat="server"
																										ImageUrl="img/SC_c1_rcpt_fin.gif"
																										visible='<%# DataBinder.Eval(Container, "DataItem.[IS_RCPT_EXECUTE]").ToString()=="1" %>'>
 --%>
																									<cc1:CustomImage
																										id="IsRcptExistsEdit" runat="server" style="vertical-align: bottom;"
																										ImageUrl="<%$ Resources:Web, SC_IM000168 %>"
																										visible='<%# DataBinder.Eval(Container, "DataItem.[IS_RCPT_EXECUTE]").ToString()=="1" %>'>
																									</cc1:CustomImage>
																									<cc1:EncodeLabel id="RcptLineIdEdit" runat="server" Visible="false"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[RCPT_LINE_ID]") %>'>
																									</cc1:EncodeLabel>
																									<cc1:EncodeLabel id="PoLineIdEdit" runat="server" Visible="false"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[PO_LINE_ID]") %>'>
																									</cc1:EncodeLabel>
																								</span>
																							</div>
																						</EditItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn ItemStyle-Width="196px" Itemstyle-HorizontalAlign="right">
																						<ItemTemplate>
																							<cc1:EncodeLabel id="PuQtLabel" runat="server"
																								Text='<%# ControlFormat.ToSlipQt(DataBinder.Eval(Container.DataItem, "[PU_QT]").ToString(), this.QtDecimalDigit, ControlFormat.FormatType.Display) %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="ItemInitPuQt" runat="server"
																								Visible="false"
																								Text='<%# ControlFormat.ToSlipQt(DataBinder.Eval(Container.DataItem, "[INIT_PU_QT]").ToString(), this.QtDecimalDigit, ControlFormat.FormatType.Input) %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="UnitNameLabel" runat="server"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[UNIT_SHORT_NAME]") %>'>
																							</cc1:EncodeLabel>
																						</ItemTemplate>
																						<EditItemTemplate>
																							<cc1:NumberBox id="EditPuQtText" runat="server"
																								Width="118px"
																								NextControlID="EditUnitList"
																								IsRequiredField="True"
																								SearchInMyParent="True"
																								ClientFocusScript="defaultFunctionKeyBody"
																								OnTextChanged="EditPuQtText_TextChanged"
																								AutoPostBack="true"
																								Text='<%# ControlFormat.ToSlipQt(DataBinder.Eval(Container.DataItem, "[PU_QT]").ToString(), this.QtDecimalDigit, ControlFormat.FormatType.Input) %>'>
																							</cc1:NumberBox>
																							<cc1:EncodeLabel id="EditInitPuQt" runat="server"
																								Visible="false"
																								Text='<%# ControlFormat.ToSlipQt(DataBinder.Eval(Container.DataItem, "[INIT_PU_QT]").ToString(), this.QtDecimalDigit, ControlFormat.FormatType.Input) %>'>
																							</cc1:EncodeLabel>
																							<cc1:CustomDropDownList id="EditUnitList" runat="server"
																								Width="66px"
																								NextControlID="LotDtilButtonEdit"
																								SearchInMyParent="True"
																								ClientFocusScript="defaultFunctionKeyBody"
																								ClientChangeScript="unitCodeChange"
																								IsRequiredField="True"
																								OnSelectedIndexChanged="UnitList_SelectedIndexChanged"
																								AutoPostBack="True">
																							</cc1:CustomDropDownList>
																						</EditItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn ItemStyle-Width="156px" Itemstyle-HorizontalAlign="right">
																						<ItemTemplate>
																							<span class="lbl_hit_adj">
																								<cc1:EncodeLabel id="PuPriceLabel" runat="server"
																									Text='<%# ControlFormat.ToSlipPrice(DataBinder.Eval(Container, "DataItem.[PU_PRICE]").ToString(), this.PriceDecimalDigit, byte.Parse(this.curDigit), ControlFormat.FormatType.Display) %>'>
																								</cc1:EncodeLabel>
																								<span style="width: 14px;">
<%-- 
																									<cc1:EncodeLabel
																										id="PriceUndecidedLabel"
																										runat="server"
																										Text='<%# (DataBinder.Eval(Container, "DataItem.[PRICE_UNDECIDED_FLG]")).Equals("1") ? "仮" : "" %>'>
 --%>
																									<cc1:EncodeLabel
																										id="PriceUndecidedLabel"
																										runat="server"
																										Text='<%# (DataBinder.Eval(Container, "DataItem.[PRICE_UNDECIDED_FLG]")).Equals("1") ? Infocom.Allegro.MultiLanguage.Get("SC_CS000368") : "" %>'>
																									</cc1:EncodeLabel>
																								</span>
																							</span><br/>
																							<span class="lbl_hit_adj">
																								<cc1:EncodeLabel id="PuMoneyLabel" runat="server"
																									Text='<%# Common.FormatAmt(DataBinder.Eval(Container, "DataItem.[PU_MONEY]"), curDigit, false, "1") %>'>
																								</cc1:EncodeLabel>
																								<span style="width: 14px;">
<%-- 
																									<cc1:EncodeLabel id="CtaxCalcType" runat="server"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[CTAX_CALC_TYPE]").Equals("I") ? "＊" : "" %>'>
 --%>
																									<cc1:EncodeLabel id="CtaxCalcType" runat="server"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[CTAX_CALC_TYPE]").Equals("I") ? Infocom.Allegro.MultiLanguage.Get("SC_CS000054") : "" %>'>
																									</cc1:EncodeLabel>
																								</span>
																								<%-- 
																									img/SC_c1_ctax_off.gif
																									税
																								 --%>
																								<%-- ZZ_BN000241: 税 --%>
																								<cc1:StyledButton id="ItemTaxInfoButton" Runat="server"
																									ClientFocusScript="defaultFunctionKeyItem"
																									Text="<%$ Resources:Web, ZZ_BN000241 %>"
																									CssClass="tiny"
																								/>
																							</span>
																						</ItemTemplate>
																						<EditItemTemplate>
																							<span class="lbl_hit_adj">
																								<cc1:NumberBox id="EditPuPriceText" runat="server"
																									Width="120px" MaxLength="17"
																									NextControlID="EditUpdateButton"
																									SearchInMyParent="True"
																									IsRequiredField="True"
																									ClientFocusScript="defaultFunctionKeyBody"
																									AllowNegative="false"
																									Text='<%# ControlFormat.ToSlipPrice(DataBinder.Eval(Container, "DataItem.[PU_PRICE]").ToString(), this.PriceDecimalDigit, byte.Parse(this.curDigit), ControlFormat.FormatType.Input) %>'>
																								</cc1:NumberBox>
																								<cc1:NumberBox
																									id="EditInitPuPriceText" runat="server"
																									Visible="false"
																									Text='<%# ControlFormat.ToSlipPrice(DataBinder.Eval(Container, "DataItem.[INIT_PU_PRICE]").ToString(), this.PriceDecimalDigit, byte.Parse(this.curDigit), ControlFormat.FormatType.Input) %>'>
																								</cc1:NumberBox>
																								<cc1:EncodeLabel
																									id="EditPuPlanPriceLabel" runat="server"
																									Visible="false"
																									Text='<%# ControlFormat.ToSlipPrice(DataBinder.Eval(Container, "DataItem.[PU_PLAN_PRICE]").ToString(), this.PriceDecimalDigit, byte.Parse(this.curDigit), ControlFormat.FormatType.Input) %>'>
																								</cc1:EncodeLabel>
																								<span style="width: 18px;">
																									<cc1:CustomCheckBox id="EditPriceUndecidedCheck"
																										ClientFocusScript="defaultFunctionKeyBody"
																										SearchInMyParent="True"
																										runat="server" NextControlID="EditUpdateButton"
																										checked='<%# (DataBinder.Eval(Container, "DataItem.[PRICE_UNDECIDED_FLG]")).Equals("1") ? true : false %>'>
																									</cc1:CustomCheckBox>
																								</span>
																							</span><br/>
																							<span class="lbl_hit_adj">
																								<cc1:EncodeLabel id="PuMoneyLabel2" runat="server"
																									Text='<%# Common.FormatAmt(DataBinder.Eval(Container, "DataItem.[PU_MONEY]"), curDigit, false, "1") %>'>
																								</cc1:EncodeLabel>
																								<span style="width: 14px;">
<%-- 
																									<cc1:EncodeLabel id="CtaxCalcType2" runat="server"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[CTAX_CALC_TYPE]").Equals("I") ? "＊" : "" %>'>
 --%>
																									<cc1:EncodeLabel id="CtaxCalcType2" runat="server"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[CTAX_CALC_TYPE]").Equals("I") ? Infocom.Allegro.MultiLanguage.Get("SC_CS000054") : "" %>'>
																									</cc1:EncodeLabel>
																								</span>
																								<%-- 
																									img/SC_c1_ctax_off.gif
																									税
																								 --%>
																								<%-- ZZ_BN000241: 税 --%>
																								<cc1:StyledButton id="EditTaxInfoButton" Runat="server"
																									CommandName="TaxInfo"
																									ClientFocusScript="defaultFunctionKeyBody"
																									Text="<%$ Resources:Web, ZZ_BN000241 %>"
																									CssClass="tiny"
																								/>
																							</span>
																						</EditItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn ItemStyle-Width="127px" Itemstyle-HorizontalAlign="Center">
																						<ItemTemplate>
																							<%-- ZZ_BN000093: 挿入 --%>
																							<cc1:StyledButton id="ItemRegistButton" runat="server"
																								Text="<%$ Resources:Web, ZZ_BN000093 %>"
																								CssClass="small"
																								CommandName="Insert"
																								ClientFocusScript="defaultFunctionKeyItem"
																								enabled='<%# paramType != "View" %>'
																							/>
																							<%-- ZZ_BN000084: 削除 --%>
																							<cc1:StyledButton id="ItemDeleteButton" runat="server"
																								Text="<%$ Resources:Web, ZZ_BN000084 %>"
																								CssClass="small icon_delete"
																								CommandName="Delete"
																								ClientFocusScript="defaultFunctionKeyItem"
																								ClientClickScript="checkDeleteRow"
																								enabled='<%# paramType != "View" %>'
																							/>
																						</ItemTemplate>
																						<EditItemTemplate>
																							<cc1:EncodeLabel id="EditCtaxRate" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[CTAX_RATE]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditProdType" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[PROD_TYPE]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditDispControlType" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[DISP_CONTROL_TYPE]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditIncludeQt" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container.DataItem, "[INCLUDE_QT]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditAllowProdName" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[PROD_NAME_CORRECTION_FLG]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="ProdEditFlg" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[PROD_EDIT_FLG]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditIsRcptExecuteFlg" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[IS_RCPT_EXECUTE]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditStockAdminFlg" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[STOCK_ADMIN_FLG]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditLotAdminFlg" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[LOT_ADMIN_FLG]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditLotStockValuationFlg" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[LOT_STOCK_VALUATION_FLG]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditQtDecimalUseFlg" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[QT_DECIMAL_USE_FLG]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditDispFlg" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[DISC_FLG]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="RowState" runat="server"
																								Visible="false"
																								Text='<%# DataBinder.Eval(Container, "DataItem.[ROW_STATE]") %>'>
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="EditStdSellPrice" runat="server"
																								Visible="false"
																								Text='<%# ControlFormat.ToSlipPrice(DataBinder.Eval(Container, "DataItem.[STOCK_UNIT_STD_SELL_PRICE]").ToString(), this.PriceDecimalDigit, byte.Parse(curDigit), ControlFormat.FormatType.Input) %>'>
																							</cc1:EncodeLabel>
																							<%-- ZZ_BN000102: 更新 --%>
																							<cc1:StyledButton id="EditUpdateButton" runat="server"
																								Text="<%$ Resources:Web, ZZ_BN000102 %>"
																								CssClass="small icon_update"
																								CommandName="Update"
																								ClientFocusScript="defaultFunctionKeyBody"
																								ClientClickScript="gridUpdateCheck"
																							/>
																							<%-- ZZ_BN000093: 挿入 --%>
																							<cc1:StyledButton id="EditRegistButton" runat="server"
																								Text="<%$ Resources:Web, ZZ_BN000093 %>"
																								CssClass="small"
																								CommandName="Insert"
																								ClientFocusScript="defaultFunctionKeyBody"
																							/>
																							<%-- ZZ_BN000084: 削除 --%>
																							<cc1:StyledButton id="EditDeleteButton" runat="server"
																								Text="<%$ Resources:Web, ZZ_BN000084 %>"
																								CssClass="small icon_delete"
																								CommandName="Delete"
																								ClientFocusScript="defaultFunctionKeyBody"
																								ClientClickScript="checkDeleteRow"
																							/>
																							</td></tr>
																							<tr style="height: 30px;">
																								<td class="bd_item_val_bg" rowspan='<%# this.GetCustomControlCount() == 0 ? 1 : 2%>'></td>
																								<td class="bd_item_val_bg" colspan='<%# this.ProductSpecUseType == "0" ? 2 : 3 %>'>
																									<%-- 摘要 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001539 %>" />
																									<cc1:CustomTextBox id="EditRemarksCodeText" runat="server"
																										Width="31px" MaxLength="3"
																										ImeMode="inactive"
																										ClientFocusScript="defaultFunctionKeyBody"
																										ClientF05Script="openEditRemarksWindow"
																										NextControlID="EditRemarksText"
																										Texttransform="UpperCase"
																										SearchInMyParent="True"
																										AutoPostBack="true"
																										OnTextChanged="LineRemarksCodeText_TextChanged"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[LINE_REMARKS_CODE]") %>'>
																									</cc1:CustomTextBox>
																									<cc1:CustomTextBox id="EditRemarksText" runat="server"
																										Width="380px" MaxLength="30"
																										ImeMode="active"
																										ClientFocusScript="defaultFunctionKeyBody"
																										NextControlID="EditBookDeductionReasonCodeList"
																										SearchInMyParent="True"
																										Text='<%# DataBinder.Eval(Container, "DataItem.[LINE_REMARKS]") %>'>
																									</cc1:CustomTextBox>
																								</td>
																								<td class="bd_item_ttl_bg">
																									<%-- 帳簿控除理由 --%>
																									<cc1:EncodeLabel id="EditBookDeductionReason" runat="server" Text="<%$ Resources:Web, SC_CS006632 %>" />
																								</td>
																								<td class="bd_item_val_bg">
																									<cc1:CustomDropDownList id="EditBookDeductionReasonCodeList" runat="server"
																										Width="150px"
																										SearchInMyParent="True"
																										ClientFocusScript="defaultFunctionKeyBody"
																										NextControlID="EditCustomItemPanel">
																									</cc1:CustomDropDownList>
																								</td>
																								<td class="bd_item_val_bg" rowspan='<%# this.GetCustomControlCount() == 0 ? 1 : 2%>'>
																								</td></tr>
																								<tr style='<%# this.GetCustomControlCount() == 0 ? "display: none" : ""%>'>
																								<td class="bd_item_val_bg" colspan='<%# this.ProductSpecUseType == "0" ? 4 : 5 %>' style="padding: 0px; height: 0px;">
																									<%-- 明細汎用項目 --%>
																									<cc1:CustomItemPanel id="EditCustomItemPanel" runat="server" class="bd_table_bg grid_container" style="width: 100%; border-spacing: 0px; table-layout: fixed;"
																										MasterType="PROD"
																										DisplayType="InputEdit"
																										FunctionCode="SCMM05_PU"
																										NextControlID="EditUpdateButton"
																										ClientFocusScriptTextBox="defaultFunctionKeyBody"
																										ClientFocusScriptListBox="defaultFunctionKeyBody"
																										UseBasisDateFlg="true"
																										FirstBasisDate="PuDateText"
																										HeadClass="bd_item_val_bg"
																										BodyClass="bd_item_val_bg"
																										TitleWidth="13"
																										MaxCharacter="27"
																										UseAccordionFlg="true"
																										TitleName="<%$ Resources:Web, SC_CS006278 %>"
																									/>
																								</td></tr>
																						</EditItemTemplate>
																					</asp:TemplateColumn>
																				</Columns>
																			</cc1:ClickableDataGrid>
																			<cc1:ClickablePanel id="InpPanel" runat="server">
																				<table id="InputTable" runat="server" class="bd_table_bg grid_container" style="width: 1120px;">
																					<tr style="text-align: center;">
																						<td class="bd_item_val_bg" style="width: 39px;" rowspan='<%# this.GetCustomControlCount() == 0 ? 2 : 3%>'><span>&nbsp;</span></td>
																						<td class="bd_item_val_bg" style="text-align: left;">
																							<span class="lbl_hit_adj">
																								<cc1:CustomTextBox id="InpProdCodeText" runat="server"
																									Width='<%# this.ProductSpecUseType == "0" ? System.Web.UI.WebControls.Unit.Pixel(361) : System.Web.UI.WebControls.Unit.Pixel(288)%>'
																									MaxLength="20"
																									ImeMode="inactive"
																									Texttransform="UpperCase"
																									ClientF05Script="openInpProdWindow"
																									ClientFocusScript="defaultFunctionKeyRegist"
																									NextControlID="InpProdNameText"
																									CheckOption="SingleByte"
																									AutoPostBack="true"
																									IsRequiredField="True"
																									SearchInMyParent="True">
																								</cc1:CustomTextBox>
																							</span><br/>
																							<span class="lbl_hit_adj">
																								<cc1:CustomTextBox id="InpProdNameText" runat="server"
																									Width='<%# this.ProductSpecUseType == "0" ? System.Web.UI.WebControls.Unit.Pixel(361) : System.Web.UI.WebControls.Unit.Pixel(288)%>'
																									MaxLength="30"
																									ImeMode="active"
																									ClientFocusScript="defaultFunctionKeyRegist"
																									NextControlID='<%# this.ProductSpecUseType == "0" ? "InpWhCodeText" : "InpProdSpec1List"%>'
																									IsRequiredField="True"
																									SearchInMyParent="True">
																								</cc1:CustomTextBox>
																							</span>
																							<cc1:EncodeLabel id="InpProdShortNameLabel" runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																						</td>
																						<td class="bd_item_val_bg" style="width: 72px;">
																							<span class='<%# this.ProductSpecUseType == "2" ? "lbl_hit_adj" : "" %>' runat="Server" id="Span7">
																								<cc1:CustomDropDownList id="InpProdSpec1List" runat="server"
																									Width="66px"
																									ClientFocusScript="defaultFunctionKeyRegist"
																									ClientChangeScript="insSpec1CodeChange"
																									NextControlID='<%# this.ProductSpecUseType == "2" ? "InpProdSpec2List" : "InpWhCodeText"%>'
																									IsRequiredField="True"
																									SearchInMyParent="True"
																									AutoPostBack="True">
																								</cc1:CustomDropDownList>
																							</span><br/>
																							<span class='<%# this.ProductSpecUseType == "2" ? "lbl_hit_adj" : "" %>' runat="Server" id="Span8">
																								<cc1:CustomDropDownList id="InpProdSpec2List" runat="server"
																									Width="66px"
																									ClientFocusScript="defaultFunctionKeyRegist"
																									ClientChangeScript="insSpec2CodeChange"
																									NextControlID="InpWhCodeText"
																									IsRequiredField="True"
																									SearchInMyParent="True"
																									AutoPostBack="True">
																								</cc1:CustomDropDownList>
																							</span>
																						</td>
																						<td class="bd_item_val_bg" style="width: 206px;">
																							<div style="text-align:left;">
																								<span class="lbl_hit_adj">
																									<cc1:CustomTextBox id="InpWhCodeText" runat="server"
																										Width="55px" MaxLength="5"
																										ImeMode="inactive"
																										Texttransform="UpperCase"
																										ClientF05Script="openInpWarehouseWindow"
																										ClientFocusScript="defaultFunctionKeyRegist"
																										NextControlID="InpPuQtText"
																										CheckOption="SingleByte"
																										IsRequiredField="True"
																										AutoPostBack="true">
																									</cc1:CustomTextBox>
																									<cc1:EncodeLabel id="InpWhShortNameLabel" runat="server">
																									</cc1:EncodeLabel>
																								</span>
																							</div>
																							<span class="lbl_hit_adj" style="text-align: center;">
																								<%-- ZZ_BN000239: ロット詳細 --%>
																								<cc1:StyledButton
																									id="InpLotDtilButton" runat="server"
																									CommandName="LotDtil"
																									ClientFocusScript="defaultFunctionKeyRegist"
																									ClientClickScript="__openLotDetailWindowInsRow"
																									Text="<%$ Resources:Web, ZZ_BN000239 %>"
																									CssClass="tiny"
																								/>
																							</span>
																						</td>
																						<td class="bd_item_val_bg" style="width: 196px; text-align: right;">
																							<cc1:NumberBox id="InpPuQtText" runat="server"
																								Width="118px"
																								ClientFocusScript="defaultFunctionKeyRegist"
																								IsRequiredField="True"
																								AutoPostBack="true"
																								NextControlID="InpUnitList">
																							</cc1:NumberBox>
																							<cc1:CustomDropDownList id="InpUnitList" runat="server"
																								Width="66px"
																								ClientFocusScript="defaultFunctionKeyRegist"
																								ClientChangeScript="insUnitCodeChange"
																								NextControlID="InpLotDtilButton"
																								SearchInMyParent="True"
																								AutoPostBack="True">
																							</cc1:CustomDropDownList>
																						</td>
																						<td class="bd_item_val_bg" style="width: 156px; text-align: right;">
																							<span class="lbl_hit_adj">
																								<cc1:Numberbox
																									id="InpInitPuPriceText" runat="server"
																									Visible="false" >
																								</cc1:Numberbox>
																								<cc1:EncodeLabel
																									id="InpPuPlanPriceLabel" runat="server"
																									Visible="false" >
																								</cc1:EncodeLabel >
																								<cc1:NumberBox id="InpPuPriceText" runat="server"
																									Width="120px"
																									ClientFocusScript="defaultFunctionKeyRegist"
																									NextControlID="RegistButton"
																									IsRequiredField="True"
																									AllowNegative="false">
																								</cc1:NumberBox>
																								<span style="width: 18px;">
																									<cc1:CustomCheckBox id="InpPriceUndecidedFlgCheck"
																										ClientFocusScript="defaultFunctionKeyRegist"
																										NextControlID="RegistButton" runat="server">
																									</cc1:CustomCheckBox>
																								</span>
																							</span><br/>
																							<span class="lbl_hit_adj">
																								<cc1:EncodeLabel id="InpPuMoneyLabel" runat="server">
																								</cc1:EncodeLabel>
																								<span style="width: 14px;">
																									<cc1:EncodeLabel id="InpCtaxCalcTypeLabel" runat="server"
																										Visible="false">
																									</cc1:EncodeLabel>
																								</span>
																								<%--
																									img/SC_c1_ctax_off.gif
																									税
																								 --%>
																								<%-- ZZ_BN000241: 税 --%>
																								<cc1:StyledButton id="InpTaxInfoButton" runat="server"
																									ClientFocusScript="defaultFunctionKeyRegist"
																									ClientClickScript="__openCtaxSearchWindowInputRow"
																									Text="<%$ Resources:Web, ZZ_BN000241 %>"
																									CssClass="tiny"
																								/>
																							</span>
																						</td>
																						<td class="bd_item_val_bg" style="width: 127px" rowspan='<%# this.GetCustomControlCount() == 0 ? 2 : 3%>'>
																							<cc1:EncodeLabel id="InpIsRcptExecuteFlg" runat="server"
																								Text="0"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpStockAdminFlg"  runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpLotAdminFlg" runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpLotStockValuationFlg" runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpQtDecimalUseFlg"  runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpCtaxRate" runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpProdType" runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpDispControlType" runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpIncludeQt" runat="server"
																								Text="0"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpAllowProdName" runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpDiscFlg" runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel id="InpStdSellPrice" runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<cc1:EncodeLabel
																								id="InpProdEditFlg" runat="server"
																								Visible="false">
																							</cc1:EncodeLabel>
																							<%-- ZZ_BN000097: 登録 --%>
																							<cc1:StyledButton id="RegistButton" runat="server"
																								ClientFocusScript="defaultFunctionKeyRegist"
																								ClientClickScript="checkValueRegist"
																								Text="<%$ Resources:Web, ZZ_BN000097 %>"
																								CssClass="small icon_check"
																							/>
																						</td>
																					</tr>
																					<tr>
																						<td class="bd_item_val_bg" colspan='<%# this.ProductSpecUseType == "0" ? 2 : 3 %>'>
																							<%-- 摘要 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001539 %>" />
																							<cc1:CustomTextBox id="InpRemarksCodeText" runat="server"
																								Width="31px" MaxLength="3"
																								ImeMode="inactive"
																								ClientFocusScript="defaultFunctionKeyRegist"
																								ClientF05Script="openInpRemarksWindow"
																								Texttransform="UpperCase"
																								NextControlID="InpRemarksText"
																								AutoPostBack="true">
																							</cc1:CustomTextBox>
																							<cc1:CustomTextBox id="InpRemarksText" runat="server"
																								Width="380px" MaxLength="30"
																								ImeMode="active"
																								ClientFocusScript="defaultFunctionKeyRegist"
																								NextControlID="InpBookDeductionReasonCodeList">
																							</cc1:CustomTextBox>
																						</td>
																						<td class="bd_item_ttl_bg">
																							<%-- 帳簿控除理由 --%>
																							<cc1:EncodeLabel id="InpBookDeductionReason" runat="server" Text="<%$ Resources:Web, SC_CS006632 %>" />
																						</td>
																						<td class="bd_item_val_bg">
																							<cc1:CustomDropDownList id="InpBookDeductionReasonCodeList" runat="server"
																								Width="150px"
																								ClientFocusScript="defaultFunctionKeyRegist"
																								NextControlID="InpCustomItemPanel">
																							</cc1:CustomDropDownList>
																						</td>
																					</tr>
																					<tr style='<%# this.GetCustomControlCount() == 0 ? "display: none" : ""%>'>
																						<td class="bd_item_val_bg" colspan='<%# this.ProductSpecUseType == "0" ? 4 : 5 %>' style="padding: 0px; height: 0px;">
																							<%-- 明細汎用項目 --%>
																							<cc1:CustomItemPanel id="InpCustomItemPanel" runat="server" class="bd_table_bg grid_container" style="width:100%; border-spacing: 0px; table-layout: fixed;"
																								MasterType="PROD"
																								DisplayType="InputNew"
																								FunctionCode="SCMM05_PU"
																								NextControlID="RegistButton"
																								ClientFocusScriptTextBox="defaultFunctionKeyRegist"
																								ClientFocusScriptListBox="defaultFunctionKeyRegist"
																								UseBasisDateFlg="true"
																								FirstBasisDate="PuDateText"
																								HeadClass="bd_item_val_bg"
																								BodyClass="bd_item_val_bg"
																								TitleWidth="13"
																								MaxCharacter="27"
																								UseAccordionFlg="true"
																								TitleName="<%$ Resources:Web, SC_CS006278 %>"
																							/>
																					</td></tr>
																				</table>
																			</cc1:ClickablePanel>
																			<table class="bd_table_bg grid_container" style="width: 1120px;">
																				<tr>
																					<td class="bd_item_ttl_bg" style="width: 10%;"><%-- 仕入金額合計 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000776 %>" /></td>
																					<td class="bd_item_val_bg" style="width: 14%; text-align: right;">
																						<cc1:EncodeLabel id="DtilAmtTtlLabel" runat="server"></cc1:EncodeLabel><br />
																						<cc1:EncodeLabel id="ConvertDtilAmtTtlLabel" runat="server"></cc1:EncodeLabel>
																					</td>
																					<td class="bd_item_ttl_bg" style="width: 10%;"><%-- 課税対象額計 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS000389 %>" /></td>
																					<td class="bd_item_val_bg" style="width: 14%; text-align: right;">
																						<cc1:EncodeLabel id="EtaxDtilAmtTtlLabel" runat="server"></cc1:EncodeLabel><br />
																						<cc1:EncodeLabel id="ConvertEtaxDtilAmtTtlLabel" runat="server" ></cc1:EncodeLabel>
																					</td>
																					<td class="bd_item_ttl_bg" style="width: 15%;"><%-- 消費税合計 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001208 %>" /></td>
																					<td class="bd_item_val_bg" style="width: 14%; text-align: right;">
																						<cc1:EncodeLabel id="EtaxAmtTtlLabel" runat="server"></cc1:EncodeLabel><br />
																						<cc1:EncodeLabel id="ConvertEtaxAmtTtlLabel" runat="server"></cc1:EncodeLabel>
																					</td>
																					<td class="bd_item_ttl_bg" style="width: 10%;"><%-- 総合計 --%><cc1:EncodeLabel runat="server" Text="<%$ Resources:Web, SC_CS001410 %>" /></td>
																					<td class="bd_item_val_bg" style="width: 13%; text-align: right;">
																						<cc1:EncodeLabel id="GrandTtlLabel" runat="server"></cc1:EncodeLabel><br />
																						<cc1:EncodeLabel id="ConvertGrandTtlLabel" runat="server"></cc1:EncodeLabel>
																					</td>
																				</tr>
																			</table>
																		</td>
																	</tr>
																</table>
															</div>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td style="height: 5px;"></td>
							</tr>
							<tr>
								<td class="btn_list_container">
									<%-- ZZ_BN000099: 経路変更 --%>
									<cc1:StyledButton id="RouteChangeButton" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientClickScript="openApprovalChangeWindow"
										Text="<%$ Resources:Web, ZZ_BN000099 %>"
										CssClass="normal"
										DisregardsMode="True"
									/>
									<%-- 添付資料 --%>
									<cc1:StyledButton
										ID="AttachmentFileButton" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientClickScript="validateAttachmentFileButtonClick"
										DisregardsMode="True"
									/>
									<%-- ZZ_BN000037: 保留解除 --%>
									<cc1:StyledButton
										id="HoldReleaseButton" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader" ClientClickScript="callHoldRelease"
										Text="<%$ Resources:Web, ZZ_BN000037 %>"
										CssClass="normal"
										CommandName="HoldRelease"
									/>
									<%-- ZZ_BN000067: 更新 --%>
									<cc1:StyledButton id="UpdateButton" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientClickScript="checkValueUpdate"
										Text="<%$ Resources:Web, ZZ_BN000067 %>"
										CssClass="normal"
									/>
									<%-- ZZ_BN000016: キャンセル --%>
									<cc1:StyledButton id="CancelButton" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientClickScript="checkCancel"
										Text="<%$ Resources:Web, ZZ_BN000016 %>"
										CssClass="normal"
									/>
									<%-- ZZ_BN000026: 削除 --%>
									<cc1:StyledButton id="DeleteButton" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientClickScript="checkDelete"
										Text="<%$ Resources:Web, ZZ_BN000026 %>"
										CssClass="normal"
									/>
									<%-- ZZ_BN000139: 諸掛閲覧 --%>
									<cc1:StyledButton id="ChargeBrowseButton" runat="server"
										clientfocusscript="defaultFunctionKeyHeader"
										clientclickscript="clickChargeBrowseButton"
										Text="<%$ Resources:Web, ZZ_BN000139 %>"
										CssClass="normal"
										disregardsmode="True"
									/>
									<%-- ZZ_BN000207: 伝票印刷 --%>
									<cc1:StyledButton id="PuSlipButton" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientClickScript="showOrderSlipP"
										Text="<%$ Resources:Web, ZZ_BN000207 %>"
										CssClass="normal icon_printer"
										DisregardsMode="True"
									/>
									<%-- ZZ_BN000019: 閉じる --%>
									<cc1:StyledButton id="CloseButton" runat="server"
										ClientFocusScript="defaultFunctionKeyHeader"
										ClientClickScript="checkDirty"
										Text="<%$ Resources:Web, ZZ_BN000019 %>"
										CssClass="normal"
										DisregardsMode="True"
									/>
								</td>
							</tr>
						</table>
						<!-- 編集行 -->
						<input id="editRowProdTypeHidden"		type="hidden" runat="server" />
						<input id="editRowDispTypeHidden"		type="hidden" runat="server" />
						<input id="editRowPuLineIdHidden"		type="hidden" runat="server" />
						<input id="editRowInitPuQtHidden"		type="hidden" runat="server" />
						<input id="editRowInitPuPriceHidden"	type="hidden" runat="server" />
						<input id="editRowStockAdminFlgHidden"	type="hidden" runat="server" />
						<input id="editRowRcptLineIdHidden"		type="hidden" runat="server" />
						<input id="inputRowProdTypeHidden"		type="hidden" runat="server" />
						<input id="inputRowDispTypeHidden"		type="hidden" runat="server" />
						<input id="inputRowInitPuQtTextHidden"	type="hidden" runat="server" />
						<input id="inputRowInitPuPriceHidden"	type="hidden" runat="server" />
						<input id="inputRowStockAdminFlgHidden"	type="hidden" runat="server" />

						<input id="ProdNameHdn" type="hidden" runat="server" />
						<input id="ProdShortNameHdn" type="hidden" runat="server" />
						<input id="StockAdminFlgHdn" type="hidden" runat="server" />
						<input id="LotAdminFlgHdn" type="hidden" runat="server" />
						<input id="LotStockValuationFlg" type="hidden" runat="server" />
						<input id="QtDecimalUseFlgHdn" type="hidden" runat="server" />
						<input id="CtaxCalcTypeHdn" type="hidden" runat="server" />
						<input id="CtaxTypeCodeHdn" type="hidden" runat="server" />
						<input id="CtaxRateCodeHdn" type="hidden" runat="server" />
						<input id="IncludeQtHdn" type="hidden" runat="server" />
						<input id="ProdNameCorrectAllowFlgHdn" type="hidden" runat="server" />
						<input id="DiscFlgHdn" type="hidden" runat="server" />
						<input id="StdSellPriceHdn" type="hidden" runat="server" />

						<input id="MultiLotFlgHdn" type="hidden" runat="server" />
						<input id="ProdEditFlgHdn" type="hidden" runat="server" />
						<input id="InitPuPriceHdn" type="hidden" runat="server" />
						<input id="PriceUpdateFlgHdn" type="hidden" runat="server" />
						<input id="TaxInfoChgFlgHdn" type="hidden" runat="server" />

						<input id="deleteDate" type="hidden" runat="server" />
						<input id="retryHidden" type="hidden" runat="server" />
					</td>
				</tr>
				<!--#include virtual="inc/CM_footer.inc" -->
			</table>
			<input id="clickHidden"       type="hidden" runat="server" />
			<input id="printListHidden"   type="hidden" runat="server" />
			<input id="reportMessHidden"  type="hidden" runat="server" />
			<input type="hidden" id="AdminItem1Hidden" runat="server" name="AdminItem1Hidden" />
			<input type="hidden" id="AdminItem2Hidden" runat="server" name="AdminItem2Hidden" />
			<input type="hidden" id="AdminItem3Hidden" runat="server" name="AdminItem3Hidden" />
			<input id="printHidden"   type="hidden" runat="server" name="printHidden" />
			<input id="UpdateFlg" type="hidden" runat="server" name="UpdateFlg" />
			<input id="cancelByScriptHidden" type="hidden" />
		</form>
	</body>
</html>
