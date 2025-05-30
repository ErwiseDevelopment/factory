﻿/* START OF FILE - ..\Sources\Preview.src.js - */
// Initialization for Query object preview tab
function IsQueryObjectPreview() {
	return window.external != undefined && window.external.SendText != undefined;
}

function IsDashboardEdit() {
	return typeof UCDashboardForEditor !== 'undefined';
}

function UpdateQueryObjectPreview(postDataJSON) {

	function SetPreviewData(qViewer, postDataJSON) {
		var postData = JSON.parse(postDataJSON);
		var keys = Object.keys(postData);
		for (var i = 0; i < keys.length; i++) {
			var key = keys[i];
			qViewer[key] = postData[key];
		}
	}

	var userControlId = Object.keys(qv.collection)[0];
	var qViewer = qv.collection[userControlId];
	SetPreviewData(qViewer, postDataJSON);
	qViewer.realShow();

}
/* END OF FILE - ..\Sources\Preview.src.js - */
/* START OF FILE - ..\Sources\Util.src.js - */
var HIGHCHARTS_COLOR_PREFIX = "highcharts-color-";
var HIGHCHARTS_MAX_COLORS = 36;
var HIGHCHARTS_CUSTOM_COLOR = [];

var qv = { collection: {}, fadeTimeouts: {} }

var QueryViewerVisible = { Always: "Always", Yes: "Yes", No: "No", Never: "Never" };
var QueryViewerElementType = { Axis: "Axis", Datum: "Datum" };
var QueryViewerAxisType = { Rows: "Rows", Columns: "Columns", Pages: "Pages" };
var QueryViewerFilterType = { ShowAllValues: "ShowAllValues", HideAllValues: "HideAllValues", ShowSomeValues: "ShowSomeValues" };
var QueryViewerAxisOrderType = { None: "None", Ascending: "Ascending", Descending: "Descending", Custom: "Custom" };
var QueryViewerExpandCollapseType = { ExpandAllValues: "ExpandAllValues", CollapseAllValues: "CollapseAllValues", ExpandSomeValues: "ExpandSomeValues" };
var QueryViewerDataType = { Integer: "integer", Real: "real", Character: "character", Boolean: "boolean", Date: "date", DateTime: "datetime", GUID: "guid", GeoPoint: "geopoint" };
var QueryViewerAggregationType = { Sum: "Sum", Average: "Average", Count: "Count", Max: "Max", Min: "Min" };
var QueryViewerOutputType = { Card: "Card", Chart: "Chart", PivotTable: "PivotTable", Table: "Table", Map: "Map", Default: "Default" };
var QueryViewerMapType = { Choropleth: "Choropleth", Bubble: "Bubble" };
var QueryViewerRegion = { Country: "Country", Continent: "Continent", World: "World" };
var QueryViewerContinent = { SouthAmerica: "SouthAmerica", NorthAmerica: "NorthAmerica", Africa: "Africa", Asia: "Asia", Europe: "Europe", Oceania: "Oceania", Antarctica: "Antarctica" };
var QueryViewerCountry = {
	AF: "AF", AL: "AL", DZ: "DZ", AD: "AD", AO: "AO", AI: "AI", AG: "AG", AR: "AR", AM: "AM", AU: "AU", AT: "AT", AZ: "AZ", BH: "BH", BD: "BD", BB: "BB", BY: "BY", BE: "BE", BZ: "BZ", BJ: "BJ", BM: "BM", BT: "BT", BO: "BO",
	BA: "BA", BW: "BW", BR: "BR", VG: "VG", BN: "BN", BG: "BG", BF: "BF", BI: "BI", KH: "KH", CM: "CM", CA: "CA", CV: "CV", CF: "CF", TD: "TD", CL: "CL", CN: "CN", CO: "CO", KM: "KM", CK: "CK", CR: "CR", HR: "HR", CU: "CU",
	CY: "CY", CZ: "CZ", CD: "CD", DK: "DK", DJ: "DJ", DM: "DM", DO: "DO", TL: "TL", EC: "EC", EG: "EG", SV: "SV", GQ: "GQ", ER: "ER", EE: "EE", SZ: "SZ", ET: "ET", FO: "FO", FJ: "FJ", FI: "FI", FR: "FR", GA: "GA", GM: "GM",
	GE: "GE", DE: "DE", GH: "GH", GR: "GR", GL: "GL", GD: "GD", GT: "GT", GN: "GN", GW: "GW", GY: "GY", HT: "HT", HN: "HN", HU: "HU", IS: "IS", IN: "IN", ID: "ID", IR: "IR", IQ: "IQ", IE: "IE", IL: "IL", IT: "IT", CI: "CI",
	JM: "JM", JP: "JP", JO: "JO", KZ: "KZ", KE: "KE", KI: "KI", XK: "XK", KW: "KW", KG: "KG", LA: "LA", LV: "LV", LB: "LB", LS: "LS", LR: "LR", LY: "LY", LI: "LI", LT: "LT", LU: "LU", MG: "MG", MW: "MW", MY: "MY", MV: "MV",
	ML: "ML", MT: "MT", MH: "MH", MR: "MR", MU: "MU", MX: "MX", FM: "FM", MD: "MD", MC: "MC", MN: "MN", ME: "ME", MA: "MA", MZ: "MZ", MM: "MM", NA: "NA", NR: "NR", NP: "NP", NL: "NL", NZ: "NZ", NI: "NI", NE: "NE", NG: "NG",
	KP: "KP", MK: "MK", NO: "NO", OM: "OM", PK: "PK", PW: "PW", PA: "PA", PS: "PS", PG: "PG", PY: "PY", PE: "PE", PH: "PH", PL: "PL", PT: "PT", PR: "PR", QA: "QA", CG: "CG", RO: "RO", RU: "RU", RW: "RW", KN: "KN", LC: "LC",
	VC: "VC", WS: "WS", SM: "SM", ST: "ST", SA: "SA", SN: "SN", RS: "RS", SC: "SC", SL: "SL", SG: "SG", SK: "SK", SI: "SI", SB: "SB", SO: "SO", ZA: "ZA", KR: "KR", SS: "SS", ES: "ES", LK: "LK", SD: "SD", SR: "SR", SE: "SE",
	CH: "CH", SY: "SY", TW: "TW", TJ: "TJ", TZ: "TZ", TH: "TH", BS: "BS", TG: "TG", TK: "TK", TO: "TO", TT: "TT", TN: "TN", TR: "TR", TM: "TM", TV: "TV", UG: "UG", UA: "UA", AE: "AE", GB: "GB", US: "US", UY: "UY", UZ: "UZ",
	VU: "VU", VA: "VA", VE: "VE", VN: "VN", EH: "EH", YE: "YE", ZM: "ZM", ZW: "ZW"
};
var QueryViewerMapLibrary = { Highcharts: "Highcharts", ECharts: "ECharts" };

var QueryViewerChartType = { Column: "Column", Column3D: "Column3D", StackedColumn: "StackedColumn", StackedColumn3D: "StackedColumn3D", StackedColumn100: "StackedColumn100", Bar: "Bar", StackedBar: "StackedBar", StackedBar100: "StackedBar100", Area: "Area", StackedArea: "StackedArea", StackedArea100: "StackedArea100", SmoothArea: "SmoothArea", StepArea: "StepArea", Line: "Line", StackedLine: "StackedLine", StackedLine100: "StackedLine100", SmoothLine: "SmoothLine", StepLine: "StepLine", Pie: "Pie", Pie3D: "Pie3D", Doughnut: "Doughnut", Doughnut3D: "Doughnut3D", LinearGauge: "LinearGauge", CircularGauge: "CircularGauge", Radar: "Radar", FilledRadar: "FilledRadar", PolarArea: "PolarArea", Funnel: "Funnel", Pyramid: "Pyramid", ColumnLine: "ColumnLine", Column3DLine: "Column3DLine", Timeline: "Timeline", SmoothTimeline: "SmoothTimeline", StepTimeline: "StepTimeline", Sparkline: "Sparkline" };
var QueryViewerConditionOperator = { Equal: "EQ", LessThan: "LT", GreaterThan: "GT", LessOrEqual: "LE", GreaterOrEqual: "GE", NotEqual: "NE", Interval: "IN" };
var QueryViewerConditionOperatorSymbol = { Equal: "=", LessThan: "<", GreaterThan: ">", LessOrEqual: "≤", GreaterOrEqual: "≥", NotEqual: "<>", Interval: "-" };
var QueryViewerOrientation = { Horizontal: "Horizontal", Vertical: "Vertical" };
var QueryViewerPlotSeries = { InTheSameChart: "InTheSameChart", InSeparateCharts: "InSeparateCharts" };
var QueryViewerShowDataAs = { Values: "Values", Percentages: "Percentages", ValuesAndPercentages: "ValuesAndPercentages" };
var QueryViewerSubtotals = { Yes: "Yes", Hidden: "Hidden", No: "No" };
var QueryViewerTrendPeriod = { SinceTheBeginning: "SinceTheBeginning", LastYear: "LastYear", LastSemester: "LastSemester", LastQuarter: "LastQuarter", LastMonth: "LastMonth", LastWeek: "LastWeek", LastDay: "LastDay", LastHour: "LastHour", LastMinute: "LastMinute", LastSecond: "LastSecond" };
var QueryViewerXAxisLabels = { Horizontally: "Horizontally", Rotated30: "Rotated30", Rotated45: "Rotated45", Rotated60: "Rotated60", Vertically: "Vertically" };
var QueryViewerAutoresizeType = { Both: "Both", Vertical: "Vertical", Horizontal: "Horizontal" };
var QueryViewerTranslationType = { NoTranslation: "None", Static: "Static", RunTime: "RunTime" };
var QueryViewerParentPanel = { Default: "Default", QueryPreview: "QueryPreview", DashboardEditor: "DashboardEditor", MobileWrapper: "MobileWrapper"};

qv.util = {

	color: {

		getHtmlColor: function (color) {
			var htmlColor;
			if ((typeof (color) == "string") || (typeof (color) == "number")) {
				if (gx.color.toHex) {
					if (color == -1) // -1 = null color
						htmlColor = "";
					else htmlColor = "#" + gx.color.toHex(color); // GeneXus X Ev. 1
				} else htmlColor = "#" + gxToHex(color) // GeneXus X
			} else htmlColor = (color == undefined ? "#000000" : color.Html);
			return htmlColor;
		},

		parseCSSColor: function (color) {
			if (color.substring(0, 3) == "rgb") {
				var values = color.replace("rgb", "").replace("(", "").replace(")", "").split(",");
				var numColor = gx.color.rgb(parseInt(values[0]), parseInt(values[1]), parseInt(values[2]));
				return this.getHtmlColor(numColor);
			} else return color;
		},

		convertValueToColor: function (value) {
			var valueColor;
			if (value.indexOf("#") == -1)
				valueColor = "#" + value;
			else
				valueColor = value;
			var vColor = valueColor.substring(1, valueColor.length);
			while (vColor.length < 6)
				vColor = "0" + vColor;
			return "#" + vColor;
		},

		IsHexaColor: function (colorStr) {
			return (colorStr.length === 6 && !isNaN(parseInt(colorStr, 16)));
		},

		lightenDarkenColor: function (col, amt) {
			var usePound = false;
			if (col[0] == "#") {
				col = col.slice(1);
				usePound = true;
			}
			var num = parseInt(col, 16);
			var r = (num >> 16) + amt;
			if (r > 255)
				r = 255;
			else if (r < 0)
				r = 0;
			var b = ((num >> 8) & 0x00FF) + amt;
			if (b > 255)
				b = 255;
			else if (b < 0)
				b = 0;
			var g = (num & 0x0000FF) + amt;
			if (g > 255)
				g = 255;
			else if (g < 0)
				g = 0;
			return (usePound ? "#" : "") + (g | (b << 8) | (r << 16)).toString(16);
		},
		
		standardize_color: function(str){
			var ctx = document.createElement('canvas').getContext('2d');
			ctx.fillStyle = str;
			return ctx.fillStyle;
		},
		
		resolveColor: function(color, opacity) {
			if (!qv.util.startsWith(color, "#"))
				color = qv.util.color.standardize_color(color);
			if (!opacity || opacity == "1")
				return color;
			else {
				var bigint = parseInt(color.substring(1), 16);
				var r = (bigint >> 16) & 255;
				var g = (bigint >> 8) & 255;
				var b = bigint & 255;
				return 'rgba(' + r + ',' + g + ',' + b + ',' + opacity + ')';
			}
		}

	},

	css: (function () {

		var CSSStyles = {}

		function getCSSStyle(className) {
			if (CSSStyles[className] != undefined)
				return CSSStyles[className];
			else {
				styleObj = loadCSSStyle(className);
				if (styleObj != undefined) {
					styleTransformed = transformCSSStyle(styleObj)
					CSSStyles[className] = styleTransformed;
					return styleTransformed;
				} else return "";
			}
		}

		function loadCSSStyle(className) {
			var css;
			var cssName = gx.theme + ".css";
			var cssFound = false;
			var styleObj;
			for (var i = 0; i < document.styleSheets.length; i++)
				if (document.styleSheets[i].href != null && document.styleSheets[i].href.indexOf(cssName) >= 0) {
					cssFound = true;
					css = document.styleSheets[i];
					break;
				}
			if (cssFound) if (css.cssRules) crossRules = css.cssRules;
			else if (css.rules) crossRules = css.rules;
			var lengthRuleSelected = Number.MAX_SAFE_INTEGER;
			for (var i = 0; i < crossRules.length; i++) {
				var rule = crossRules[i];
				if (rule.selectorText != undefined)
					if (rule.selectorText.toLowerCase().indexOf("." + className.toLowerCase()) == 0 && rule.selectorText.length < lengthRuleSelected) {
						styleObj = rule.style;
						lengthRuleSelected = rule.selectorText.length;
					}
			}
			return styleObj;
		}

		function transformCSSStyle(styleObj) {
			var strAux = "";
			if (styleObj.color != "") strAux += (strAux == "" ? "" : ";") + "color:" + qv.util.color.parseCSSColor(styleObj.color);
			if (styleObj.backgroundColor != "") strAux += (strAux == "" ? "" : ";") + "backgroundColor:" + qv.util.color.parseCSSColor(styleObj.backgroundColor);
			if (styleObj.borderStyle != "") strAux += (strAux == "" ? "" : ";") + "borderStyle:" + styleObj.borderStyle;
			if (styleObj.borderWidth != "") strAux += (strAux == "" ? "" : ";") + "borderThickness:" + styleObj.borderWidth.replace("pt", "").replace("px", "");
			if (styleObj.borderColor != "") strAux += (strAux == "" ? "" : ";") + "borderColor:" + qv.util.color.parseCSSColor(styleObj.borderColor);
			//if (styleObj.paddingLeft != "")        strAux += (strAux == "" ? "" : ";") + "paddingLeft:"      + styleObj.paddingLeft.replace("pt", "").replace("px", "");
			//if (styleObj.paddingRight != "")       strAux += (strAux == "" ? "" : ";") + "paddingRight:"     + styleObj.paddingRight.replace("pt", "").replace("px", "");
			//if (styleObj.paddingTop != "")         strAux += (strAux == "" ? "" : ";") + "paddingTop:"       + styleObj.paddingTop.replace("pt", "").replace("px", "");
			//if (styleObj.paddingBottom != "")      strAux += (strAux == "" ? "" : ";") + "paddingBottom:"    + styleObj.paddingBottom.replace("pt", "").replace("px", "");
			if (styleObj.fontFamily != "") strAux += (strAux == "" ? "" : ";") + "fontFamily:" + styleObj.fontFamily.replace(/"/g, "").replace(/'/g, "");
			if (styleObj.fontSize != "") strAux += (strAux == "" ? "" : ";") + "fontSize:" + styleObj.fontSize.replace("pt", "").replace("px", "");
			if (styleObj.fontWeight != "") strAux += (strAux == "" ? "" : ";") + "fontWeight:" + styleObj.fontWeight;
			if (styleObj.fontStyle != "") strAux += (strAux == "" ? "" : ";") + "fontStyle:" + styleObj.fontStyle;
			if (styleObj.textDecoration != "") strAux += (strAux == "" ? "" : ";") + "textDecoration:" + styleObj.textDecoration;
			//if (styleObj.textAlign != "")          strAux += (strAux == "" ? "" : ";") + "textAlign:"        + styleObj.textAlign;

			// Faltan
			//    backgroundAlpha   = "1"     // 0 .. 1
			//    cornerRadius    = "0"       // 0 .. n
			//    dropShadowEnabled = "true"    // true | false
			//    shadowDirection   = "right"   // left | right | center
			return strAux;
		}
	
		return {

			replaceCssClasses: function (xml) {
				var replaceMarker = "gxpl_cssReplace(";
				while ((posIni = xml.indexOf(replaceMarker)) >= 0) {
					posFin = xml.indexOf(")", posIni);
					className = xml.substring(posIni + replaceMarker.length, posFin);
					style = getCSSStyle(className);
					toReplace = xml.substring(posIni, posFin + 1);
					xml = xml.replace(toReplace, style);
				}
				return xml;
			},

			parseStyle: function (style) {
				var cssStyle = "";
				if (style != "" && style != undefined) {
					if (style.indexOf(":") < 0)
						return style;	// No se parsea pues el el nombre de una clase
					else {
						var arr = style.split(";");
						for (var i = 0; i < arr.length; i++) {
							var arr2 = arr[i].split(":");
							var key = arr2[0];
							var value = arr2[1];
							var key2 = (key == "borderThickness" ? "borderWidth" : key);
							var units = (key == "borderThickness" || key == "fontSize" ? "px" : "");
							cssStyle += (cssStyle == "" ? "" : ",") + '"' + key2 + '":"' + value + units + '"';
						}
					}
					return "{" + cssStyle + "}";
				}
				return "{}";
			},
			
			resolveVariable: function(value) {
				if (qv.util.startsWith(value, "var(") && qv.util.endsWith(value, ")")) {
					var variableName = value.substr(4, value.length - 5);
					return qv.util.trim(getComputedStyle(document.documentElement).getPropertyValue(variableName.toLowerCase()));
				}
				else
					return value;
			}

		}

	})(),

	autorefresh: (function () {

		return {

			UpdateLayoutSameGroup: function (qViewer, sourceElements, allowElementsOrderChange) {

				function ParseParametersXML(qViewer, xml) {
					var xmlDoc = qv.util.dom.xmlDocument(xml);
					var rootElement = qv.util.dom.getSingleElementByTagName(xmlDoc, "gxpl_ParameterCollection");
					if (qViewer.Metadata == undefined)
						qViewer.Metadata = {};
					qViewer.Metadata.Parameters = [];
					var parameters = qv.util.dom.getMultipleElementsByTagName(rootElement, "gxpl_Parameter");
					for (var i = 0; i < parameters.length; i++) {
						var parameter = {};
						parameter.Name = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(parameters[i], "Name"));
						parameter.Type = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(parameters[i], "Type"));
						parameter.IsCollection = gx.lang.gxBoolean(qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(parameters[i], "IsCollection")));
						qViewer.Metadata.Parameters.push(parameter);
					}
				}

				function UpdateTargetElementsAndParametersFromSourceElements(qViewer, sourceElements) {
				
					function GetParameterInQuery(qViewer, axisName) {
						for (var i = 0 ; i < qViewer.Metadata.Parameters.length; i++) {
							var parameter = qViewer.Metadata.Parameters[i];
							if (parameter.IsCollection && parameter.Name == axisName)
								return [i, parameter];
						}
						return [null, null];
					}

					function GetRuntimeParameter(qViewer, axisName) {
						var runtimeParameter = null;
						for (var i = 0; i < qViewer.Parameters.length; i++) {
							if (qViewer.Parameters[i].Name == axisName) {
								runtimeParameter = qViewer.Parameters[i];
								break;
							}
						}
						return runtimeParameter;
					}

					function GetRuntimeParameterValue(sourceAxis, parameter) {
						var valueList = "";
						var delimiter = (parameter.Type == "I" || parameter.Type == "R" || parameter.Type == "B" ? "" : "\"");
						for (var i = 0; i < sourceAxis.Filter.Values.length; i++) {
							valueList += (valueList == "" ? "" : ",") + delimiter + sourceAxis.Filter.Values[i] + delimiter;
						}
						valueList = "[" + valueList + "]";
						return valueList;
					}

					var elements = [];
					if (!qViewer._parametersCloned) {
						// Clono la collection de parámetros pues aunque se carguen en los eventos con la misma variable el autorefresh agrega diferente a la collection dependiendo de si es chart o no chart
						qViewer._parametersCloned = true;
						qViewer.Parameters = qv.util.cloneObject(qViewer.Parameters);
					}
					var keys = qv.util.GetOrderedElementsKeys(qViewer, sourceElements);
					var targetMetadata = qViewer.GetMetadata();
					for (var i = 0; i < keys.length; i++) {
						var index = parseInt(keys[i].substr(6, 4));
						sourceElement = sourceElements[index];
						var parameterArray = GetParameterInQuery(qViewer, sourceElement.Name);
						var parameterPosition = parameterArray[0];
						var parameter = parameterArray[1];
						var targetElement = qv.util.GetElementInCollection(targetMetadata, "Name", sourceElement.Name);
						var applyToElement = (targetElement != null);
						var applyToParameter = !applyToElement;
						if (applyToElement) {
							qv.util.MergeFields(sourceElement, targetElement);
							elements.push(targetElement);
						}
						if (applyToParameter) {
							// no existe un eje para aplicar los cambios, busco si puedo aplicarlos en un parametro
							if (parameter != null) {
								// existe un parámetro en la query destino, aplico los cambios ahí
								var runtimeParameterValue = GetRuntimeParameterValue(sourceElement, parameter);
								if (qViewer.Object) {
									var array = eval(qViewer.Object);
									array[parameterPosition + 2] = runtimeParameterValue;
									qViewer.Object = JSON.stringify(array);
								}
								else {
									var runtimeParameter = GetRuntimeParameter(qViewer, sourceElement.Name);
									if (runtimeParameter == null) {
										runtimeParameter = {};
										runtimeParameter.Name = sourceElement.Name;
										qViewer.Parameters.push(runtimeParameter);
									}
									runtimeParameter.Value = runtimeParameterValue;
								}
							}
						}
					}
					qViewer.Axes = elements;
				}

				function UpdateQueryViewer(qViewer, sourceElements, allowElementsOrderChange) {
					UpdateTargetElementsAndParametersFromSourceElements(qViewer, sourceElements);
					qViewer.RememberLayout = false;
					qViewer.AllowElementsOrderChange = allowElementsOrderChange;
					qv.util.autorefresh.SaveAxesAndParametersState(qViewer);
					qViewer._Autorefreshing = true;
					qViewer.realShow();
				}

				if ((qViewer.AutoRefreshGroup != undefined) && (qViewer.AutoRefreshGroup != null) && (qViewer.AutoRefreshGroup != "") && (qv.util.trim(qViewer.AutoRefreshGroup) != "")) {

					qv.util.autorefresh.DeleteAxesAndParametersState(qViewer);
					for (index in qv.collection) {
						qViewerOther = qv.collection[index];
						if (qv.services.IsObjectSet(qViewerOther))
							if (qViewerOther.userControlId() != qViewer.userControlId()) {
								if (qViewer.AutoRefreshGroup == qViewerOther.AutoRefreshGroup) {
									// In same Refresh Group
									if (qViewerOther.Metadata != undefined && qViewerOther.Metadata.Parameters != undefined)
										UpdateQueryViewer(qViewerOther, sourceElements, allowElementsOrderChange);
									else
										qViewerOther.getQueryParameters(function (parametersXML, qViewer) {
											ParseParametersXML(qViewer, parametersXML);
											UpdateQueryViewer(qViewer, sourceElements, allowElementsOrderChange);
										});
								}
							}
					}
				}

			},

			LoadAxesAndParametersState: function (qViewer) {

				function GetObjectByName(array, name) {
					for (var i = 0; i < array.length; i++) {
						if (array[i].Name.toLowerCase() == name.toLowerCase())
							return array[i];
					}
					return null;
				}
			
				function MergeArraysByName(destinationArr, sourceArr) {
					for (var i = 0; i < sourceArr.length; i++) {
						var sourceObj = sourceArr[i];
						var destinationObj = GetObjectByName(destinationArr, sourceObj.Name);
						if (destinationObj != null)
							destinationObj = Object.assign(destinationObj, sourceObj);
					}
					return destinationArr;
				}
				
				var path = window.location.pathname + "_" + qViewer.userControlId() + "_" + qViewer.ObjectId + "_" + qViewer.ObjectName + "_";
				var cookieparameterID = path + "Parameters";
				var cookieAxesID = path + "Axes";
				var parametersString = qv.util.storage.getItem(cookieparameterID);
				var AxesString = qv.util.storage.getItem(cookieAxesID);
				if (parametersString != null && parametersString != "") {
					qViewer.Parameters = MergeArraysByName(JSON.parse(parametersString), qViewer.Parameters);
					qViewer.RememberLayout = false;
				}
				if (AxesString != null && AxesString != "") {
					qViewer.Axes = MergeArraysByName(JSON.parse(AxesString), qViewer.Axes);
					qViewer.RememberLayout = false;
				}
			},

			SaveAxesAndParametersState: function (qViewer) {
				var path = window.location.pathname + "_" + qViewer.userControlId() + "_" + qViewer.ObjectId + "_" + qViewer.ObjectName + "_";
				var cookieparameterID = path + "Parameters";
				var cookieAxesID = path + "Axes";
				qv.util.storage.setItem(cookieparameterID, JSON.stringify(qViewer.Parameters));
				qv.util.storage.setItem(cookieAxesID, JSON.stringify(qViewer.Axes));
			},

			DeleteAxesAndParametersState: function (qViewer) {
				var path = window.location.pathname + "_" + qViewer.userControlId() + "_" + qViewer.ObjectId + "_" + qViewer.ObjectName + "_";
				var cookieparameterID = path + "Parameters";
				var cookieAxesID = path + "Axes";
				qv.util.storage.removeItem(cookieparameterID);
				qv.util.storage.removeItem(cookieAxesID);
			}

		}

	})(),        
	
	dom: {

		getSingleElementByTagName: function (parent, name) {
			var nodes;
			var node;
			nodes = this.getMultipleElementsByTagName(parent, name);
			node = (nodes.length > 0 ? nodes[0] : null);
			return node;
		},

		getMultipleElementsByTagName: function (parent, name) {
			var nodes;
			var node;
			if (!gx.util.browser.isIE() || gx.util.browser.ieVersion() >= 12)
				nodes = parent.getElementsByTagName(name);
			else // Internet Explorer
				nodes = parent.selectNodes(name);
			return nodes;
		},

		getBooleanAttribute: function (element, attName, defaultValue) {
			var attValue = element.getAttribute(attName);
			if (attValue == null)
				return defaultValue;
			else
				return attValue.toLowerCase() == "true";
		},

		getCharacterAttribute: function (element, attName, defaultValue) {
			var attValue = element.getAttribute(attName);
			if (attValue == null)
				return defaultValue;
			else
				return attValue;
		},

		getValueNode: function (node) {
			if ((node == null) || (node == undefined))
				return null;
			if ((node.firstChild != null) && (node.firstChild != undefined))
				return node.firstChild.nodeValue;
			else
				return null;
		},

		selectXPathNode: function (xmlDoc, xpath) {
			var nodes;
			var node;
			if (xmlDoc.evaluate) { // Firefox, Chrome, Opera and Safari
				nodes = xmlDoc.evaluate(xpath, xmlDoc, null, XPathResult.ANY_TYPE, null);
				node = nodes.iterateNext();
			} else {			// Internet Explorer
				nodes = xmlDoc.selectNodes(xpath);
				node = (nodes.length > 0 ? nodes[0] : null);
			}
			return node;
		},

		xmlDocument: function (text) {
			var xmlDoc;
			if (!gx.util.browser.isIE() || gx.util.browser.ieVersion() >= 12) {
				parser = new DOMParser();
				xmlDoc = parser.parseFromString(text, "text/xml");
			} else // Internet Explorer
			{
				xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
				xmlDoc.async = "false";
				xmlDoc.loadXML(text);
			}
			return xmlDoc;
		},

		getEmptyContainer: function (qViewer) {
			var container = qViewer.getContainerControl();
			while (container.firstChild) container.removeChild(container.firstChild);
			return container;
		},

		setStyle: function (element, styleObj) {
			for (key in styleObj)
				element.style[key] = styleObj[key];
		},

		createText: function (parent, text) {
			var textNode = document.createTextNode(text);
			parent.appendChild(textNode);
			return textNode;
		},

		createElement: function (parent, tagName, id, className, styleObj, onClick, text) {
			var element = document.createElement(tagName);
			if (id != "")
				element.id = id;
			if (className != "")
				element.className = className;
			qv.util.dom.setStyle(element, styleObj);
			if (typeof onClick == 'function')
				element.onclick = onClick;
			if (text != "")
				var textNode = qv.util.dom.createText(element, text);
			if (parent != null)
				parent.appendChild(element);
			return element;
		},

		createTable: function (parent, className, styleObj) {
			var table = qv.util.dom.createElement(parent, "TABLE", "", className, styleObj, null, "");
			var tBody = document.createElement("TBODY");
			table.appendChild(tBody);
			return tBody;
		},

		createRow: function (parentTable) {
			return qv.util.dom.createElement(parentTable, "TR", "", "", {}, null, "");
		},

		createCell: function (parentRow, colSpan, align, styleObj, text) {
			var cell = qv.util.dom.createElement(parentRow, "TD", "", "", styleObj, null, text);
			if (colSpan != 1)
				cell.colSpan = colSpan;
			if (align != "")
				cell.align = align;
			return cell;
		},

		createSpan: function (parent, id, className, title, styleObj, onClick, text) {
			var span = qv.util.dom.createElement(parent, "SPAN", id, className, styleObj, onClick, text);
			if (title != "")
				span.title = title;
			return span;
		},

		createDiv: function (parent, id, className, title, styleObj, text) {
			var div = qv.util.dom.createElement(parent, "DIV", id, className, styleObj, null, text);
			if (title != "")
				div.title = title;
			return div;
		},

		createAnchor: function (parent, id, styleObj, text) {
			return qv.util.dom.createElement(parent, "A", id, "", styleObj, null, text);
		},

		createInput: function (parent, id, type, styleObj) {
			var input = qv.util.dom.createElement(parent, "INPUT", id, "", styleObj, null, "");
			if (type != "")
				input.type = type;
			return input;
		},

		createSelect: function (parent, id) {
			return qv.util.dom.createElement(parent, "SELECT", id, "", {}, null, "");
		},

		createOption: function (parent, value, selected, text) {
			var option = qv.util.dom.createElement(parent, "OPTION", "", "", {}, null, text);
			if (value != "")
				option.value = value;
			if (selected)
				option.selected = true;
			return option;
		},

		createIcon: function (parent, title, styleObj, text) {
			var icon = qv.util.dom.createElement(parent, "I", "", "material-icons", styleObj, null, text);
			if (title != "")
				icon.title = title;
			return icon;
		},

		loadStylesAndScripts: function (mainStyleUrls, libraryStyleUrls, scripts, callback) {

			function getLayerName(url) {
				return url.replace(/\//g, "_").replace(/\./g, "_");
			}
			
			function loadStyle(url, layer, beforeElement, callback) {
				qv.util.dom._loadedStyles = qv.util.dom._loadedStyles || [];
				if (qv.util.dom._loadedStyles.indexOf(url) < 0) {
					qv.util.dom._loadedStyles.push(url);
					var staticDir = qv.services.url.getStaticDirectory();
					var urlAux = staticDir + url;
					if (gx.O.DSO) {
						var style = document.createElement("style");
						style.setAttribute("data-gx-href", urlAux);
						style.innerHTML = '@import url("' + urlAux + '") layer(' + layer + ')';
						if (typeof (callback) === 'function') {
							style.onload = callback;
						}
						$(style).insertBefore(beforeElement);
					}
					else
					{
						var link = document.createElement("link");
						link.type = "text/css";
						link.rel = "stylesheet";
						link.href = urlAux;
						if (typeof (callback) === 'function') {
							link.onload = callback;
						}
						$(link).insertBefore(beforeElement);
					}
				}
				else
					callback();
			}

			function loadStylesAndScriptsMain(styleUrls, beforeElement, scripts, callback, i) {
				if (typeof (i) === 'undefined') {
					i = 0;
				}
				if (i >= styleUrls.length) {
					var staticDir = qv.services.url.getStaticDirectory();
					gx.http.loadScripts(scripts.map(function (url) { return staticDir + url }), callback);
				}
				else {
					loadStyle(styleUrls[i], layer, beforeElement, (function (styleUrls, callback, i) {
						loadStylesAndScriptsMain(styleUrls, beforeElement, scripts, callback, i + 1);
					}).closure(this, [styleUrls, callback, i]));
				}
			}

			var layer = getLayerName(mainStyleUrls[0]);
			loadStyle(mainStyleUrls[0], layer, gx.getThemeElement(), (function (libraryStyleUrls, callback) {
				var mainStyleElement = qv.util.GetLinkOrStyleElement(mainStyleUrls[0]);
				var remainingStyleUrls = mainStyleUrls.slice(1).concat(libraryStyleUrls);
				loadStylesAndScriptsMain(remainingStyleUrls, mainStyleElement, scripts, callback);
			}).closure(this, [libraryStyleUrls, callback]));

		}

	},

	storage: (function() {

		function createCookie(name, value, days) {
			if (days) {
				var date = new Date();
				date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
				var expires = "; expires=" + date.toGMTString();
			} else
				var expires = "";
			document.cookie = name + "=" + value + expires + "; path=/";
		}

		function readCookie(name) {
			var nameEQ = name + "=";
			var ca = document.cookie.split(';');
			for (var i = 0; i < ca.length; i++) {
				var c = ca[i];
				while (c.charAt(0) == ' ') c = c.substring(1, c.length);
				if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
			}
			return null;
		}

		function eraseCookie(name) {
			createCookie(name, "", -1);
		}

		return {

			setItem: function (key, data) {
				if (!!localStorage)
					localStorage.setItem(key, data);
				else
					createCookie(key, data, 365);
			},

			getItem: function (key) {
				if (!!localStorage)
					return localStorage.getItem(key);
				else
					return readCookie(key);
			},

			removeItem: function (key) {
				if (!!localStorage)
					localStorage.removeItem(key);
				else
					eraseCookie(key);
			}
		}

	})(),

	ExecuteTracker: function (trackerId, trackerData) {
		var trackers = Array();
		for (var i = 0; i < gx.fx.ctx.trackers.length; i++)
			if (gx.fx.ctx.trackers[i].types[0] == trackerId) trackers[trackers.length] = gx.fx.ctx.trackers[i];
		for (var i = 0; i < trackers.length; i++) {
			var tgxO = gx.O;
			gx.O = trackers[i].obj;
			var tCmp = gx.csv.cmpCtx;
			gx.csv.cmpCtx = trackers[i].obj.CmpContext;
			gx.evt.setProcessing(false);
			trackers[i].hdl.call(trackers[i].obj, null, null, trackerData);
			gx.O = tgxO;
			gx.csv.cmpCtx = tCmp;
		}
	},

	satisfyStyle: function (value, conditionalStyle) {
		switch (conditionalStyle.Operator) {
			case QueryViewerConditionOperator.Equal:
				return value == conditionalStyle.Value1;
			case QueryViewerConditionOperator.GreaterThan:
				return value > conditionalStyle.Value1;
			case QueryViewerConditionOperator.LessThan:
				return value < conditionalStyle.Value1;
			case QueryViewerConditionOperator.GreaterOrEqual:
				return value >= conditionalStyle.Value1;
			case QueryViewerConditionOperator.LessOrEqual:
				return value <= conditionalStyle.Value1;
			case QueryViewerConditionOperator.NotEqual:
				return value != conditionalStyle.Value1;
			case QueryViewerConditionOperator.Interval:
				return value >= conditionalStyle.Value1 && value <= conditionalStyle.Value2;
		}
	},

	isGeneXusPreview: function () {
		return IsQueryObjectPreview();
	},

	getGenerator: function () {
		var gen;
		if (gx.gen.isDotNet() || gx.gen.isDotNetCore())
			gen = "C#";
		else if (gx.gen.isJava())
			gen = "Java";
		else
			gen = "";
		return gen;
	},

	getErrorFromText: function (resultText) {
		if (resultText == "<Result OK=\"True\"></Result>")
			return ""; // No hubo error
		else
			return resultText.replace("<Result OK=\"False\"><Dsc>", "").replace("</Dsc></Result>", "");
	},

	trim: function (str) {
		if (typeof str != 'string')
			return null;
		return str.replace(/^[\s]+/, '').replace(/[\s]+$/, '').replace(/[\s]{2,}/, ' ');
	},

	capitalize: function (str) {
		return str.charAt(0).toUpperCase() + str.slice(1);
	},

	decapitalize: function (str) {
		return str.charAt(0).toLowerCase() + str.slice(1);
	},

	dateToString: function (date, includeTime) {
		var dateStr = date.getStringWithFmt("Y4MD").replace(/\//g, "-");
		if (includeTime) {
			date.TimeFmt = 24;
			dateStr += " " + date.getTimeString(true, true);
		}
		return dateStr;
	},

	cloneObject: function (obj) {
		return JSON.parse(JSON.stringify(obj));
	},

	endsWith: function (string, subString) {
		return string.substr(string.length - subString.length, subString.length) == subString;
	},

	startsWith: function (string, subString) {
		return string.substr(0, subString.length) == subString;
	},

	formatNumber: function (number, decimalPrecision, picture, removeTrailingZeroes) {

		var formattedNumber = gx.num.formatNumber(number, decimalPrecision, picture, 0, true, false);
		if (removeTrailingZeroes) {
			if (formattedNumber.indexOf(gx.decimalPoint) >= 0) {
				while (qv.util.endsWith(formattedNumber, "0"))
					formattedNumber = formattedNumber.slice(0, -1);
				if (qv.util.endsWith(formattedNumber, gx.decimalPoint))
					formattedNumber = formattedNumber.slice(0, -1);
			}
		}
		return formattedNumber;
	},

	formatDateTime: function (date, dataType, dateFormat, includeHours, includeMinutes, includeSeconds, includeMilliseconds) {
		var gxDate = new gx.date.gxdate(date, "Y4MD");
		var formattedDate = gxDate.getStringWithFmt(dateFormat);
		if (dataType == QueryViewerDataType.DateTime) {
			gxDate.TimeFmt = 24;
			formattedDate += " " + gxDate.getTimeString(includeMinutes, includeSeconds, includeHours, includeMilliseconds);
		}
		return formattedDate;
	},

	seconsdToText: function (seconds) {
		var text;
		var picture = "ZZZZZZZZZZZZZZ9";
		var decimalPrecision = 0;
		if (seconds < 60)							// less than 1 minute
			text = qv.util.formatNumber(Math.round(seconds), decimalPrecision, picture, false) + " " + qv.util.decapitalize(gx.getMessage("GXPL_QViewerSeconds"));
		else if (seconds < 60 * 60)					// less than 1 hour
			text = qv.util.formatNumber(Math.round(seconds / 60), decimalPrecision, picture, false) + " " + qv.util.decapitalize(gx.getMessage("GXPL_QViewerMinutes"));
		else if (seconds < 60 * 60 * 24)			// less than 1 day
			text = qv.util.formatNumber(Math.round(seconds / 60 / 60), decimalPrecision, picture, false) + " " + qv.util.decapitalize(gx.getMessage("GXPL_QViewerHours"));
		else if (seconds < 60 * 60 * 24 * 30.44)	// less than 1 month
			text = qv.util.formatNumber(Math.round(seconds / 60 / 60 / 24), decimalPrecision, picture, false) + " " + qv.util.decapitalize(gx.getMessage("GXPL_QViewerDays"));
		else if (seconds < 60 * 60 * 24 * 365.25)	// less than 1 year
			text = qv.util.formatNumber(Math.round(seconds / 60 / 60 / 24 / 30.44), decimalPrecision, picture, false) + " " + qv.util.decapitalize(gx.getMessage("GXPL_QViewerMonths"));
		else										// more than 1 year
			text = qv.util.formatNumber(Math.round(seconds / 60 / 60 / 24 / 365.25), decimalPrecision, picture, false) + " " + qv.util.decapitalize(gx.getMessage("GXPL_QViewerYears"));
		return text;
	},

	ParseNumericPicture: function (dataType, picture) {
		var decimalPrecision;
		var useThousandsSeparator;
		var prefix = "";
		var suffix = "";
		if (picture == "") {
			decimalPrecision = (dataType == QueryViewerDataType.Integer ? 0 : 2);
			useThousandsSeparator = false;
		}
		else {			// Saco los datos de la picture
			if (picture.indexOf(".") < 0 && picture.indexOf(",") < 0) {		// No tiene ni punto ni coma
				decimalPrecision = 0;
				useThousandsSeparator = false;
			} else if (picture.indexOf(".") >= 0 && picture.indexOf(",") < 0) {	// Tiene solo punto
				decimalPrecision = (dataType == QueryViewerDataType.Integer ? 0 : picture.length - picture.indexOf(".") - 1);
				useThousandsSeparator = false;
			} else if (picture.indexOf(".") < 0 && picture.indexOf(",") >= 0) {	// Tiene solo coma
				decimalPrecision = 0;
				useThousandsSeparator = true;
			} else {															// Tiene punto y coma
				decimalPrecision = (dataType == QueryViewerDataType.Integer ? 0 : picture.length - picture.indexOf(".") - 1);
				useThousandsSeparator = true;
			}
			// Obtengo prefijo y sufijo.
			// pictureArea = 1 (prefijo), 2 (número) o 3 (sufijo)
			var pictureArea = 1;
			for (var i = 0; i < picture.length; i++) {
				var chr = picture.substr(i, 1);
				if ((chr == "." || chr == "," || chr == "9" || chr == "Z") && pictureArea == 1)
					pictureArea = 2;
				if ((chr != "." && chr != "," && chr != "9" && chr != "Z") && pictureArea == 2)
					pictureArea = 3;
				switch (pictureArea) {
					case 1:
						prefix += chr;
						break;
					case 3:
						suffix += chr;
						break;
				}
			}
		}
		return { DecimalPrecision: decimalPrecision, UseThousandsSeparator: useThousandsSeparator, Prefix: prefix, Suffix: suffix };
	},

	ParseDateTimePicture: function (dataType, picture) {
		var dateFormat = gx.dateFormat;
		var includeHours = dataType == QueryViewerDataType.DateTime;
		var includeMinutes = dataType == QueryViewerDataType.DateTime;
		var includeSeconds = dataType == QueryViewerDataType.DateTime;
		var includeMilliseconds = dataType == QueryViewerDataType.DateTime;
		if (picture != "") {
			if (picture.indexOf("9999") >= 0 && dateFormat.indexOf("Y4") < 0)
				dateFormat = dateFormat.replace("Y", "Y4");
			else if (picture.indexOf("9999") < 0 && dateFormat.indexOf("Y4") >= 0)
				dateFormat = dateFormat.replace("Y4", "Y");
			if (dataType == QueryViewerDataType.DateTime) {
				var posSeparator = picture.indexOf(" ");
				if (posSeparator >= 0) {
					var timePart = picture.substr(posSeparator + 1, picture.length - posSeparator);
					includeHours = timePart.length >= 2;
					includeMinutes = timePart.length >= 5;
					includeSeconds = timePart.length >= 8;
					includeMilliseconds = timePart.length == 12;
				}
				else {
					includeHours = false;
					includeMinutes = false;
					includeSeconds = false;
					includeMilliseconds = false;
				}
			}
		}
		return { DateFormat: dateFormat, IncludeHours: includeHours, IncludeMinutes: includeMinutes, IncludeSeconds: includeSeconds, IncludeMilliseconds: includeMilliseconds };
	},

	evaluate : function (formula, baseName, variables) {
		for (var i = 1; i <= variables.length; i++)
			formula = formula.replace(baseName + i.toString(), variables[i-1]);
		return eval(formula);
	},
	
	aggregate: function (aggregation, values, quantities) {
		aggregation = aggregation || QueryViewerAggregationType.Sum;
		var sumValues = null;
		var sumQuantities = null;
		var minValue = null;
		var maxValue = null;
		switch (aggregation) {
			case QueryViewerAggregationType.Sum:
				for (var i = 0; i < values.length; i++) {
					if (values[i] != null)
						sumValues += values[i];
				}
				return sumValues;
			case QueryViewerAggregationType.Average:
				for (var i = 0; i < values.length; i++) {
					if (values[i] != null) {
						sumValues += values[i];
						sumQuantities += quantities[i];
					}
				}
				return sumValues != null ? sumValues / sumQuantities : null;
			case QueryViewerAggregationType.Count:
				for (var i = 0; i < quantities.length; i++) { sumQuantities += quantities[i]; }
				return sumQuantities;
			case QueryViewerAggregationType.Max:
				for (var i = 0; i < values.length; i++) { maxValue = (maxValue == null ? values[i] : (values[i] > maxValue ? values[i] : maxValue)); }
				return maxValue;
			case QueryViewerAggregationType.Min:
				for (var i = 0; i < values.length; i++) { minValue = (minValue == null ? values[i] : (values[i] < minValue ? values[i] : minValue)); }
				return minValue;
		}
	},

	anyError: function (resultText) {
		return (resultText.indexOf("<Result OK=\"False\"><Dsc>") == 0);
	},

	showActivityIndicator: function (qViewer) {
		var f = 'qv.util.showActivityIndicatorMain("' + qViewer.getContainerControl().id + '");';
		var ucId = qViewer.userControlId();
		if (qv.fadeTimeouts[ucId])
			clearTimeout(qv.fadeTimeouts[ucId]);
		qv.fadeTimeouts[ucId] = setTimeout(f, 500); 
	},

	showActivityIndicatorMain: function (containerId) {
		var container = document.getElementById(containerId);
		gx.dom.addClass(container, "gx-qv-loading");
		for (var i = 0; i < container.childNodes.length; i++)
			gx.dom.addClass(container.childNodes[i], "gx-qv-loading-children");
	},

	hideActivityIndicator: function (qViewer) {
		var ucId = qViewer.userControlId();
		if (qv.fadeTimeouts[ucId]) {
			clearTimeout(qv.fadeTimeouts[ucId]);
			qv.fadeTimeouts[ucId] = undefined;
		}
		var container = qViewer.getContainerControl();
		gx.dom.removeClass(container, "gx-qv-loading");
		for (var i = 0; i < container.childNodes.length; i++)
			gx.dom.removeClass(container.childNodes[i], "gx-qv-loading-children");
	},

	renderError: function (qViewer, errMsg) {
		if (IsQueryObjectPreview() && !IsDashboardEdit()) // Preview en GeneXus (se muestra en el output)
			window.external.SendText(qViewer.ControlName, errMsg);
		else // Aplicación generada
		{
			var container = qv.util.dom.getEmptyContainer(qViewer);
			var div = qv.util.dom.createDiv(container, "", "gx-qv-centered-text", "", { width: gx.dom.addUnits(qViewer.Width), height: gx.dom.addUnits(qViewer.Height), borderColor: "silver", borderWidth: "thin", borderStyle: "solid" }, gx.getMessage("GXPL_QViewerError") + ": " + errMsg);
			qViewer._ControlRenderedTo = undefined;
			qv.util.hideActivityIndicator(qViewer);
		}
	},

	GetDesigntimeMetadata: function (qViewer) {

		var queryViewerAxes = [];
		// Agrego los ejes
		for (var i = 0; i < qViewer.Metadata.Axes.length; i++) {
			var axis = qViewer.Metadata.Axes[i];
			if (!axis.IsComponent) {
				var queryViewerElement = {};
				queryViewerElement.Name = axis.Name;
				queryViewerElement.Title = axis.Title;
				queryViewerElement.DataField = axis.DataField;
				queryViewerElement.Visible = axis.Visible;
				queryViewerElement.Type = QueryViewerElementType.Axis;
				queryViewerElement.Axis = axis.Axis;
				queryViewerElement.Filter = axis.Filter;
				queryViewerElement.ExpandCollapse = axis.ExpandCollapse;
				queryViewerElement.AxisOrder = axis.Order;
				queryViewerElement.Format = {};
				queryViewerElement.Format.Subtotals = axis.Subtotals;
				queryViewerElement.Format.Picture = axis.Picture;
				queryViewerElement.Format.CanDragToPages = axis.CanDragToPages;
				queryViewerElement.Format.Style = axis.Style;
				if (axis.ValuesStyles.length > 0)
					queryViewerElement.Format.ValuesStyles = axis.ValuesStyles;
				queryViewerElement.Actions = {};
				queryViewerElement.Actions.RaiseItemClick = axis.RaiseItemClick;
				queryViewerAxes.push(queryViewerElement);
			}
		}
		// Agrego los datos
		for (var i = 0; i < qViewer.Metadata.Data.length; i++) {
			var datum = qViewer.Metadata.Data[i];
			if (!datum.IsComponent) {
				var queryViewerElement = {};
				queryViewerElement.Name = datum.Name;
				queryViewerElement.Title = datum.Title;
				queryViewerElement.DataField = datum.DataField;
				queryViewerElement.Visible = datum.Visible;
				queryViewerElement.Type = QueryViewerElementType.Datum;
				queryViewerElement.Axis = "";
				queryViewerElement.Aggregation = datum.Aggregation;
				queryViewerElement.Format = {};
				queryViewerElement.Format.Picture = datum.Picture;
				queryViewerElement.Format.Style = datum.Style;
				queryViewerElement.Format.TargetValue = datum.TargetValue;
				queryViewerElement.Format.MaximumValue = queryViewerElement.Format.TargetValue;
				if (datum.ConditionalStyles.length > 0)
					queryViewerElement.Format.ConditionalStyles = datum.ConditionalStyles;
				queryViewerElement.Actions = {};
				queryViewerElement.Actions.RaiseItemClick = datum.RaiseItemClick;
				queryViewerAxes.push(queryViewerElement);
			}
		}
		return queryViewerAxes;
	},
	
	MergeFields: function (runtimeField, designtimeField) {
		if (designtimeField.Visible != QueryViewerVisible.Never) {
			designtimeField.Visible = runtimeField.Hidden ? QueryViewerVisible.No : QueryViewerVisible.Yes;
			if (designtimeField.Type == QueryViewerElementType.Axis) {
				designtimeField.Axis = runtimeField.Axis;
				if (runtimeField.Order)
				{
					switch (designtimeField.AxisOrder.Type) {
						case QueryViewerAxisOrderType.None:
						case QueryViewerAxisOrderType.Ascending:
						case QueryViewerAxisOrderType.Descending:
							designtimeField.AxisOrder.Type = runtimeField.Order;
							break;
						case QueryViewerAxisOrderType.Custom:
							if (runtimeField.Order == QueryViewerAxisOrderType.Descending)
								designtimeField.AxisOrder.Values.reverse();
							break;
					}
				}
				if (designtimeField.Format.Subtotals != QueryViewerSubtotals.No)
					if (runtimeField.Subtotals != undefined)
						designtimeField.Format.Subtotals = (runtimeField.Subtotals == QueryViewerSubtotals.Yes ? QueryViewerSubtotals.Yes : QueryViewerSubtotals.Hidden);
				if (runtimeField.Filter)
					designtimeField.Filter = runtimeField.Filter;
				if (runtimeField.ExpandCollapse)
					designtimeField.ExpandCollapse = runtimeField.ExpandCollapse;
			}
		}
	},

	GetOrderedElementsKeys: function (qViewer, elements) {

		function padLeft(nr, n, str) {
			return Array(n - String(nr).length + 1).join(str || '0') + nr;
		}

		var keys = [];
		for (var i = 0; i < elements.length; i++) {
			var element = elements[i];
			var typePrefix;
			if (qViewer.RealType == QueryViewerOutputType.Table)
				typePrefix = "0";														// No se distingue entre ejes y datos
			else
				typePrefix = (element.Type == QueryViewerElementType.Axis ? "1" : "2");	// Los ejes van antes que los datos
			var key = typePrefix;
			if (element.Position != null) {
				var axisPrefix;
				if (qViewer.RealType == QueryViewerOutputType.PivotTable) {				// Se distingue entre tipo de eje
					if (element.Type == QueryViewerElementType.Axis) {
						switch (element.Axis) {
							case QueryViewerAxisType.Columns:
								axisPrefix = "B";
								break;
							case QueryViewerAxisType.Pages:
								axisPrefix = "C";
								break;
							default:
								axisPrefix = "A";
								break;
						}
					}
					else
						axisPrefix = "D";
				}
				else
					axisPrefix = "A";													// No se distingue entre tipo de eje
				key += axisPrefix + padLeft(element.Position, 4, "0") + padLeft(i, 4, "0");
			}
			else
				key += "Z" + padLeft(i, 4, "0") + padLeft(i, 4, "0");		// Elementos invisibles van al final	
			keys.push(key);
		}
		keys.sort();
		return keys;

	},

	GetContainerControlClass: function (qViewer) {
		if (qViewer.Class != "") {
			var ucClass = qViewer.Class + "-" + qViewer.RealType.toLowerCase();
			return ucClass;
		}
		else
			return "";
	},

	GetContainerControlClasses: function (qViewer) {
		var ucCls = qv.util.GetContainerControlClass(qViewer);
		var classes;
		switch (qViewer.RealType) {
			case QueryViewerOutputType.Card:
				classes = "qv-card";
				break;
			case QueryViewerOutputType.Chart:
				classes = "qv-chart";
				break;
			case QueryViewerOutputType.PivotTable:
				classes = "qv-pivottable";
				break;
			case QueryViewerOutputType.Table:
				classes = "qv-table";
				break;
			case QueryViewerOutputType.Map:
				classes = "qv-map";
				break;
		}
		if (ucCls != "")
			classes += " " + ucCls;
		return classes;
	},

	SetUserControlClass: function (uc, className) {
		uc.getContainerControl().className = "gx_usercontrol " + className;
	},
	
	GetElementInCollection: function(col, property, elementName) {
		for (var i = 0 ; i < col.length; i++) {
			var element = col[i];
			if (element[property] == elementName)
				return element;
		}
		return null;
	},

	IsInteger: function(value) {
		if (Number.isInteger)
			return Number.isInteger(value);
		else 
			return typeof value === "number" && isFinite(value) && Math.floor(value) === value;		// Internet Explorer
	},

	ApplyPicture: function (value, picture, dataType, pictureProperties) {
		switch (dataType) {
			case QueryViewerDataType.Integer:
			case QueryViewerDataType.Real:
				return qv.util.formatNumber(value, pictureProperties.DecimalPrecision, picture, false);
			case QueryViewerDataType.Boolean:
			case QueryViewerDataType.Character:
			case QueryViewerDataType.GUID:
			case QueryViewerDataType.GeoPoint:
				return qv.util.trim(value);
			case QueryViewerDataType.Date:
			case QueryViewerDataType.DateTime:
				return qv.util.formatDateTime(value, dataType, pictureProperties.DateFormat, pictureProperties.IncludeHours, pictureProperties.IncludeMinutes, pictureProperties.IncludeSeconds, pictureProperties.IncludeMilliseconds);
		}
	},

	GetPictureProperties: function (dataType, picture) {
		var pictureProperties;
		if (dataType == QueryViewerDataType.Integer || dataType == QueryViewerDataType.Real)
			pictureProperties = qv.util.ParseNumericPicture(dataType, picture);
		else if (dataType == QueryViewerDataType.Date || dataType == QueryViewerDataType.DateTime)
			pictureProperties = qv.util.ParseDateTimePicture(dataType, picture);
		else
			pictureProperties = null;
		return pictureProperties;
	},

	GetAxisByDataField: function (qViewer, dataField) {
		for (var i = 0; i < qViewer.Metadata.Axes.length; i++)
			if (qViewer.Metadata.Axes[i].DataField == dataField)
				return qViewer.Metadata.Axes[i];
	},

	GetThemeStyleSheet: function (qViewer) {
		if (!qViewer._themeStyleSheet)
			qViewer._themeStyleSheet = gx.getThemeElement().sheet;
		return qViewer._themeStyleSheet;
	},

	GetNullColor: function () {
		return qv.util.GetColorObject("");
	},

	GetColorObject: function (colorStr) {
		return { IsDefault: false, Color: colorStr, ColorIndex: '-1' };
	},

	IsNullColor: function (color) {
		return color.IsDefault ? color.ColorIndex < 0 : color.Color == "";
	},

	GetQueryViewerStyleSheet: function (qViewer) {
		if (!qViewer._queryViewerStyleSheet) {
			var cssName = "QueryViewer.css";
			var sheet = qv.util.GetLinkOrStyleElement(cssName).sheet;
			var importRule = sheet.rules[0];
			qViewer._queryViewerStyleSheet = importRule.styleSheet;
		}
		return qViewer._queryViewerStyleSheet;
	},

	GetLinkOrStyleElement: function (url) {
		if (gx.O.DSO) {
			var styles = document.getElementsByTagName("style");
			for (var i = 0; i < styles.length; i++)
				if (styles[i].attributes["data-gx-href"] && styles[i].attributes["data-gx-href"].value.indexOf(url) >= 0)
					return styles[i];
		}
		else {
			var links = document.getElementsByTagName("link");
			for (var i = 0; i < links.length; i++)
				if (links[i].attributes["href"] && links[i].attributes["href"].value.indexOf(url) >= 0)
					return links[i];
		}
		return null;
	},

	XAxisDataType: function (qViewer) {
		var cantRowsOrColumns = 0;
		var dataType = "";
		for (var i = 0; i < qViewer.Metadata.Axes.length; i++) {
			var axis = qViewer.Metadata.Axes[i];
			if (axis.Visible == QueryViewerVisible.Yes || axis.Visible == QueryViewerVisible.Always) {
				cantRowsOrColumns++;
				dataType = axis.DataType;
			}
		}
		if (cantRowsOrColumns == 1)
			return dataType;
		else
			return QueryViewerDataType.Character;		// Pues se concatenan los valores
	},

	ProcessDataAndMetadata: function (qViewer) {

		function TotData(data) {
			var totData = 0;
			for (var i = 0; i < data.length; i++)
				if (data[i].DataField != "F0")	// Quantity
					totData++;
			return totData;
		}

		function VisibleDatum(totData, datum) {
			if (totData == 1)
				return datum.Visible == QueryViewerVisible.Yes || datum.Visible == QueryViewerVisible.Always;
			else
				return datum.Visible != QueryViewerVisible.Never;
		}

		function GetCategoriesAndSeriesDataFields(qViewer) {
			qViewer.Chart.Categories = {};
			qViewer.Chart.Categories.DataFields = [];
			for (var i = 0; i < qViewer.Metadata.Axes.length; i++) {
				var axis = qViewer.Metadata.Axes[i];
				if (axis.Visible == QueryViewerVisible.Yes || axis.Visible == QueryViewerVisible.Always)
					if (qViewer.RealType != QueryViewerOutputType.Map || axis.DataType == QueryViewerDataType.Character)	// only character dimensions are valid for Maps
						qViewer.Chart.Categories.DataFields.push(axis.DataField);
			}
			qViewer.Chart.Series = {};
			qViewer.Chart.Series.DataFields = [];
			var totData = TotData(qViewer.Metadata.Data);
			for (var i = 0; i < qViewer.Metadata.Data.length; i++) {
				var datum = qViewer.Metadata.Data[i];
				if (VisibleDatum(totData, datum))
					qViewer.Chart.Series.DataFields.push(datum.DataField);
			}
		}

		function GetAxesByDataFieldObj(qViewer) {
			var axesByDataField = {};
			for (var i = 0; i < qViewer.Metadata.Axes.length; i++) {
				var axis = qViewer.Metadata.Axes[i];
				var pictureProperties = qv.util.GetPictureProperties(axis.DataType, axis.Picture);
				axesByDataField[axis.DataField] = { Picture: axis.Picture, DataType: axis.DataType, PictureProperties: pictureProperties, Filter: axis.Filter };
			}
			return axesByDataField;
		}

		function GetDataByDataFieldObj(qViewer, uniqueAxis) {

			function IsMulticoloredSerie(qViewer, datum, uniqueAxis) {

				function ExistColors(styles) {
					// Verifica si hay colores a partir de Styles condicionales
					var existColors = false;
					for (var i = 0; i < styles.length; i++) {
						var style = styles[i];
						var arr = GetColorFromStyle(style.StyleOrClass, false);
						var colorFound = arr[0];
						if (colorFound) {
							existColors = true;
							break;
						}
					}
					return existColors;
				}

				var multicoloredSerie;
				if (qViewer.RealType == QueryViewerOutputType.Map && ((qViewer.MapType == QueryViewerMapType.Choropleth && qViewer.Chart.colorAxis != "") || (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Chart.colorAxis != "")))
					multicoloredSerie = false;					// Estos tipos de gráfica tienen que dibujar sí o sí cada valor de referencia con un color diferente
				else if (qViewer.RealType == QueryViewerOutputType.Map && ((qViewer.MapType == QueryViewerMapType.Choropleth && (qViewer.Chart.colorAxis.dataClasses.length == 0)) || (qViewer.MapType == QueryViewerMapType.Bubble && (qViewer.Chart.colorAxis.dataClasses.length == 0))))
					multicoloredSerie = true;				// En este tipo de mapas todos los valores van a ir del mismo color 
				if (qViewer.RealType == QueryViewerOutputType.Chart && (qv.chart.IsSingleSerieChart(qViewer) || (qViewer.RealChartType == QueryViewerChartType.PolarArea && qViewer.Chart.Series.DataFields.length == 1)))
					multicoloredSerie = true;					// Estos tipos de gráfica tienen que dibujar sí o sí cada valor con un color diferente
				else if (qViewer.RealType == QueryViewerOutputType.Chart && (qv.chart.IsAreaChart(qViewer) || qv.chart.IsLineChart(qViewer) || qViewer.RealChartType == QueryViewerChartType.Radar || qViewer.RealChartType == QueryViewerChartType.FilledRadar))
					multicoloredSerie = false;					// Estos tipos de gráfica no pueden ser multicolores porque son líneas o áreas y no estamos dejando pintar partes de una linea o area de colores diferentes
				else if (qViewer.RealType == QueryViewerOutputType.Chart && (qViewer.Chart.Series.DataFields.length > 1 && !qv.chart.IsSplittedChart(qViewer)))
					multicoloredSerie = false;					// Multi series: al haber más de una serie hay una leyenda indicando el color de cada serie, por lo tanto todos los valores tienen que tener el mismo color
				else {
					// Single series
					var existConditionalColors = ExistColors(datum.ConditionalStyles);
					var existValuesColors = false;
					if (uniqueAxis != null)
						existValuesColors = ExistColors(uniqueAxis.ValuesStyles);	// Si tengo una sola categoria tambien se puede hacer por valor si corresponde
					multicoloredSerie = (existConditionalColors || existValuesColors);	// Es multicolor si existen colores condicionales o colores por valor
				}
				return multicoloredSerie;
			}

			var dataByDataField = {};
			var totData = TotData(qViewer.Metadata.Data);
			for (var i = 0; i < qViewer.Metadata.Data.length; i++) {
				var datum = qViewer.Metadata.Data[i];
				if (VisibleDatum(totData, datum)) {
					var multicolored = IsMulticoloredSerie(qViewer, datum, uniqueAxis)
					dataByDataField[datum.DataField] = { Datum: datum, Multicolored: multicolored };
				}
			}
			return dataByDataField;

		}

		function GetColorFromStyle(style, isBackgroundColor) {
			var color = "";
			var colorFound = false;
			var colorKey = isBackgroundColor ? "backgroundcolor" : "color";
			if (style != "") {
				var keyValuePairs = style.split(";");
				for (var i = 0; i < keyValuePairs.length; i++) {
					var keyValuePairStr = keyValuePairs[i];
					var keyValuePair = keyValuePairStr.split(":");
					if (keyValuePair.length == 2) {
						var key = qv.util.trim(keyValuePair[0]);
						var value = qv.util.trim(keyValuePair[1]);
						if (key.toLowerCase() == colorKey) {
							color = value;
							colorFound = (value != "");
							break;
						}
					}
				}
				if (colorFound && color.substr(0, 1) == "#")
					color = color.replace("#", "");
			}
			return [colorFound, color];
		}

		function GetColor(multicoloredSerie, datum, uniqueAxis, seriesIndex, colorIndex, categoryLabel, value) {

			function GetValueStyleColor(axis, value) {
				// Obtiene el color que corresponde al valor según el ValueStyle
				var arr = [false, ""];
				for (var i = 0; i < axis.ValuesStyles.length; i++) {
					var valueStyle = axis.ValuesStyles[i];
					if (valueStyle.Value == value) {
						arr = GetColorFromStyle(valueStyle.StyleOrClass, false);
						break;
					}
				}
				return arr;
			}

			function GetConditionalColor(datum, value) {
				// Obtiene el color que corresponde al valor según el Style condicional
				var arr = [false, ""];
				var conditionSatisfied = false;
				for (var i = 0; i < datum.ConditionalStyles.length; i++) {
					var conditionalStyle = datum.ConditionalStyles[i];
					conditionSatisfied = qv.util.satisfyStyle(value, conditionalStyle);
					if (conditionSatisfied) {
						arr = GetColorFromStyle(conditionalStyle.StyleOrClass, false);
						break;
					}
				}
				return arr;
			}

			var color;
			var colorIndexAux = -1;
			var isDefaultColor = false;
			var arr;
			if (multicoloredSerie) {		// Cada valor de la serie tiene un color diferente
				var colorFound = false;
				if (uniqueAxis != null) {
					arr = GetValueStyleColor(uniqueAxis, categoryLabel);	// Busco primero en los style por valor
					colorFound = arr[0];
					color = arr[1];
				}
				if (!colorFound) {
					arr = GetConditionalColor(datum, value)	// Busco luego en los styles condicionales
					colorFound = arr[0];
					color = arr[1];
					if (!colorFound) {
						colorIndexAux = colorIndex % HIGHCHARTS_MAX_COLORS;
						isDefaultColor = true;
					}
				}
			}
			else {		// Todos los valores de la serie con el mismo valor
				arr = GetColorFromStyle(datum.Style, false);
				colorFound = arr[0];
				color = arr[1];
				if (!colorFound) {
					colorIndexAux = seriesIndex % HIGHCHARTS_MAX_COLORS;
					isDefaultColor = true;
				}
			}
			return { IsDefault: isDefaultColor, Color: color, ColorIndex: colorIndexAux };
		}

		function AddCategoryValue(qViewer, row, valueIndex, axesByDataField) {

			function GetCategoryLabel(qViewer, row, axesByDataField) {

				var label = "";
				var labelWithPicture = "";
				for (var i = 0; i < qViewer.Chart.Categories.DataFields.length; i++) {
					var dataField = qViewer.Chart.Categories.DataFields[i];
					var value;
					var valueWithPicture;
					if (row[dataField] != undefined) {
						value = qv.util.trim(row[dataField]);
						valueWithPicture = qv.util.ApplyPicture(value, axesByDataField[dataField].Picture, axesByDataField[dataField].DataType, axesByDataField[dataField].PictureProperties);
					}
					else {
						value = qViewer.Metadata.TextForNullValues;
						valueWithPicture = qViewer.Metadata.TextForNullValues;
					}
					label += (label == "" ? "" : ", ") + value;
					labelWithPicture += (labelWithPicture == "" ? "" : ", ") + valueWithPicture;
				}
				return [label, labelWithPicture];
			}

			var arr = GetCategoryLabel(qViewer, row, axesByDataField);
			var categoryValue = {};
			categoryValue.Value = arr[0];
			categoryValue.ValueWithPicture = arr[1];
			qViewer.Chart.Categories.Values.push(categoryValue);
			if (valueIndex == 0) {
				qViewer.Chart.Categories.MinValue = categoryValue.Value;
				qViewer.Chart.Categories.MaxValue = categoryValue.Value;
			}
			else {
				if (categoryValue.Value > qViewer.Chart.Categories.MaxValue)
					qViewer.Chart.Categories.MaxValue = categoryValue.Value;
				if (categoryValue.Value < qViewer.Chart.Categories.MinValue)
					qViewer.Chart.Categories.MinValue = categoryValue.Value;
			}

		}

		function AddSeriesValues(qViewer, row, valueIndex, dataByDataField, uniqueAxis) {
			for (var i = 0; i < qViewer.Chart.Series.DataFields.length; i++) {
				var serie = qViewer.Chart.Series.ByIndex[i]
				var dataField = qViewer.Chart.Series.DataFields[i];
				var value = row[dataField] != undefined ? row[dataField] : null;
				var point = {};
				point.Value = value;
				var datum = dataByDataField[dataField].Datum;
				var multicoloredSerie = dataByDataField[dataField].Multicolored;
				if (datum.Aggregation == QueryViewerAggregationType.Average) {
					var value_N = row[dataField + "_N"];
					var value_D = row[dataField + "_D"];
					if (value_N == undefined && value_D == undefined) {
						// Caso de un dataprovider donde se le asigna agregación = Average por código
						value_N = value;
						value_D = "1";
					}
					point.Value_N = value_N;
					point.Value_D = value_D;
				}
				if (multicoloredSerie)
					point.Color = GetColor(multicoloredSerie, datum, uniqueAxis, 0, valueIndex, qViewer.Chart.Categories.Values[valueIndex].Value, value);
				else
					point.Color = qv.util.GetNullColor();
				serie.Points.push(point);
				if (point.Value > 0) serie.PositiveValues = true;
				if (point.Value < 0) serie.NegativeValues = true;
				if (valueIndex === 0) {
					serie.MinValue = parseFloat(point.Value);
					serie.MaxValue = parseFloat(point.Value);
				}
				else {
					if (parseFloat(point.Value) > serie.MaxValue)
						serie.MaxValue = parseFloat(point.Value);
					if (parseFloat(point.Value) < serie.MinValue)
						serie.MinValue = parseFloat(point.Value);
				}

			}
		}

		function CalculatePlotBands(qViewer, datum) {
			for (var j = 0; j < datum.ConditionalStyles.length; j++) {
				var conditionalStyle = datum.ConditionalStyles[j];
				var arr = GetColorFromStyle(conditionalStyle.StyleOrClass, true);
				var colorFound = arr[0];
				var backgroundColor = arr[1];
				if (colorFound) {
					plotBand = {};
					plotBand.Color = qv.util.GetColorObject(backgroundColor);
					if (conditionalStyle.Operator == QueryViewerConditionOperator.Interval) {
						plotBand.From = parseFloat(conditionalStyle.Value1);
						plotBand.To = parseFloat(conditionalStyle.Value2);
					} else if (conditionalStyle.Operator == QueryViewerConditionOperator.Equal) {
						plotBand.From = parseFloat(conditionalStyle.Value1);
						plotBand.To = parseFloat(conditionalStyle.Value1);
					}
					else if (conditionalStyle.Operator == QueryViewerConditionOperator.GreaterOrEqual || conditionalStyle.Operator == QueryViewerConditionOperator.GreaterThan)
						plotBand.From = parseFloat(conditionalStyle.Value1);
					else if (conditionalStyle.Operator == QueryViewerConditionOperator.LessOrEqual || conditionalStyle.Operator == QueryViewerConditionOperator.LessThan)
						plotBand.To = parseFloat(conditionalStyle.Value1);
					plotBand.SeriesName = datum.Title != "" ? datum.Title : datum.Name;
					qViewer.Chart.PlotBands.push(plotBand);
				}
			}
		}

		function IsFilteredRow(qViewer, row) {
			var filtered = false;
			for (var i = 0; i < qViewer.Metadata.Axes.length; i++) {
				var axis = qViewer.Metadata.Axes[i];
				if (axis.Visible == QueryViewerVisible.Yes || axis.Visible == QueryViewerVisible.Always) {
					var value = qv.util.trim(row[axis.DataField]);
					// Controlo contra la propiedad Filter
					if (axis.Filter.Type == QueryViewerFilterType.HideAllValues) {
						filtered = true;
						break;
					}
					else if (axis.Filter.Type == QueryViewerFilterType.ShowSomeValues) {
						if (axis.Filter.Values.indexOf(value) < 0) {
							filtered = true;
							break;
						}
					}
					if (qViewer.RealType === QueryViewerOutputType.Map && axis.DataType === QueryViewerDataType.Character) {
						// En mapas de Continent y Country filtro los países o estados que quedan fuera del mapa
						if (qViewer.Region === QueryViewerRegion.Country) {
							if (!qv.util.startsWith(value.toUpperCase(), qViewer.Country + "-")) {
								filtered = true;
								break;
							}
						} else if (qViewer.Region === QueryViewerRegion.Continent) {
							switch (qViewer.Continent) {
								case QueryViewerContinent.Africa:
									filtered = !qv.map.IsAfricanCountry(value.toUpperCase());
									break;
								case QueryViewerContinent.Asia:
									filtered = !qv.map.IsAsianCountry(value.toUpperCase());
									break;
								case QueryViewerContinent.Europe:
									filtered = !qv.map.IsEuropeanCountry(value.toUpperCase());
									break;
								case QueryViewerContinent.NorthAmerica:
									filtered = !qv.map.IsNorthAmericanCountry(value.toUpperCase());
									break;
								case QueryViewerContinent.Oceania:
									filtered = !qv.map.IsOceanianCountry(value.toUpperCase());
									break;
								case QueryViewerContinent.SouthAmerica:
									filtered = !qv.map.IsSouthAmericanCountry(value.toUpperCase());
									break;
								default:
									filtered = true;
									break;
							}
						}
					}
				}
			}
			return filtered;
		}

		function XAxisDataTypeOK(qViewer) {
			var dataType = qv.util.XAxisDataType(qViewer);
			var dataTypeOK;
			var errCode;
			switch (qViewer.RealType) {
				case QueryViewerOutputType.Chart:
					dataTypeOK = qv.chart.IsDatetimeXAxis(qViewer) ? dataType == QueryViewerDataType.Date || dataType == QueryViewerDataType.DateTime : true;
					errCode = "GXPL_QViewerNoDatetimeAxis";
					break;
				case QueryViewerOutputType.Map:
					dataTypeOK = (dataType == QueryViewerDataType.GeoPoint || dataType == QueryViewerDataType.Character);
					errCode = "GXPL_QViewerNoMapAxis";
					break;
				default:
					dataTypeOK = true;
					break;
			}
			return { IsOK: dataTypeOK, Error: dataTypeOK ? "" : gx.getMessage(errCode) };
		}

		function NormalizeTargetAndMaximumValues(serie) {
			if (serie.TargetValue <= 0)
				serie.TargetValue = 100;
			if (serie.MaximumValue <= 0)
				serie.MaximumValue = 100;
			if (serie.MaximumValue < serie.TargetValue)
				serie.MaximumValue = serie.TargetValue;
		}

		function aggregatePoints(chartSerie) {
			var currentYValues = [];
			var currentYQuantities = [];
			var firstColor = "";
			for (var i = 0; i < chartSerie.Points.length; i++) {
				var yValue;
				var yQuantity;
				if (chartSerie.Aggregation == QueryViewerAggregationType.Count) {
					yValue = 0;		// No se utiliza
					yQuantity = parseFloat(qv.util.trim(chartSerie.Points[i].Value));
				}
				else {
					if (chartSerie.Aggregation == QueryViewerAggregationType.Average) {
						yValue = parseFloat(qv.util.trim(chartSerie.Points[i].Value_N));
						yQuantity = parseFloat(qv.util.trim(chartSerie.Points[i].Value_D));
					}
					else {
						yValue = parseFloat(qv.util.trim(chartSerie.Points[i].Value));
						yQuantity = 1;
					}
				}
				currentYValues.push(yValue);
				currentYQuantities.push(yQuantity);
				if (firstColor == "") firstColor = chartSerie.Points[i].Color;
			}
			var value = qv.util.aggregate(chartSerie.Aggregation, currentYValues, currentYQuantities).toString();
			chartSerie.Points = [{ Value: value, Value_N: value, Value_D: "1", Color: firstColor }];
			chartSerie.NegativeValues = value < 0;
			chartSerie.PositiveValues = value > 0;
		}

		function CalculateColorAxis(qViewer, datum) {

			qViewer.Chart.colorAxis = qViewer.Chart.colorAxis || {};
			qViewer.Chart.colorAxis.dataClasses = qViewer.Chart.colorAxis.dataClasses || [];

			for (var j = 0; j < datum.ConditionalStyles.length; j++) {

				var conditionalStyle = datum.ConditionalStyles[j];
				colorAxis = {};
				colorAxis.dataClasses = [];
				var dataclasses = {};
				dataclasses.color = conditionalStyle.StyleOrClass.replace("color:", "");

				if (conditionalStyle.Operator == QueryViewerConditionOperator.Interval) {

					dataclasses.from = parseFloat(conditionalStyle.Value1);
					dataclasses.to = parseFloat(conditionalStyle.Value2);
					dataclasses.Operator = QueryViewerConditionOperatorSymbol.Interval;

				} else if (conditionalStyle.Operator == QueryViewerConditionOperator.Equal) {

					dataclasses.from = parseFloat(conditionalStyle.Value1);
					dataclasses.Operator = QueryViewerConditionOperatorSymbol.Equal;

				} else if (conditionalStyle.Operator == QueryViewerConditionOperator.GreaterOrEqual) {

					dataclasses.from = parseFloat(conditionalStyle.Value1);
					dataclasses.Operator = QueryViewerConditionOperatorSymbol.GreaterOrEqual;

				} else if (conditionalStyle.Operator == QueryViewerConditionOperator.GreaterThan) {

					dataclasses.from = parseFloat(conditionalStyle.Value1);
					dataclasses.Operator = QueryViewerConditionOperatorSymbol.GreaterThan;

				} else if (conditionalStyle.Operator == QueryViewerConditionOperator.LessThan) {

					dataclasses.to = parseFloat(conditionalStyle.Value1);
					dataclasses.Operator = QueryViewerConditionOperatorSymbol.LessThan;

				} else if (conditionalStyle.Operator == QueryViewerConditionOperator.LessOrEqual) {

					dataclasses.to = parseFloat(conditionalStyle.Value1);
					dataclasses.Operator = QueryViewerConditionOperatorSymbol.LessOrEqual;

				}
				else if (conditionalStyle.Operator == QueryViewerConditionOperator.NotEqual) {

					dataclasses.from = parseFloat(conditionalStyle.Value1);
					dataclasses.Operator = QueryViewerConditionOperatorSymbol.NotEqual;

				}
				qViewer.Chart.colorAxis.dataClasses.push(dataclasses);
			}
		}

		var xAxisDataTypeStatus = XAxisDataTypeOK(qViewer);
		if (xAxisDataTypeStatus.IsOK) {

			qViewer.Chart = {};

			// Obtengo DataFields de categorias y series
			GetCategoriesAndSeriesDataFields(qViewer);

			// Inicializo categorias
			qViewer.Chart.Categories.MinValue = null;
			qViewer.Chart.Categories.MaxValue = null;
			qViewer.Chart.Categories.Values = [];
			var axesByDataField = GetAxesByDataFieldObj(qViewer);

			// Inicializo series
			qViewer.Chart.Series.ByIndex = [];
			var uniqueAxis = qViewer.Chart.Categories.DataFields.length == 1 ? qv.util.GetAxisByDataField(qViewer, qViewer.Chart.Categories.DataFields[0]) : null;
			var dataByDataField = GetDataByDataFieldObj(qViewer, uniqueAxis);
			qViewer.Chart.PlotBands = [];
			for (var i = 0; i < qViewer.Chart.Series.DataFields.length; i++) {
				var dataField = qViewer.Chart.Series.DataFields[i];
				var datum = dataByDataField[dataField].Datum;
				var serie = {};
				serie.MinValue = null;		// Minimum value for the serie from the dataset
				serie.MaxValue = null;		// Maximum value for the serie from the dataset
				var multicoloredSerie = dataByDataField[dataField].Multicolored;
				serie.FieldName = datum.Name;					// Nombre del field correspondiente a serie
				serie.Name = datum.Title;
				serie.Visible = datum.Visible;
				serie.DataType = datum.DataType;
				serie.Aggregation = datum.Aggregation;
				var picture = datum.Picture;
				serie.Picture = (picture == "" ? (serie.DataType == QueryViewerDataType.Integer ? "ZZZZZZZZZZZZZZ9" : "ZZZZZZZZZZZZZZ9.99") : picture);
				serie.NumberFormat = qv.util.ParseNumericPicture(serie.DataType, serie.Picture);
				if (!multicoloredSerie)
					serie.Color = GetColor(multicoloredSerie, datum, uniqueAxis, i, 0, "", 0);
				else
					serie.Color = qv.util.GetNullColor();
				serie.TargetValue = datum.TargetValue;
				serie.MaximumValue = datum.MaximumValue;	// MaximumValue property value (not the maximum value for the serie from the dataset)
				NormalizeTargetAndMaximumValues(serie);
				serie.PositiveValues = false;
				serie.NegativeValues = false;
				serie.Points = [];
				qViewer.Chart.Series.ByIndex.push(serie);
				// Si el dato tiene estilos condicionales, agrego las PlotBands correspondientes
				if (qViewer.RealType == QueryViewerOutputType.Chart)
					CalculatePlotBands(qViewer, datum);
				// Calculo colores segun los ConditionalStyles para las leyendas del mapa
				if (qViewer.RealType == QueryViewerOutputType.Map)
					CalculateColorAxis(qViewer, datum);
			}

			// Recorro valores y lleno categorías y series
			var valueIndex = 0;
			for (var i = 0; i < qViewer.Data.Rows.length; i++) {
				var row = qViewer.Data.Rows[i];
				if (!IsFilteredRow(qViewer, row)) {
					AddCategoryValue(qViewer, row, valueIndex, axesByDataField);
					AddSeriesValues(qViewer, row, valueIndex, dataByDataField, uniqueAxis);
					valueIndex++;
				}
			}

			if (qViewer.RealType == QueryViewerOutputType.Chart && qv.chart.IsGaugeChart(qViewer))
				for (var i = 0; i < qViewer.Chart.Series.DataFields.length; i++) {
					var serie = qViewer.Chart.Series.ByIndex[i];
					aggregatePoints(serie);		// Sólo puede haber un punto por serie para el Gauge
				}

			return "";

		}
		else
			return xAxisDataTypeStatus.Error;
	},

	getTranslation: function (literal) {
		if (qv.TranslationType == QueryViewerTranslationType.RunTime)
			return gx.getMessage(literal);
		else
			return literal;
	},

	getTranslationAlsoIfStatic: function (literal) {		// Hack to get the correct translation in cases where literals are not translated if static translation is specified
		if (qv.TranslationType == QueryViewerTranslationType.RunTime || qv.TranslationType == QueryViewerTranslationType.Static)		
			return gx.getMessage(literal);
		else
			return literal;
	},

	aggregateData: function (data, rows) {

		function aggregateDatum(datum, rows) {
			var currentYValues = [];
			var currentYQuantities = [];
			var variables = [];
			var firstColor = "";
			var noData;
			for (var i = 0; i < rows.length; i++) {
				var row = rows[i];
				if (datum.IsFormula) {
					noData = true;
					var j = 0;
					do {
						j++;
						var value = row[datum.DataField + "_" + j.toString()];
						if (value != undefined) {
							noData = false;
							value = parseFloat(value);
							if (i == 0)
								variables.push(value);
							else
								variables[j-1] += value;
						}
					} while (value != undefined);
				}
				else {
					var yValue;
					var yQuantity;
					noData = false;
					if (datum.Aggregation == QueryViewerAggregationType.Count) {
						if (row[datum.DataField] != undefined) {
							yValue = 0;		// No se utiliza
							yQuantity = parseFloat(row[datum.DataField]);
						}
						else
							noData = true;
					}
					else {
						if (datum.Aggregation == QueryViewerAggregationType.Average) {
							if (row[datum.DataField + "_N"] != undefined && row[datum.DataField + "_D"] != undefined) {
								yValue = parseFloat(row[datum.DataField + "_N"]);
								yQuantity = parseFloat(row[datum.DataField + "_D"]);
							}
							else
								noData = true;
						}
						else {
							if (row[datum.DataField] != undefined) {
								yValue = parseFloat(row[datum.DataField]);
								yQuantity = 1;
							}
							else
								noData = true;
						}
					}
					currentYValues.push(yValue);
					currentYQuantities.push(yQuantity);
				}
			}
			if (noData)
				return "0";
			else if (datum.IsFormula)
				return qv.util.evaluate(datum.Formula, datum.DataField + "_", variables).toString();
			else
				return qv.util.aggregate(datum.Aggregation, currentYValues, currentYQuantities).toString();
		}

		var newRow = {};
		for (var i = 0; i < data.length; i++) {
			var datum = data[i];
			var aggValue = aggregateDatum(datum, rows);
			newRow[datum.DataField] = aggValue;
		}
		return newRow;
	},

	
	isRTL: function (qViewer) {
		var id = qViewer.getContainerControl().id;
		var elem = document.getElementById(id);
		var rtl = false;

		if (window.getComputedStyle)
			cs = window.getComputedStyle(elem, null).getPropertyValue('direction');
		else
			cs = elem.currentStyle.direction;

		if (cs == "rtl")
			rtl = true;

		return rtl;
	}

}
/* END OF FILE - ..\Sources\Util.src.js - */
/* START OF FILE - ..\Sources\Services.src.js - */
var STATE_DONE = 4
var STATUS_OK = 200
var METADATA_VERSION = 2

qv.services = (function () {

	function GetObjectNameFromObjectProperty(propValue) {
		var array = eval(propValue);
		return array[1].replace(/\\/g, ".");
	}

	function MetadataChanged(qViewer, key) {

		function MetadataType(outputType) {
			switch (outputType) {
				case QueryViewerOutputType.Table:
					return "IgnoreType";
				case QueryViewerOutputType.Chart:
				case QueryViewerOutputType.Card:
					return "IgnoreTypeAndAxis";
				default:
					return "IgnoreNot";
			}
		}

		var runtimeFieldsJSON = qv.services.RuntimeFieldsJSON(qViewer);
		var runtimeParametersJSON = qv.services.RuntimeParametersJSON(qViewer);
		var metadataType = MetadataType(qViewer.RealType);
		if (qViewer.ObjectName != key.ObjectName || qViewer.ObjectType != key.ObjectType || qViewer.ObjectId != key.ObjectId || qViewer.Object != key.Object || runtimeFieldsJSON != key.RuntimeFieldsJSON || runtimeParametersJSON != key.RuntimeParametersJSON || metadataType != key.MetadataType) {
			key.ObjectName = qViewer.ObjectName;
			key.ObjectType = qViewer.ObjectType;
			key.ObjectId = qViewer.ObjectId;
			key.Object = qViewer.Object;
			key.RuntimeFieldsJSON = runtimeFieldsJSON;
			key.RuntimeParametersJSON = runtimeParametersJSON;
			key.MetadataType = metadataType;
			return true;
		}
		else
			return false;
	}

	function DataChanged(qViewer, key) {

		function DataType(outputType) {
			if (outputType == QueryViewerOutputType.Table)
				return "PagedRecordSet";
			else if (outputType == QueryViewerOutputType.PivotTable)
				return "PagedLineSet";
			else
				return "NotPaged";
		}

		function GetFieldsJSON(qViewer, fields, keyOrderType) {
			var fieldsStr = SortAscendingForced(qViewer);
			for (var i = 0; i < fields.length; i++) {
				var field = fields[i];
				var orderType = "";
				if (field[keyOrderType] != undefined)
					orderType = field[keyOrderType].Type;
				if (orderType != "") {
					var sdtOrderType = qv.services.postInfo._priv.SdtWithValuesJSON("Order", orderType, QueryViewerAxisOrderType.Custom, field[keyOrderType].Values, false);
					fieldsStr += "," + sdtOrderType;
				}
				if (field["Analytics"] != undefined) {
					fieldsStr += "," + field["Analytics"].ShowValuesAs;
					fieldsStr += "," + field["Analytics"].RollingAverageType;
					fieldsStr += "," + field["Analytics"].RollingAverageTerms;
					fieldsStr += "," + field["Analytics"].DifferenceFrom;
					fieldsStr += "," + field["Analytics"].ShowAsPercentage;
				}
			}
			return fieldsStr;
		}

		var runtimeParametersJSON = qv.services.RuntimeParametersJSON(qViewer);
		var fieldsJSON = GetFieldsJSON(qViewer, qViewer.Axes, "AxisOrder");
		var dataType = DataType(qViewer.RealType);
		if (qViewer.ObjectName != key.ObjectName || qViewer.ObjectType != key.ObjectType || qViewer.ObjectId != key.ObjectId || qViewer.Object != key.Object || runtimeParametersJSON != key.RuntimeParametersJSON || fieldsJSON != key.FieldsJSON || dataType != key.DataType) {
			key.ObjectName = qViewer.ObjectName;
			key.ObjectType = qViewer.ObjectType;
			key.ObjectId = qViewer.ObjectId;
			key.Object = qViewer.Object;
			key.RuntimeParametersJSON = runtimeParametersJSON;
			key.FieldsJSON = fieldsJSON;
			key.DataType = dataType;
			return true;
		}
		else
			return false;
	}

	function DashboardSpecChanged(dViewer, key) {
		if (dViewer.Object) {
			var objectName = GetObjectNameFromObjectProperty(dViewer.Object);
			if (objectName != key.ObjectName) {
				key.ObjectName = objectName;
				return true;
			}
			else
				return false;
		}
		else
			return dViewer.DashboardSpec == "";
	}

	function SortAscendingForced(qViewer) {
		return (qViewer.RealType == QueryViewerOutputType.Chart && qv.chart.IsDatetimeXAxis(qViewer)) || (qViewer.RealType == QueryViewerOutputType.Card && (qViewer.IncludeSparkline || qViewer.IncludeTrend))
	}
	
	function ServicesVersionOK(version) {
		return version == null || parseInt(version) == METADATA_VERSION;		// Se controla que sea distinto de null por la ejecución de consultas a través del API de GXquery, que no devuelven versión por ser servicios más viejos
	}
	
	function ParserResult(success, message) {
		return { Success: success, Message: message};
	}

	return {

		url: (function () {

			function getServiceURL(qViewer, serviceName) {
				var GenType = qv.util.getGenerator();
				var fc = foolCache(); // Para que el explorador no cachee los resultados de los servicios
				var debugSubstr = qViewer.enableServerDebug ? "_debug" : "";
				switch (GenType) {
					case "C#":
						return baseUrl() + "agxpl_get" + debugSubstr + ".aspx?" + serviceName + "," + fc;
					case "Java":
						return GetJavaBaseUrl(false) + "qviewer.services.agxpl_get" + debugSubstr + "?" + serviceName + "," + fc;
					default:
						return "";
				}
			}

			function foolCache() {
				var currentTime = new Date();
				var miliSecs = currentTime.getTime();
				return miliSecs;
			}

			function staticDirectory() {
				var staticDir;
				if (gx.staticDirectory != "")
					staticDir = gx.staticDirectory;
				else
					staticDir = this.getCookie('StaticContent');
				if (qv.util.startsWith(staticDir, "/"))
					return staticDir.substr(1, staticDir.length - 1);
				else
					return staticDir;
			}

			function GetJavaBaseUrl(staticContent) {
				var baseUrl = gx.util.resourceUrl(gx.basePath, true);
				if (staticContent)
					baseUrl += staticDirectory();
				return baseUrl;
			}

			function baseUrl() {
				var url = new gx.util.Url(location.href);
				var path = url.path;
				var pathResult = path.substr(0, path.lastIndexOf('/') + 1);
				if (url.port == "")
					urlresult = url.protocol + "://" + url.host + pathResult;
				else
					urlresult = url.protocol + "://" + url.host + ":" + url.port + pathResult;
				return urlresult;
			}

			return {

				getDefaultOutputURL: function (qViewer) {
					return getServiceURL(qViewer, "defaultoutput");
				},

				getRecordsetCacheKeyURL: function (qViewer) {
					return getServiceURL(qViewer, "recordsetcachekey");
				},

				getMetadataURL: function (qViewer) {
					return getServiceURL(qViewer, "metadata");
				},

				getDataURL: function (qViewer) {
					return getServiceURL(qViewer, "data");
				},

				getAttributeValuesURL: function (qViewer) {
					return getServiceURL(qViewer, "attributevalues");
				},

				getPageDataForTableURL: function (qViewer) {
					return getServiceURL(qViewer, "pagedatafortable");
				},

				getPageDataForPivotTableURL: function (qViewer) {
					return getServiceURL(qViewer, "pagedataforpivottable");
				},

				getQueryParametersURL: function (qViewer) {
					return getServiceURL(qViewer, "queryparameters");
				},

				getDashboardSpecURL: function (qViewer) {
					return getServiceURL(qViewer, "dashboardspec");
				},

				getStaticDirectory: function () {
					if (qv.util.getGenerator() === "Java")
						return GetJavaBaseUrl(true);
					else
						return staticDirectory();
				}
			
			}

		})(),

		postInfo: (function () {

			function RuntimeFieldsJSON(qViewer, encodevaluescollection) {
				var strFields = '';
				var strValues = '';
				var existFields;
				var existValues;
				var picture;
				var targetValue;
				var maximumValue;
				var style;
				var subtotals;
				var CanDragToPages;
				var RaiseItemClick;
				var ShowValuesAs;
				var RollingAverageType;
				var RollingAverageTerms;
				var DifferenceFrom;
				var ShowAsPercentage;
				var orderType;
				var expandCollapseType;
				var filterType;
				existFields = false;
				for (i = 0; qViewer.Axes[i] != undefined; i++) {
					existFields = true;
					strFields += (strFields != '' ? ',' : '');
					strFields += '{';
					picture = '';
					targetValue = 0;
					maximumValue = 0;
					style = '';
					subtotals = '';
					CanDragToPages = true;
					RaiseItemClick = true;
					ShowValuesAs = '';
					RollingAverageType = '';
					RollingAverageTerms = 0;
					DifferenceFrom = '';
					ShowAsPercentage = ''
					orderType = '';
					expandCollapseType = '';
					filterType = '';
					var valuesStyles = ValuesStylesJSON(qViewer.Axes[i]);
					var conditionalStyles = ConditionalStylesJSON(qViewer.Axes[i]);
					var grouping = GroupingJSON(qViewer.Axes[i]);
					if (qViewer.Axes[i].Format != undefined) {
						picture = (qViewer.Axes[i].Format.Picture ? qViewer.Axes[i].Format.Picture : "");
						targetValue = (qViewer.Axes[i].Format.TargetValue ? qViewer.Axes[i].Format.TargetValue : 0);
						maximumValue = (qViewer.Axes[i].Format.MaximumValue ? qViewer.Axes[i].Format.MaximumValue : 0);
						style = (qViewer.Axes[i].Format.Style ? qViewer.Axes[i].Format.Style : "");
						subtotals = (qViewer.Axes[i].Format.Subtotals ? qViewer.Axes[i].Format.Subtotals : "");
						CanDragToPages = (qViewer.Axes[i].Format.CanDragToPages != undefined ? qViewer.Axes[i].Format.CanDragToPages : true);
					}
					if (qViewer.Axes[i].Actions != undefined) {
						RaiseItemClick = qViewer.Axes[i].Actions.RaiseItemClick;
					}
					if (qViewer.Axes[i].Analytics != undefined) {
						ShowValuesAs = qViewer.Axes[i].Analytics.ShowValuesAs;
						RollingAverageType = qViewer.Axes[i].Analytics.RollingAverageType;
						RollingAverageTerms = qViewer.Axes[i].Analytics.RollingAverageTerms;
						DifferenceFrom = qViewer.Axes[i].Analytics.DifferenceFrom;
						ShowAsPercentage = qViewer.Axes[i].Analytics.ShowAsPercentage;
					}
					if (qViewer.Axes[i].AxisOrder != undefined) {
						orderType = qViewer.Axes[i].AxisOrder.Type;
					}
					if (qViewer.Axes[i].ExpandCollapse != undefined) {
						expandCollapseType = qViewer.Axes[i].ExpandCollapse.Type;
					}
					if (qViewer.Axes[i].Filter != undefined) {
						filterType = qViewer.Axes[i].Filter.Type;
					}
					if (filterType == undefined) filterType = QueryViewerFilterType.ShowSomeValues;

					strFields += '"Name":"' + encodeURIComponent(qViewer.Axes[i].Name) + '"';
					strFields += ',';
					strFields += '"Caption":"' + encodeURIComponent(qViewer.Axes[i].Title) + '"';
					strFields += ',';
					strFields += '"Aggregation":"' + qViewer.Axes[i].Aggregation + '"';
					strFields += ',';
					strFields += '"Visible":"' + qViewer.Axes[i].Visible + '"';
					strFields += ',';
					strFields += '"Type":"' + qViewer.Axes[i].Type + '"';
					strFields += ',';
					strFields += '"Axis":"' + qViewer.Axes[i].Axis + '"';
					strFields += ',';
					strFields += '"Picture":"' + encodeURIComponent(picture) + '"';
					strFields += ',';
					strFields += '"TargetValue":' + targetValue;
					strFields += ',';
					strFields += '"MaximumValue":' + maximumValue;
					strFields += ',';
					strFields += '"Style":"' + style + '"';
					strFields += ',';
					strFields += '"Subtotals":"' + subtotals + '"';
					strFields += ',';
					strFields += '"CanDragToPages":' + CanDragToPages;
					strFields += ',';
					strFields += '"RaiseItemClick":' + RaiseItemClick;
					if (ShowValuesAs != '') {
						strFields += ',';
						strFields += '"Analytics":{';
						strFields += '"ShowValuesAs":"' + ShowValuesAs + '"';
						strFields += ',';
						strFields += '"RollingAverageType":"' + RollingAverageType + '"';
						strFields += ',';
						strFields += '"RollingAverageTerms":' + RollingAverageTerms;
						strFields += ',';
						strFields += '"DifferenceFrom":"' + DifferenceFrom + '"';
						strFields += ',';
						strFields += '"ShowAsPercentage":"' + ShowAsPercentage + '"';
						strFields += '}';
					}
					if (orderType != '') {
						var sdtOrderType = SdtWithValuesJSON("Order", orderType, QueryViewerAxisOrderType.Custom, qViewer.Axes[i].AxisOrder.Values, encodevaluescollection);
						strFields += (sdtOrderType != '' ? ',' + sdtOrderType : '');
					}
					if (expandCollapseType != '') {
						var sdtExpandCollapse = SdtWithValuesJSON("ExpandCollapse", expandCollapseType, QueryViewerExpandCollapseType.ExpandSomeValues, qViewer.Axes[i].ExpandCollapse.Values, encodevaluescollection);
						strFields += (sdtExpandCollapse != '' ? ',' + sdtExpandCollapse : '');
					}
					if (filterType != '' && qViewer.Axes[i].Filter.Values) {
						var sdtFilter = SdtWithValuesJSON("Filter", filterType, QueryViewerFilterType.ShowSomeValues, qViewer.Axes[i].Filter.Values, encodevaluescollection);
						strFields += (sdtFilter != '' ? ',' + sdtFilter : '');
					}
					strFields += (valuesStyles != '' ? ',' + valuesStyles : '');
					strFields += (conditionalStyles != '' ? ',' + conditionalStyles : '');
					strFields += (grouping != '' ? ',' + grouping : '');
					strFields += '}';
				}
				if (existFields) strFields = '"RuntimeFields":[' + strFields + "]";
				return strFields;
			}

			function ValuesStylesJSON(axis) {
				var strStyles = '';
				var existStyles = false;
				if (axis.Format != undefined) {
					if (axis.Format.ValuesStyles != undefined) {
						for (var i = 0; axis.Format.ValuesStyles[i] != undefined; i++) {
							existStyles = true;
							strStyles += (strStyles != '' ? ',' : '');
							strStyles += '{';
							strStyles += '"Value":"' + encodeURIComponent(axis.Format.ValuesStyles[i].Value) + '"';
							strStyles += ',';
							strStyles += '"Style":"' + encodeURIComponent(axis.Format.ValuesStyles[i].StyleOrClass) + '"';
							strStyles += ',';
							strStyles += '"Propagate":' + (axis.Format.ValuesStyles[i].ApplyToRowOrColumn ? "true" : "false");
							strStyles += '}';
						}
					}
				}
				if (existStyles) strStyles = '"ValuesStyles":[' + strStyles + ']';
				return strStyles;
			}

			function ConditionalStylesJSON(axis) {
				var strStyles = '';
				var existStyles = false;
				if (axis.Format != undefined) {
					if (axis.Format.ConditionalStyles != undefined) {
						for (var i = 0; axis.Format.ConditionalStyles[i] != undefined; i++) {
							existStyles = true;
							strStyles += (strStyles != '' ? ',' : '');
							strStyles += '{';
							strStyles += '"Operator":"' + axis.Format.ConditionalStyles[i].Operator + '"';
							strStyles += ',';
							strStyles += '"Value1":"' + encodeURIComponent(axis.Format.ConditionalStyles[i].Value1) + '"';
							if (axis.Format.ConditionalStyles[i].Operator == QueryViewerConditionOperator.Interval) {
								strStyles += ',';
								strStyles += '"Value2":"' + encodeURIComponent(axis.Format.ConditionalStyles[i].Value2) + '"';
							}
							strStyles += ',';
							strStyles += '"Style":"' + encodeURIComponent(axis.Format.ConditionalStyles[i].StyleOrClass) + '"';
							strStyles += '}';
						}
					}
				}
				if (existStyles) strStyles = '"ConditionalStyles":[' + strStyles + ']';
				return strStyles;
			}

			function GroupingJSON(axis) {
				var strGrouping = '';
				if (axis.Grouping != undefined) {
					strGrouping += '{';
					strGrouping += '"GroupByYear":' + (axis.Grouping.GroupByYear ? "true" : "false");
					strGrouping += ',';
					strGrouping += '"YearTitle":"' + axis.Grouping.YearTitle + '"';
					strGrouping += ',';
					strGrouping += '"GroupBySemester":' + (axis.Grouping.GroupBySemester ? "true" : "false");
					strGrouping += ',';
					strGrouping += '"SemesterTitle":"' + axis.Grouping.SemesterTitle + '"';
					strGrouping += ',';
					strGrouping += '"GroupByQuarter":' + (axis.Grouping.GroupByQuarter ? "true" : "false");
					strGrouping += ',';
					strGrouping += '"QuarterTitle":"' + axis.Grouping.QuarterTitle + '"';
					strGrouping += ',';
					strGrouping += '"GroupByMonth":' + (axis.Grouping.GroupByMonth ? "true" : "false");
					strGrouping += ',';
					strGrouping += '"MonthTitle":"' + axis.Grouping.MonthTitle + '"';
					strGrouping += ',';
					strGrouping += '"GroupByDayOfWeek":' + (axis.Grouping.GroupByDayOfWeek ? "true" : "false");
					strGrouping += ',';
					strGrouping += '"DayOfWeekTitle":"' + axis.Grouping.DayOfWeekTitle + '"';
					strGrouping += ',';
					strGrouping += '"HideValue":' + (axis.Grouping.HideValue ? "true" : "false");
					strGrouping += '}';
					strGrouping = '"Grouping":' + strGrouping;
				}
				return strGrouping;
			}

			function SdtWithValuesJSON(sdtName, actualType, typeWithValues, values, encodevalues) {
				var strAux = '';
				if (actualType != '') {
					strAux += '"' + sdtName + '":';
					strAux += '{';
					strAux += '"Type":"' + actualType + '"';
					strValues = "";
					if (actualType == typeWithValues) {
						existValues = false;
						for (j = 0; values[j] != undefined; j++) {
							existValues = true;
							strValues += (strValues != '' ? ',' : '');
							if (encodevalues) strValues += '"' + encodeURIComponent(values[j]) + '"';
							else strValues += '"' + values[j] + '"';
						}
						if (existValues) strValues = ',' + '"Values":[' + strValues + ']';
					}
					strAux += strValues;
					strAux += '}';
				}
				return strAux;
			}

			function RuntimeParametersJSON(qViewer) {
				var strParameters = '';
				var existParameters = false;

				if (qViewer.Object) {
					var array = eval(qViewer.Object);
					for (i = 2; i < array.length; i++) {
						existParameters = true;
						strParameters += (strParameters != '' ? ',' : '');
						strParameters += '{';
						strParameters += '"Value":"' + encodeURIComponent(array[i]) + '"';
						strParameters += '}';
					}
				}
				else {
					for (i = 0; qViewer.Parameters[i] != undefined; i++) {
						existParameters = true;
						strParameters += (strParameters != '' ? ',' : '');
						strParameters += '{';
						strParameters += '"Name":"' + qViewer.Parameters[i].Name + '"';
						strParameters += ',';
						strParameters += '"Value":"' + encodeURIComponent(qViewer.Parameters[i].Value) + '"';
						strParameters += '}';
					}
				}
				if (existParameters) strParameters = '"RuntimeParameters":[' + strParameters + ']';
				return strParameters;
			}

			function ExpandCollapseJSON(ExpandCollapse) {
				var strExpandCollapse = '';
				var existExpandCollapse = false;
				for (var i = 0; ExpandCollapse[i] != undefined; i++) {
					existExpandCollapse = true;
					strExpandCollapse += (strExpandCollapse != '' ? ',' : '');
					strExpandCollapse += '{';
					strExpandCollapse += '"DataField":"' + ExpandCollapse[i].DataField + '"';
					strExpandCollapse += ',';
					strExpandCollapse += '"NullExpanded":' + ExpandCollapse[i].NullExpanded;
					strExpandedValues = "";
					existValues = false;
					for (var j = 0; ExpandCollapse[i].NotNullValues.Expanded[j] != undefined; j++) {
						existValues = true;
						strExpandedValues += (strExpandedValues != '' ? ',' : '');
						strExpandedValues += '"' + encodeURIComponent(ExpandCollapse[i].NotNullValues.Expanded[j]) + '"';
					}
					if (existValues) strExpandedValues = ',' + '"Expanded":[' + strExpandedValues + ']';
					strCollapsedValues = "";
					existValues = false;
					for (var j = 0; ExpandCollapse[i].NotNullValues.Collapsed[j] != undefined; j++) {
						existValues = true;
						strCollapsedValues += (strCollapsedValues != '' ? ',' : '');
						strCollapsedValues += '"' + encodeURIComponent(ExpandCollapse[i].NotNullValues.Collapsed[j]) + '"';
					}
					if (existValues) strCollapsedValues = ',' + '"Collapsed":[' + strCollapsedValues + ']';
					strExpandCollapse += ',';
					strExpandCollapse += '"NotNullValues":{"DefaultAction":"' + ExpandCollapse[i].NotNullValues.DefaultAction + '"' + strExpandedValues + strCollapsedValues + '}';
					strExpandCollapse += '}';
				}
				if (existExpandCollapse) strExpandCollapse = '"ExpandCollapse":[' + strExpandCollapse + ']';
				return strExpandCollapse;
			}

			function FiltersJSON(Filters) {
				var strFilters = '';
				var existFilters = false;
				for (i = 0; Filters[i] != undefined; i++) {
					existFilters = true;
					strFilters += (strFilters != '' ? ',' : '');
					strFilters += '{';
					strFilters += '"DataField":"' + Filters[i].DataField + '"';
					strFilters += ',';
					strFilters += '"NullIncluded":' + Filters[i].NullIncluded;
					strIncludedValues = "";
					existValues = false;
					for (j = 0; Filters[i].NotNullValues.Included[j] != undefined; j++) {
						existValues = true;
						strIncludedValues += (strIncludedValues != '' ? ',' : '');
						strIncludedValues += '"' + encodeURIComponent(Filters[i].NotNullValues.Included[j]) + '"';
					}
					if (existValues) strIncludedValues = ',' + '"Included":[' + strIncludedValues + ']';
					strExcludedValues = "";
					existValues = false;
					for (j = 0; Filters[i].NotNullValues.Excluded[j] != undefined; j++) {
						existValues = true;
						strExcludedValues += (strExcludedValues != '' ? ',' : '');
						strExcludedValues += '"' + encodeURIComponent(Filters[i].NotNullValues.Excluded[j]) + '"';
					}
					if (existValues) strExcludedValues = ',' + '"Excluded":[' + strExcludedValues + ']';
					strFilters += ',';
					strFilters += '"NotNullValues":{"DefaultAction":"' + Filters[i].NotNullValues.DefaultAction + '"' + strIncludedValues + strExcludedValues + '}';
					strFilters += '}';
				}
				if (existFilters) strFilters = '"Filters":[' + strFilters + ']';
				return strFilters;
			}

			function AxesInfoJSON(AxesInfo) {
				var strAxesInfo = '';
				var existAxesInfo = false;
				for (var i = 0; AxesInfo[i] != undefined; i++) {
					existAxesInfo = true;
					strAxesInfo += (strAxesInfo != '' ? ',' : '');
					strAxesInfo += '{';
					strAxesInfo += '"DataField":"' + AxesInfo[i].DataField + '"';
					strAxesInfo += ',';
					strAxesInfo += '"Visible":' + !AxesInfo[i].Hidden;
					strAxesInfo += ',';
					strAxesInfo += '"Axis":"' + AxesInfo[i].Axis.Type + '"';
					strAxesInfo += ',';
					strAxesInfo += '"Position":' + (qv.util.IsInteger(AxesInfo[i].Axis.Position) ? AxesInfo[i].Axis.Position : 0);
					strAxesInfo += ',';
					strAxesInfo += '"Order":"' + AxesInfo[i].Order + '"';
					strAxesInfo += ',';
					strAxesInfo += '"Subtotals":' + AxesInfo[i].Subtotals;
					strAxesInfo += '}';
				}
				if (existAxesInfo) strAxesInfo = '"AxesInfo":[' + strAxesInfo + ']';
				return strAxesInfo;
			}

			function DataInfoJSON(DataInfo) {
				var strDataInfo = '';
				var existDataInfo = false;
				for (var i = 0; DataInfo[i] != undefined; i++) {
					existDataInfo = true;
					strDataInfo += (strDataInfo != '' ? ',' : '');
					strDataInfo += '{';
					strDataInfo += '"DataField":"' + DataInfo[i].DataField + '"';
					strDataInfo += ',';
					strDataInfo += '"Visible":' + !DataInfo[i].Hidden;
					strDataInfo += ',';
					strDataInfo += '"Position":' + (qv.util.IsInteger(DataInfo[i].Position) ? DataInfo[i].Position : 0);
					strDataInfo += '}';
				}
				if (existDataInfo) strDataInfo = '"DataInfo":[' + strDataInfo + ']';
				return strDataInfo;
			}

			function OrderJSON(DataField, Type) {
				return '{"DataField":"' + DataField + '","Type":"' + Type + '"}';
			}

			function RecordsetCacheInfoJSON(qViewer) {
				if (qViewer.UseRecordsetCache)
					return '{"ActualKey":"' + qViewer.RecordsetCache.ActualKey + '","OldKey":"' + qViewer.RecordsetCache.OldKey + '","MinutesToKeep":' + qViewer.MinutesToKeepInRecordsetCache + ',"MaximumSize":' + qViewer.MaximumCacheSize + '}';
				else
					return '{"ActualKey":"","OldKey":"","MinutesToKeep":0,"MaximumSize":0}';
			}

			function getObjectBasicInfo(qViewer) {
				var str = "";
				str += (qViewer.ApplicationNamespace != '' ? '"ApplicationNamespace":"' + qViewer.ApplicationNamespace + '"' + ',' : '');
				str += '"ParentPanel":"' + qViewer.ParentPanel + '"';
				str += ',';
				if (qViewer.Object)
					str += '"ObjectName":"' + GetObjectNameFromObjectProperty(qViewer.Object) + '"';
				else {
					str += '"ObjectName":"' + qViewer.ObjectName + '"';
					str += ',';
					str += '"Alt_ObjectType":"' + qViewer.ObjectType + '"';
					str += ',';
					str += '"Alt_ObjectId":' + qViewer.ObjectId;
				}
				return str;
			}

			return {

				DefaultOutput: function (qViewer) {
					var str = "";
					str += '{';
					str += getObjectBasicInfo(qViewer);
					str += '}';
					return "Data=" + encodeURIComponent(str);
				},

				RecordsetCacheKey: function (qViewer) {
					var str = "";
					str += '{';
					str += getObjectBasicInfo(qViewer);
					str += '}';
					return "Data=" + encodeURIComponent(str);
				},

				Metadata: function (qViewer) {
					var str = "";
					var runtimeParametersJSON = RuntimeParametersJSON(qViewer);
					var runtimeFieldsJSON = RuntimeFieldsJSON(qViewer, true);
					str += '{';
					str += getObjectBasicInfo(qViewer);
					str += (qViewer.AppSettings != '' ? ',' + '"AppSettings":' + qViewer.AppSettings : '');
					str += (runtimeParametersJSON != '' ? ',' + runtimeParametersJSON : '');
					str += (runtimeFieldsJSON != '' ? ',' + runtimeFieldsJSON : '');
					str += ',';
					str += '"OutputType":"' + qViewer.RealType + '"';
					str += ',';
					str += '"AllowElementsOrderChange":' + qViewer.AllowElementsOrderChange;
					str += ',';
					str += '"RememberLayout":' + qViewer.RememberLayout;
					str += ',';
					str += '"ShowDataLabelsIn":"' + qViewer.ShowDataLabelsIn + '"';
					str += ',';
					str += '"RecordsetCacheInfo":' + RecordsetCacheInfoJSON(qViewer);
					str += ',';
					str += '"ReturnSampleData":' + qViewer.ReturnSampleData;
					str += ',';
					str += '"TranslationType":"' + qViewer.TranslationType + '"';
					str += '}';
					return "Data=" + encodeURIComponent(str);
				},

				Data: function (qViewer) {
					var str = "";
					var runtimeParametersJSON = RuntimeParametersJSON(qViewer);
					var runtimeFieldsJSON = RuntimeFieldsJSON(qViewer, true);
					str += '{';
					str += getObjectBasicInfo(qViewer);
					str += (qViewer.AppSettings != '' ? ',' + '"AppSettings":' + qViewer.AppSettings : '');
					str += (runtimeParametersJSON != '' ? ',' + runtimeParametersJSON : '');
					str += (runtimeFieldsJSON != '' ? ',' + runtimeFieldsJSON : '');
					str += ',';
					str += '"OutputType":"' + qViewer.RealType + '"';
					str += ',';
					str += '"SortAscendingForced":' + SortAscendingForced(qViewer);
					str += ',';
					str += '"AllowElementsOrderChange":' + qViewer.AllowElementsOrderChange;
					str += ',';
					str += '"RecordsetCacheInfo":' + RecordsetCacheInfoJSON(qViewer);
					str += ',';
					str += '"ReturnSampleData":' + qViewer.ReturnSampleData;
					str += ',';
					str += '"TranslationType":"' + qViewer.TranslationType + '"';
					str += '}';
					return "Data=" + encodeURIComponent(str);
				},

				AttributeValues: function (qViewer, DataField, PageNumber, PageSize, Filter) {
					var str = "";
					var runtimeParametersJSON = RuntimeParametersJSON(qViewer);
					var runtimeFieldsJSON = RuntimeFieldsJSON(qViewer, true);
					str += '{';
					str += getObjectBasicInfo(qViewer);
					str += ',';
					str += '"DataField":"' + DataField + '"';
					str += ',';
					str += '"PageNumber":' + PageNumber;
					str += ',';
					str += '"PageSize":' + PageSize;
					str += ',';
					str += '"Filter":"' + Filter + '"';
					str += (qViewer.AppSettings != '' ? ',' + '"AppSettings":' + qViewer.AppSettings : '');
					str += (runtimeParametersJSON != '' ? ',' + runtimeParametersJSON : '');
					str += (runtimeFieldsJSON != '' ? ',' + runtimeFieldsJSON : '');
					str += ',';
					str += '"OutputType":"' + qViewer.RealType + '"';
					str += ',';
					str += '"AllowElementsOrderChange":' + qViewer.AllowElementsOrderChange;
					str += ',';
					str += '"RecordsetCacheInfo":' + RecordsetCacheInfoJSON(qViewer);
					str += ',';
					str += '"ReturnSampleData":' + qViewer.ReturnSampleData;
					str += ',';
					str += '"TranslationType":"' + qViewer.TranslationType + '"';
					str += '}';
					return "Data=" + encodeURIComponent(str);
				},

				TablePageData: function (qViewer, PageNumber, PageSize, ReturnTotPages, DataFieldOrder, OrderType, Filters, LayoutChanged) {
					var str = "";
					var runtimeParametersJSON = RuntimeParametersJSON(qViewer);
					var runtimeFieldsJSON = RuntimeFieldsJSON(qViewer, true);
					var filtersJSON = FiltersJSON(Filters);
					str += '{';
					str += getObjectBasicInfo(qViewer);
					str += ',';
					str += '"PageNumber":' + PageNumber;
					str += ',';
					str += '"PageSize":' + (gx.lang.gxBoolean(qViewer.Paging) ? PageSize : 0);
					str += ',';
					str += '"ReturnTotPages":' + ReturnTotPages;
					str += ',';
					str += '"Order":' + OrderJSON(DataFieldOrder, OrderType);
					str += (filtersJSON != '' ? ',' + filtersJSON : '');
					str += (qViewer.AppSettings != '' ? ',' + '"AppSettings":' + qViewer.AppSettings : '');
					str += (runtimeParametersJSON != '' ? ',' + runtimeParametersJSON : '');
					str += (runtimeFieldsJSON != '' ? ',' + runtimeFieldsJSON : '');
					str += ',';
					str += '"AllowElementsOrderChange":' + qViewer.AllowElementsOrderChange;
					str += ',';
					str += '"RecordsetCacheInfo":' + RecordsetCacheInfoJSON(qViewer);
					str += ',';
					str += '"LayoutChanged":' + LayoutChanged;
					str += ',';
					str += '"ReturnSampleData":' + qViewer.ReturnSampleData;
					str += ',';
					str += '"TranslationType":"' + qViewer.TranslationType + '"';
					str += '}';
					return "Data=" + encodeURIComponent(str);
				},

				PivotTablePageData: function (qViewer, PageNumber, PageSize, ReturnTotPages, AxesInfo, DataInfo, Filters, ExpandCollapse, LayoutChanged) {
					var str = "";
					var runtimeParametersJSON = RuntimeParametersJSON(qViewer);
					var runtimeFieldsJSON = RuntimeFieldsJSON(qViewer, true);
					var axesInfoJSON = AxesInfoJSON(AxesInfo);
					var dataInfoJSON = DataInfoJSON(DataInfo);
					var filtersJSON = FiltersJSON(Filters);
					var expandCollapseJSON = ExpandCollapseJSON(ExpandCollapse);
					str += '{';
					str += getObjectBasicInfo(qViewer);
					str += ',';
					str += '"PageNumber":' + PageNumber;
					str += ',';
					str += '"PageSize":' + (gx.lang.gxBoolean(qViewer.Paging) ? PageSize : 0);
					str += ',';
					str += '"ReturnTotPages":' + ReturnTotPages;
					str += ',';
					str += '"ShowDataLabelsIn":"' + qViewer.ShowDataLabelsIn + '"';
					str += ',';
					str += '"TotalForRows":"' + qViewer.TotalForRows + '"';
					str += ',';
					str += '"TotalForColumns":"' + qViewer.TotalForColumns + '"';
					str += (axesInfoJSON != '' ? ',' + axesInfoJSON : '');
					str += (dataInfoJSON != '' ? ',' + dataInfoJSON : '');
					str += (filtersJSON != '' ? ',' + filtersJSON : '');
					str += (expandCollapseJSON != '' ? ',' + expandCollapseJSON : '');
					str += (qViewer.AppSettings != '' ? ',' + '"AppSettings":' + qViewer.AppSettings : '');
					str += (runtimeParametersJSON != '' ? ',' + runtimeParametersJSON : '');
					str += (runtimeFieldsJSON != '' ? ',' + runtimeFieldsJSON : '');
					str += ',';
					str += '"AllowElementsOrderChange":' + qViewer.AllowElementsOrderChange;
					str += ',';
					str += '"RecordsetCacheInfo":' + RecordsetCacheInfoJSON(qViewer);
					str += ',';
					str += '"LayoutChanged":' + LayoutChanged;
					str += ',';
					str += '"ReturnSampleData":' + qViewer.ReturnSampleData;
					str += ',';
					str += '"TranslationType":"' + qViewer.TranslationType + '"';
					str += '}';
					return "Data=" + encodeURIComponent(str);
				},

				getQueryParameters: function (qViewer) {
					var str = "";
					str += '{';
					str += getObjectBasicInfo(qViewer);
					str += '}';
					return "Data=" + encodeURIComponent(str);
				},

				DashboardSpec: function (dViewer) {
					var objectName = "";
					if (dViewer.Object)
						objectName = GetObjectNameFromObjectProperty(dViewer.Object);
					var postInfo = { ApplicationNamespace: dViewer.ApplicationNamespace, ObjectName: objectName, Alt_ObjectId: 0 };
					var postInfoStr = JSON.stringify(postInfo);
					return "Data=" + encodeURIComponent(postInfoStr);
				},

				_priv: {

					RuntimeParametersJSON: function (qViewer) {
						return RuntimeParametersJSON(qViewer)
					},

					RuntimeFieldsJSON: function (qViewer) {
						return RuntimeFieldsJSON(qViewer)
					},

					SdtWithValuesJSON: function (sdtName, actualType, typeWithValues, values, encodevalues) {
						return SdtWithValuesJSON(sdtName, actualType, typeWithValues, values, encodevalues);
					}

				}

			}

		})(),

		RuntimeParametersJSON: function (qViewer) {
			return this.postInfo._priv.RuntimeParametersJSON(qViewer);
		},

		RuntimeFieldsJSON: function (qViewer, encodevaluescollection) {
			return this.postInfo._priv.RuntimeFieldsJSON(qViewer, encodevaluescollection);
		},

		getXMLHttpRequest: function () {
			if (window.XMLHttpRequest) {
				return new window.XMLHttpRequest;
			} else {
				try {
					return new ActiveXObject("MSXML2.XMLHTTP.3.0");
				} catch (ex) {
					return null;
				}
			}
		},

		CallServerSync: function (qViewer, serviceUrlFn, postInfoFn, postInfoParms) {
			postInfoParms = postInfoParms || [];
			postInfoParms.unshift(qViewer);
			var src = serviceUrlFn.call(qv.services.url, qViewer);
			var postInfo = postInfoFn.apply(qv.services.postInfo, postInfoParms);
			var xmlHttp = qv.services.getXMLHttpRequest();
			xmlHttp.open("POST", src, false); // sync
			xmlHttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
			xmlHttp.send(postInfo);
			return xmlHttp.responseText;
		},

		createAsyncServerCallFn: function (qViewer, serviceUrlFn, postInfoFn, externalQueryMember, responsePreProcessFn) {
			return function (callback, postInfoParms) {
				postInfoParms = postInfoParms || [];
				postInfoParms.unshift(qViewer);
				var responseFn = function (response) {
					if (responsePreProcessFn && qViewer.RealType != QueryViewerOutputType.Card) {
						response = responsePreProcessFn.call(qv.util.css, response);
					}
					callback(response, qViewer);
				};
				if (!gx.lang.gxBoolean(qViewer.IsExternalQuery)) {
					var src = serviceUrlFn.call(qv.services.url, qViewer)
					var	postInfo = postInfoFn.apply(qv.services.postInfo, postInfoParms)
					var	xmlHttp = qv.services.getXMLHttpRequest()
					var	responseHandler = function () {
							if (xmlHttp.readyState == STATE_DONE && xmlHttp.status == STATUS_OK) {
								responseFn(xmlHttp.responseText);
							}
						};
					if (gx.util.browser.isIE())
						xmlHttp.onreadystatechange = responseHandler;
					else
						xmlHttp.onload = responseHandler;
					xmlHttp.open("POST", src); // async
					xmlHttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
					xmlHttp.send(postInfo);
				}
				else
					responseFn(qViewer.ExternalQueryResultObj()[externalQueryMember]);
			}
		},

		parseRecordsetCacheKeyXML: function (qViewer) {
			if (qViewer.xml.recordsetCacheKey != "") {
				qViewer.RecordsetCache = qViewer.RecordsetCache || {};
				qViewer.RecordsetCache.OldKey = (qViewer.RecordsetCache.ActualKey ? qViewer.RecordsetCache.ActualKey : "");
				qViewer.RecordsetCache.ActualKey = qViewer.xml.recordsetCacheKey;	// Es un texto plano, no un XML que haya que parsear
			}
		},

		parseDataXML: function (qViewer) {
			if (qViewer.xml.data != "") {
				var xmlDoc = qv.util.dom.xmlDocument(qViewer.xml.data);
				var rootElement = qv.util.dom.getSingleElementByTagName(xmlDoc, "Recordset");
				qViewer.Data = qViewer.Data || {};
				var rows;
				if (!gx.util.browser.isIE()) {
					rows = qv.util.dom.getMultipleElementsByTagName(rootElement, "Record");
				} else {
					rows = qv.util.dom.getMultipleElementsByTagName(qv.util.dom.getSingleElementByTagName(rootElement, "Page"), "Record");
				}
				qViewer.Data.Rows = [];
				for (var i = 0; i < rows.length; i++) {
					var row = {};
					for (var j = 0; j < rows[i].childNodes.length; j++) {
						var node = rows[i].childNodes[j];
						if (node.nodeType == 1) {
							var name = node.nodeName;
							var value = (node.childNodes.length == 1 ? node.childNodes[0].nodeValue : "");
							row[name] = value;
						}
					}
					qViewer.Data.Rows.push(row);
				}
			}
		},

		parseMetadataXML: function (qViewer) {

			function translateStyleOperator(op1, op2) {
				if (op1 == "greaterequal" && op2 == "lessequal")
					return QueryViewerConditionOperator.Interval;
				else
					switch (op1) {
						case "equal":
							return QueryViewerConditionOperator.Equal;
						case "less":
							return QueryViewerConditionOperator.LessThan;
						case "greater":
							return QueryViewerConditionOperator.GreaterThan;
						case "lessequal":
							return QueryViewerConditionOperator.LessOrEqual;
						case "greaterequal":
							return QueryViewerConditionOperator.GreaterOrEqual;
						case "notequal":
							return QueryViewerConditionOperator.NotEqual;
					}
			}

			function getValuesGroup(parentElement, groupTag, valueTag, searchTotalValue) {
				var obj = {};
				var groupElement = qv.util.dom.getSingleElementByTagName(parentElement, groupTag);
				if (groupElement != null) {
					obj.GroupFound = true;
					obj.TotalValueFound = false;
					var values = qv.util.dom.getMultipleElementsByTagName(groupElement, valueTag);
					obj.Values = [];
					for (var i = 0; i < values.length; i++) {
						var value = (values[i].firstChild != null ? values[i].firstChild.nodeValue : "");
						if (value == "TOTAL" && searchTotalValue)
							obj.TotalValueFound = true;
						else
							obj.Values.push(value);
					}
				}
				else
					obj.GroupFound = false;
				return obj;
			}

			function removeCSSReplaceMarker(style) {
				var replaceMarker = "gxpl_cssReplace(";
				if (style.indexOf(replaceMarker) == 0) {	// El style es en realidad el nombre de una clase
					var posIni = style.indexOf(replaceMarker);
					var posFin = style.indexOf(")", posIni);
					style = style.substring(posIni + replaceMarker.length, posFin);
				}
				return style;
			}

			function getValuesStyles(parentElement) {
				var valuesStylesElements;
				var parentElement2 = qv.util.dom.getSingleElementByTagName(parentElement, "formatValues");
				if (parentElement2 != null)
					valuesStylesElements = qv.util.dom.getMultipleElementsByTagName(parentElement2, "value");
				else
					valuesStylesElements = [];
				var ValuesStyles = []
				for (var i = 0; i < valuesStylesElements.length; i++) {
					var valueStyle = {};
					valueStyle.Value = qv.util.trim(valuesStylesElements[i].firstChild != null ? valuesStylesElements[i].firstChild.nodeValue : "");
					valueStyle.StyleOrClass = removeCSSReplaceMarker(valuesStylesElements[i].getAttribute("format"));
					valueStyle.ApplyToRowOrColumn = valuesStylesElements[i].getAttribute("recursive") == "yes";
					ValuesStyles.push(valueStyle);
				}
				return ValuesStyles;
			}

			function getConditionalStyles(parentElement) {
				var conditionalStylesElements;
				var parentElement2 = qv.util.dom.getSingleElementByTagName(parentElement, "conditionalFormats");
				if (parentElement2 != null)
					conditionalStylesElements = qv.util.dom.getMultipleElementsByTagName(parentElement2, "rule");
				else
					conditionalStylesElements = [];
				var ConditionalStyles = []
				for (var i = 0; i < conditionalStylesElements.length; i++) {
					var conditionalStyle = {};
					conditionalStyle.Operator = translateStyleOperator(conditionalStylesElements[i].getAttribute("op1"), conditionalStylesElements[i].getAttribute("op2"));
					conditionalStyle.Value1 = parseFloat(conditionalStylesElements[i].getAttribute("value1"));
					if (conditionalStyle.Operator == QueryViewerConditionOperator.Interval)
						conditionalStyle.Value2 = parseFloat(conditionalStylesElements[i].getAttribute("value2"));
					conditionalStyle.StyleOrClass = removeCSSReplaceMarker(conditionalStylesElements[i].getAttribute("format"));
					ConditionalStyles.push(conditionalStyle);
				}
				return ConditionalStyles;
			}

			if (qViewer.xml.metadata != "") {
				var xmlDoc = qv.util.dom.xmlDocument(qViewer.xml.metadata);
				var rootElement = qv.util.dom.getSingleElementByTagName(xmlDoc, "OLAPCube");
				var servicesVersion = rootElement.getAttribute("Version");
				if (ServicesVersionOK(servicesVersion)) {
					qViewer.Metadata = qViewer.Metadata || {};
					// Obtengo propiedades generales
					qViewer.Metadata.TextForNullValues = rootElement.getAttribute("textForNullValues");
					// Obtengo los ejes
					var axes = qv.util.dom.getMultipleElementsByTagName(rootElement, "OLAPDimension");
					qViewer.Metadata.Axes = [];
					for (var i = 0; i < axes.length; i++) {
						var axis = {};
						axis.Name = axes[i].getAttribute("name");
						axis.Title = axes[i].getAttribute("displayName");
						axis.DataField = axes[i].getAttribute("dataField");
						axis.DataType = axes[i].getAttribute("dataType");
						axis.Visible = axes[i].getAttribute("visible");
						axis.Axis = axes[i].getAttribute("axis");
						axis.Picture = axes[i].getAttribute("picture");
						if (axis.Picture == "")
							switch (axis.DataType) {
								case QueryViewerDataType.Integer:
									axis.Picture = "ZZZZZZZZZZZZZZ9";
									break;
								case QueryViewerDataType.Real:
									axis.Picture = "ZZZZZZZZZZZZZZ9.99";
									break;
								case QueryViewerDataType.Date:
									axis.Picture = "99/99/9999";
									break;
								case QueryViewerDataType.DateTime:
									axis.Picture = "99/99/9999 99:99:99";
									break;
								case QueryViewerDataType.GUID:
									axis.Picture = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";
									break;
							}
						axis.CanDragToPages = qv.util.dom.getBooleanAttribute(axes[i], "canDragToPages", true);
						axis.RaiseItemClick = qv.util.dom.getBooleanAttribute(axes[i], "raiseItemClick", true);
						axis.IsComponent = qv.util.dom.getBooleanAttribute(axes[i], "isComponent", false);
						axis.Style = axes[i].getAttribute("format");
						var includeGroup = getValuesGroup(axes[i], "include", "value", true);
						var excludeGroup = getValuesGroup(axes[i], "exclude", "value", true);
						var expandGroup = getValuesGroup(axes[i], "expand", "value", false);
						var customOrderGroup = getValuesGroup(axes[i], "customOrder", "Value", false);
						if (axes[i].getAttribute("summarize") == "no")
							axis.Subtotals = QueryViewerSubtotals.No;
						else {
							if (excludeGroup.GroupFound && excludeGroup.TotalValueFound)
								axis.Subtotals = QueryViewerSubtotals.Hidden;
							else
								axis.Subtotals = QueryViewerSubtotals.Yes;
						}
						axis.Filter = {};
						if (!includeGroup.GroupFound && !excludeGroup.GroupFound) {
							axis.Filter.Type = QueryViewerFilterType.ShowAllValues;
							axis.Filter.Values = [];
						}
						else if (!includeGroup.GroupFound && excludeGroup.GroupFound && excludeGroup.Values.length == 0 & excludeGroup.TotalValueFound) {
							axis.Filter.Type = QueryViewerFilterType.ShowAllValues;
							axis.Filter.Values = [];
						}
						else if (includeGroup.GroupFound && !excludeGroup.GroupFound && includeGroup.Values.length == 0) {
							axis.Filter.Type = QueryViewerFilterType.HideAllValues;
							axis.Filter.Values = [];
						}
						else {
							axis.Filter.Type = QueryViewerFilterType.ShowSomeValues;
							axis.Filter.Values = includeGroup.Values;
						}
						axis.ExpandCollapse = {};
						if (!expandGroup.GroupFound) {
							axis.ExpandCollapse.Type = QueryViewerExpandCollapseType.ExpandAllValues;
							axis.ExpandCollapse.Values = [];
						}
						else if (expandGroup.GroupFound && expandGroup.Values.length == 0) {
							axis.ExpandCollapse.Type = QueryViewerExpandCollapseType.CollapseAllValues;
							axis.ExpandCollapse.Values = [];
						}
						else {
							axis.ExpandCollapse.Type = QueryViewerExpandCollapseType.ExpandSomeValues;
							axis.ExpandCollapse.Values = expandGroup.Values;
						}
						axis.Order = {};
						var order = axes[i].getAttribute("order");
						if (order == null) {
							axis.Order.Type = QueryViewerAxisOrderType.None;
							axis.Order.Values = [];
						}
						else {
							axis.Order.Type = qv.util.capitalize(order);
							if (axis.Order.Type == QueryViewerAxisOrderType.Custom)
								axis.Order.Values = customOrderGroup.Values;
							else
								axis.Order.Values = [];
						}
						axis.ValuesStyles = getValuesStyles(axes[i]);
						qViewer.Metadata.Axes.push(axis);
					}
					// Obtengo los datos
					var data = qv.util.dom.getMultipleElementsByTagName(rootElement, "OLAPMeasure");
					qViewer.Metadata.Data = [];
					for (var i = 0; i < data.length; i++) {
						var datum = {};
						datum.Name = data[i].getAttribute("name");
						datum.Title = data[i].getAttribute("displayName");
						datum.DataField = data[i].getAttribute("dataField");
						datum.Aggregation = data[i].getAttribute("aggregation");
						datum.DataType = data[i].getAttribute("dataType");
						datum.Visible = data[i].getAttribute("visible");
						datum.Picture = data[i].getAttribute("picture");
						datum.RaiseItemClick = qv.util.dom.getBooleanAttribute(data[i], "raiseItemClick", true);
						datum.IsComponent = qv.util.dom.getBooleanAttribute(data[i], "isComponent", false);
						if (datum.Picture == "")
							datum.Picture = datum.DataType == QueryViewerDataType.Integer ? "ZZZZZZZZZZZZZZ9" : "ZZZZZZZZZZZZZZ9.99";
						datum.Aggregation = qv.util.capitalize(datum.Aggregation);
						datum.TargetValue = parseFloat(data[i].getAttribute("targetValue"));
						datum.MaximumValue = parseFloat(data[i].getAttribute("maximumValue"));
						datum.Style = data[i].getAttribute("format");
						if (datum.TargetValue <= 0)
							datum.TargetValue = 100;
						if (datum.MaximumValue <= 0)
							datum.MaximumValue = 100;
						datum.ConditionalStyles = getConditionalStyles(data[i]);
						var formula = qv.util.dom.getCharacterAttribute(data[i], "formula", "");
						datum.IsFormula = formula != "";
						datum.Formula = formula;
						qViewer.Metadata.Data.push(datum);
					}
					qViewer.Metadata.ParserResult = ParserResult(true, "");
				}
				else {
					qViewer.Metadata.ParserResult = ParserResult(false, gx.getMessage("GXPL_QViewerWrongMetadataVersion").replace("{0}", METADATA_VERSION));
				}
			}
		},

		GetDataIfNeeded: function (qViewer, callbackFn) {
			qViewer.Data = qViewer.Data || {};
			qViewer.Data.LastServiceCallKey = qViewer.Data.LastServiceCallKey || {};
			if (qViewer.xml.data == undefined || DataChanged(qViewer, qViewer.Data.LastServiceCallKey) || gx.lang.gxBoolean(qViewer.IsExternalQuery))
				qViewer.calculatePivottableData(callbackFn);
			else
				callbackFn(qViewer.xml.data, qViewer);
		},

		GetMetadataIfNeeded: function (qViewer, callbackFn) {
			qViewer.Metadata = qViewer.Metadata || {};
			qViewer.Metadata.LastServiceCallKey = qViewer.Metadata.LastServiceCallKey || {};
			if (qViewer.xml.metadata == undefined || MetadataChanged(qViewer, qViewer.Metadata.LastServiceCallKey) || gx.lang.gxBoolean(qViewer.IsExternalQuery))
				qViewer.calculatePivottableMetadata(callbackFn);
			else
				callbackFn(qViewer.xml.metadata, qViewer);
		},

		GetDashboardSpecIfNeeded: function (dViewer, callbackFn) {
			dViewer.DashboardSpec = dViewer.DashboardSpec || "";
			dViewer.LastServiceCallKey = dViewer.LastServiceCallKey || {};
			if (dViewer.DashboardSpec == undefined || DashboardSpecChanged(dViewer, dViewer.LastServiceCallKey)) {
				dViewer.LoadingSpec = true;
				dViewer.GetDashboardSpec(callbackFn);
			}
			else
				callbackFn(dViewer.DashboardSpec, dViewer);
		},

		GetRecordsetCacheKeyIfNeeded: function (qViewer, callbackFn) {
			if (qViewer.UseRecordsetCache && !gx.lang.gxBoolean(qViewer.IsExternalQuery)) {
				qViewer.RecordsetCache = qViewer.RecordsetCache || {};
				qViewer.RecordsetCache.LastServiceCallKey = qViewer.RecordsetCache.LastServiceCallKey || {};
				if (qViewer.xml.recordsetCacheKey == undefined || DataChanged(qViewer, qViewer.RecordsetCache.LastServiceCallKey))
					qViewer.getRecordsetCacheKey(callbackFn);
				else
					callbackFn(qViewer.xml.recordsetCacheKey, qViewer);
			}
			else
				callbackFn("", qViewer);
		},

		IsObjectSet: function (qViewer) {
			return qViewer.Object || qViewer.ObjectName != "" || (qViewer.ObjectType != "" && qViewer.ObjectId != 0);
		}

	}

})()

/* END OF FILE - ..\Sources\Services.src.js - */
/* START OF FILE - ..\Sources\PivotTable.src.js - */
qv.pivot = (function () {

	function renderPivotTable(qViewer) {
		var qvClasses = qv.util.GetContainerControlClasses(qViewer);
		if (qvClasses != "")
			qv.util.SetUserControlClass(qViewer, qvClasses);
		var page = qViewer.userControlId() + "_" + qViewer.ObjectName.replace(/,/g, "").replace(/\./g,"") + "_pivot_page";
		qViewer.pivotParams = {};
		qViewer.pivotParams.page = page;
		var content = qViewer.userControlId() + "_" + qViewer.ObjectName.replace(/,/g, "").replace(/\./g,"") + "_pivot_content";
		qViewer.pivotParams.content = content;
		
		
		if ((qViewer._ControlRenderedTo != qViewer.RealType) || (jQuery("#"+content).length == 0)) {
			if ((qViewer._ControlRenderedTo != qViewer.RealType) && (qViewer.RealType == QueryViewerOutputType.PivotTable)) {
				var container = qv.util.dom.getEmptyContainer(qViewer);
				if (qViewer.Title) qv.util.dom.createDiv(container, page.replace("_pivot_page", "_title_div"), "", "", {}, "");
				qv.util.dom.createDiv(container, page, "", "", {}, "");
				qv.util.dom.createDiv(container, content, "", "", {}, "");
			} else {
				if (qViewer.Title) jQuery("#"+qViewer.ContainerName).find(".pivot_title_div").attr("id",page.replace("_pivot_page", "_title_div"))
				jQuery("#"+qViewer.ContainerName).find(".pivot_filter_div").attr("id",page)
				jQuery("#"+qViewer.ContainerName).find(".conteiner_table_div").attr("id",content)
			}
		}

		qViewer.pivotParams.container = qViewer.getContainerControl();
		qViewer.pivotParams.RealType = qViewer.RealType;
		qViewer.pivotParams.ObjectName = qViewer.ObjectName;
		qViewer.pivotParams.ControlName = qViewer.ControlName;
		qViewer.pivotParams.PageSize = ((qViewer.Paging) && (qViewer.Paging != "false")) ? qViewer.PageSize : undefined;
		qViewer.pivotParams.metadata = qViewer.xml.metadata;
		var data;
		if (gx.lang.gxBoolean(qViewer.IsExternalQuery))
			data = qViewer.xml.data;
		else
			if (qViewer.RealType == QueryViewerOutputType.Table)
				data = qViewer.ServerPagingForTable ? qViewer.xml.pageData : qViewer.xml.data;
			else
				data = qViewer.ServerPagingForPivotTable ? qViewer.xml.pageData : qViewer.xml.data;
		qViewer.pivotParams.data = data;
		qViewer.pivotParams.UcId = qViewer.userControlId();
		qViewer.pivotParams.AutoResize = gx.lang.gxBoolean(qViewer.AutoResize) || gx.lang.gxBoolean(qViewer.ShrinkToFit);	// Property ShrinkToFit deprecated in GX16U3 (Issue 72724)
		qViewer.pivotParams.DisableColumnSort = qViewer.DisableColumnSort;
		qViewer.pivotParams.RememberLayout = qViewer.RememberLayout;
		qViewer.pivotParams.ShowDataLabelsIn = qViewer.ShowDataLabelsIn;
		qViewer.pivotParams.ServerPaging = qViewer.ServerPagingForTable && (!gx.lang.gxBoolean(qViewer.IsExternalQuery));
		qViewer.pivotParams.ServerPagingPivot = qViewer.ServerPagingForPivotTable && (!gx.lang.gxBoolean(qViewer.IsExternalQuery));;
		qViewer.pivotParams.ServerPagingCacheSize = 0
		qViewer.pivotParams.UseRecordsetCache = qViewer.UseRecordsetCache && !gx.lang.gxBoolean(qViewer.IsExternalQuery);
		qViewer.pivotParams.AllowSelection = qViewer.AllowSelection;
		qViewer.pivotParams.SelectLine = true;
		qViewer.pivotParams.TotalForColumns = qViewer.TotalForColumns; 
		qViewer.pivotParams.TotalForRows = qViewer.TotalForRows;
		qViewer.pivotParams.Title = qv.util.getTranslation(qViewer.Title);
		if (OAT.Loader != undefined) {
			renderJSPivot(qViewer.pivotParams, qv.collection, qViewer);
		} else {
			OAT.Loader.addListener(function () {
				renderJSPivot(qViewer.pivotParams, qv.collection, qViewer);
			});
		}
		qViewer._ControlRenderedTo = qViewer.RealType;
		if (qViewer.RealType == QueryViewerOutputType.Table)
			qv.util.hideActivityIndicator(qViewer);
	}

	function callServiceGetPageDataForTable(qViewer, t1, t2) {
		var DataFieldOrder = "";
		var OrderType = "";
		for (var i = 0; i < qViewer.Metadata.Axes.length; i++)
		{
			var axis = qViewer.Metadata.Axes[i];
			if (axis.Order.Type == QueryViewerAxisOrderType.Ascending || axis.Order.Type == QueryViewerAxisOrderType.Descending)
			{
				DataFieldOrder = axis.DataField;
				OrderType = axis.Order.Type;
				break;
			}
		}
		qViewer.getPageDataForTable(function (resXML, qViewer) {
			var d3 = new Date();
			var t3 = d3.getTime();
			if (!qv.util.anyError(resXML)) {
				if (resXML != "")
					qViewer.xml.pageData = resXML;
				renderPivotTable(qViewer);
			} else {
				errMsg = qv.util.getErrorFromText(resXML);
				qv.util.renderError(qViewer, errMsg);
			}
		}, [1, qViewer.PageSize, true, DataFieldOrder, OrderType, [], false]);
	}

	function getComponentItems(qViewer) {
		var componentItems = [];
		for (var i = 0; i < qViewer.Metadata.Axes.length; i++)
			if (qViewer.Metadata.Axes[i].IsComponent)
				componentItems.push(qViewer.Metadata.Axes[i].Name);
		for (var i = 0; i < qViewer.Metadata.Data.length; i++)
			if (qViewer.Metadata.Data[i].IsComponent)
				componentItems.push(qViewer.Metadata.Data[i].Name);
		return componentItems;
	}

	function loadContextItems(Node, excludedItems) {
		var Items = [];
		if (Node != null) {
			var itemIndex = -1;
			for (var i = 0; i < Node.childNodes.length; i++) {
				if (Node.childNodes[i].nodeName == "ITEM") {
					var itemName = Node.childNodes[i].getAttribute("name");
					if (excludedItems.indexOf(itemName) < 0) {
						itemIndex++;
						Items[itemIndex] = {};
						Items[itemIndex].Name = itemName;
						Items[itemIndex].Values = [];
						var valueIndex = -1;
						// Seek VALUES node
						var valuesNode = Node.childNodes[i]; // ITEM
						for (var j = 0; j < Node.childNodes[i].childNodes.length; j++)
							if (Node.childNodes[i].childNodes[j].nodeName == "VALUES") {
								valuesNode = Node.childNodes[i].childNodes[j];
								break;
							}
						// Seek VALUE nodes
						for (var j = 0; j < valuesNode.childNodes.length; j++)
							if (valuesNode.childNodes[j].nodeName == "VALUE") {
								valueIndex++;
								Items[itemIndex].Values[valueIndex] = (valuesNode.childNodes[j].firstChild != null ? valuesNode.childNodes[j].firstChild.nodeValue : "");
							}
					}
				}
			}
		}
		return Items;
	}

	return {

		tryToRenderPivotTable: function (qViewer) {
			var errMsg = "";

			// Ejecuto el primer servicio y verifico que no haya habido error
			var d1 = new Date();
			var t1 = d1.getTime();

			qViewer.xml = qViewer.xml || {};

			qv.services.GetRecordsetCacheKeyIfNeeded(qViewer, function (resText, qViewer) {				// Servicio GetRecordsetCacheKey
				var newRecordsetCacheKey = false;
				if (resText != qViewer.xml.recordsetCacheKey) {
					qViewer.xml.recordsetCacheKey = resText;
					newRecordsetCacheKey = true;
				}
				if (!qv.util.anyError(resText)) {
					if (newRecordsetCacheKey)
						qv.services.parseRecordsetCacheKeyXML(qViewer);

					qv.services.GetMetadataIfNeeded(qViewer, function (resText, qViewer) {				// Servicio GetMetadata
						var newMetadata = false;
						if (resText != qViewer.xml.metadata) {
							qViewer.xml.metadata = resText;
							newMetadata = true;
						}
						var d2 = new Date();
						var t2 = d2.getTime();
						if (!qv.util.anyError(resText)) {
							if (newMetadata)
								qv.services.parseMetadataXML(qViewer);
								
							if (qViewer.Metadata.ParserResult.Success) {
								if ((qViewer.ServerPagingForTable) && (qViewer.RealType == QueryViewerOutputType.Table) && (!gx.lang.gxBoolean(qViewer.IsExternalQuery))) {
									// Tabla con paginado en el server
									var previusStateSave = false;
									if (OAT.getStateWhenServingPaging) {
										previusStateSave = OAT.getStateWhenServingPaging(qViewer.userControlId() + '_' + qViewer.ObjectName, qViewer.ObjectName)
									}
									if ((!previusStateSave) || (!qViewer.RememberLayout)) {
											callServiceGetPageDataForTable(qViewer, t1, t2);
									} else {
										renderPivotTable(qViewer);
									}
								}
								else if ((qViewer.ServerPagingForPivotTable) && (qViewer.RealType == QueryViewerOutputType.PivotTable) && (!gx.lang.gxBoolean(qViewer.IsExternalQuery))) {
									// PivotTable con paginado en el server
									var previusStateSave = false;
									if (OAT.getStateWhenServingPaging) {
										previusStateSave = OAT.getStateWhenServingPaging(qViewer.userControlId() + '_' + qViewer.ObjectName, qViewer.ObjectName)
									}
									renderPivotTable(qViewer);
								}
								else {
									// Paginado en el cliente
									qv.services.GetDataIfNeeded(qViewer, function (resText, qViewer) {				// Servicio GetData
										if (resText != qViewer.xml.data)
											qViewer.xml.data = resText;
										var d3 = new Date();
										var t3 = d3.getTime();
										if (!qv.util.anyError(resText))
											renderPivotTable(qViewer);
										else {
											// Error en el servicio GetData
											errMsg = qv.util.getErrorFromText(resText);
											qv.util.renderError(qViewer, errMsg);
										}
									});
								}
							}
							else
								qv.util.renderError(qViewer, qViewer.Metadata.ParserResult.Message);							
						}
						else {
							// Error en el servicio GetMetadata
							errMsg = qv.util.getErrorFromText(resText);
							qv.util.renderError(qViewer, errMsg);
						}
					});

				}
				else {
					// Error en el servicio GetRecordsetCachekey
					errMsg = qv.util.getErrorFromText(resText);
					qv.util.renderError(qViewer, errMsg);
				}
			});

		},

		GetMetadataPivot: function (qViewer) {

			function MergeMetadatas(qViewer, designtimeMetadata, runtimeMetadata) {

				var fields = [];
				var keys = qv.util.GetOrderedElementsKeys(qViewer, runtimeMetadata);
				for (var i = 0; i < keys.length; i++) {
					var index = parseInt(keys[i].substr(6, 4));
					var runtimeField = runtimeMetadata[index];
					var designtimeField;
					var designtimeFieldCloned;
					for (var j = 0; j < designtimeMetadata.length; j++) {
						designtimeField = designtimeMetadata[j];
						if (designtimeField.Name == runtimeField.Name) {
							designtimeFieldCloned = qv.util.cloneObject(designtimeField);		// Clono para no perder los valores originales
							qv.util.MergeFields(runtimeField, designtimeFieldCloned);
							fields.push(designtimeFieldCloned);
							break;
						}
					}
				}
				return fields;

			}

			var designtimeMetadata = qv.util.GetDesigntimeMetadata(qViewer);
			if (designtimeMetadata.length > 0) {
				var xml = qViewer.oat_element.getMetadataXML();
				var runtimeMetadata = qv.pivot.GetRuntimeMetadata(xml, qViewer.RealType);
				return MergeMetadatas(qViewer, designtimeMetadata, runtimeMetadata);
			}
			else
				return [];
		},

		GetRuntimeMetadata: function (xml, type) {

			function GetTypeValuesObject(parentNode, typeNodeName, includeNodeName, withValuesNodeType, excludeTotalValue) {
				var nodeType = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(parentNode, typeNodeName));
				var values = [];
				if (nodeType == withValuesNodeType) {
					var parentNodeAux = qv.util.dom.getSingleElementByTagName(parentNode, includeNodeName);
					if (parentNodeAux != null) {
						var valueNodes = qv.util.dom.getMultipleElementsByTagName(parentNodeAux, "value");
						for (var j = 0; j < valueNodes.length; j++) {
							var value = qv.util.trim(qv.util.dom.getValueNode(valueNodes[j]));
							if (value != null && (value.toUpperCase() != "TOTAL" || !excludeTotalValue))
								values.push(value);
						}
					}
				}
				return { Type: nodeType, Values: values };
			}

			var xmlDoc = qv.util.dom.xmlDocument(xml);
			var rootElement = qv.util.dom.getSingleElementByTagName(xmlDoc, "OLAPCube");
			var elements = [];
			// Obtengo los ejes
			var domElements;
			domElements = qv.util.dom.getMultipleElementsByTagName(rootElement, "OLAPDimension");
			for (var i = 0; i < domElements.length; i++) {
				var element = {};
				var name = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(domElements[i], "name"));
				var hidden = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(domElements[i], "hidden")) == "true";
				var axisType = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(domElements[i], "axis"));
				var position = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(domElements[i], "position"));
				var summarize = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(domElements[i], "summarize"));
				var order = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(domElements[i], "order"));
				element.Name = name;
				element.Type = QueryViewerElementType.Axis;
				element.Hidden = hidden;
				element.Axis = (axisType != null && axisType != "" && axisType != "null") ? qv.util.capitalize(axisType) : null;
				element.Position = position;
				element.Order = (order != null && order != "" && order != "null") ? qv.util.capitalize(order) : null;
				if (type == QueryViewerOutputType.Table) {
					element.Filter = GetTypeValuesObject(domElements[i], "", "include", null, true);
					element.Filter.Type = QueryViewerFilterType.ShowSomeValues;
				}
				else {
					element.Subtotals = summarize == "no" ? QueryViewerSubtotals.No : QueryViewerSubtotals.Yes;
					element.Filter = GetTypeValuesObject(domElements[i], "filterType", "include", QueryViewerFilterType.ShowSomeValues, true);
					element.ExpandCollapse = GetTypeValuesObject(domElements[i], "collapseType", "includeExpand", QueryViewerExpandCollapseType.ExpandSomeValues, false);
				}
				elements.push(element);
			}
			// Obtengo los datos
			var domElements = qv.util.dom.getMultipleElementsByTagName(rootElement, "OLAPMeasure");
			for (var i = 0; i < domElements.length; i++) {
				var element = {};
				var name = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(domElements[i], "name"));
				var hidden = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(domElements[i], "hidden")) == "true";
				var position = qv.util.dom.getValueNode(qv.util.dom.getSingleElementByTagName(domElements[i], "position"));
				element.Name = name;
				element.Type = QueryViewerElementType.Datum;
				element.Hidden = hidden;
				element.Position = position;
				elements.push(element);
			}
			return elements;
		},

		GetDataPivot: function (qViewer) {
			var result = qViewer.oat_element.getDataXML()
			return result;
		},

		GetFilteredDataPivot: function (qViewer) {
			var result = qViewer.oat_element.getFilteredDataXML()
			return result;
		},

		onOAT_PIVOTDragAndDropEvent: function (qViewer, data) {
			var position;
			if (qViewer.RealType == QueryViewerOutputType.PivotTable) {
				if (IsQueryObjectPreview())
					window.external.SendText(qViewer.ControlName, data);
				if (qViewer.DragAndDrop) {
					var xml_doc = qv.util.dom.xmlDocument(data);
					var Node = qv.util.dom.selectXPathNode(xml_doc, "/DATA");
					qViewer.DragAndDropData.Name = Node.getAttribute("name");
					qViewer.DragAndDropData.Type = QueryViewerElementType.Axis;
					axis = Node.getAttribute("axis");
					qViewer.DragAndDropData.Axis = (axis == "rows" ? QueryViewerAxisType.Rows : (axis == "columns" ? QueryViewerAxisType.Columns : QueryViewerAxisType.Pages));
					qViewer.DragAndDropData.Position = Node.getAttribute("position");
					qViewer.DragAndDrop();
				}
			}
		},

		onItemClickEvent: function (qViewer, data, isDoubleClick) {
			var location;
			var eventData;
			if ((qViewer.ItemClick && !isDoubleClick) || (qViewer.ItemDoubleClick && isDoubleClick)) {
				eventData = (isDoubleClick ? eventData = qViewer.ItemDoubleClickData : qViewer.ItemClickData);
				var xml_doc = qv.util.dom.xmlDocument(data);
				var Node1 = qv.util.dom.selectXPathNode(xml_doc, "/DATA/ITEM");
				var Node2 = qv.util.dom.selectXPathNode(xml_doc, "/DATA/CONTEXT/RELATED");
				var Node3 = qv.util.dom.selectXPathNode(xml_doc, "/DATA/CONTEXT/FILTERS");
				eventData.Name = Node1.getAttribute("name");
				location = Node1.getAttribute("location");
				switch (location) {
					case "rows":
						eventData.Type = QueryViewerElementType.Axis;
						eventData.Axis = QueryViewerAxisType.Rows;
						break;
					case "columns":
						eventData.Type = QueryViewerElementType.Axis;
						eventData.Axis = QueryViewerAxisType.Columns;
						break;
					case "pages":
						eventData.Type = QueryViewerElementType.Axis;
						eventData.Axis = QueryViewerAxisType.Pages;
						break;
					default:
						eventData.Type = QueryViewerElementType.Datum;
						eventData.Axis = "";
						break;
				}
				eventData.Value = (Node1.firstChild != null ? Node1.firstChild.nodeValue : "");
				eventData.Selected = Node1.getAttribute("selected") == "true";
				var excludedItems = getComponentItems(qViewer);
				eventData.Context = loadContextItems(Node2, excludedItems);
				eventData.Filters = loadContextItems(Node3, excludedItems);
				if (isDoubleClick)
					qViewer.ItemDoubleClick();
				else
					qViewer.ItemClick();
			}
		},

		onItemExpandCollapseEvent: function (qViewer, data, isCollapse) {
			var location;
			var eventData;
			if (IsQueryObjectPreview())
				window.external.SendText(qViewer.ControlName, data);
			if ((qViewer.ItemExpand && !isCollapse) || (qViewer.ItemCollapse && isCollapse)) {
				eventData = (isCollapse ? eventData = qViewer.ItemCollapseData : qViewer.ItemExpandData);
				var xml_doc = qv.util.dom.xmlDocument(data);
				var Node1 = qv.util.dom.selectXPathNode(xml_doc, "/DATA/ITEM");
				var Node2 = qv.util.dom.selectXPathNode(xml_doc, "/DATA/CONTEXT/EXPANDEDVALUES");
				eventData.Name = Node1.getAttribute("name");
				eventData.Value = Node1.firstChild.nodeValue;
				eventData.ExpandedValues = [];
				var valueIndex = -1;
				for (var i = 0; i < Node2.childNodes.length; i++)
					if (Node2.childNodes[i].nodeName == "VALUE") {
						valueIndex++;
						eventData.ExpandedValues[valueIndex] = Node2.childNodes[i].firstChild.nodeValue;
					}
				if (isCollapse)
					qViewer.ItemCollapse();
				else
					qViewer.ItemExpand();
			}
		},

		Select: function (qViewer, selection) {
			qViewer.oat_element.selectValue(selection);
		},

		Deselect: function (qViewer) {
			qViewer.oat_element.deselectValue();
		}

	}

})()
/* END OF FILE - ..\Sources\PivotTable.src.js - */
/* START OF FILE - ..\Sources\Chart.src.js - */
var HCChart;
var _highChartsDrawPointsWrapped;
var DEFAULTCHARTSPACING = 10;

qv.chart = (function () {

	function IsTimelineChart(qViewer) {
		return qViewer.RealChartType == QueryViewerChartType.Timeline || qViewer.RealChartType == QueryViewerChartType.SmoothTimeline || qViewer.RealChartType == QueryViewerChartType.StepTimeline;
	}

	function IsDatetimeXAxis(qViewer) {
		return IsTimelineChart(qViewer) || (qViewer.RealChartType == QueryViewerChartType.Sparkline );
	}

	function IsStackedChart(qViewer) {
		return qViewer.RealChartType == QueryViewerChartType.StackedColumn || qViewer.RealChartType == QueryViewerChartType.StackedColumn3D || qViewer.RealChartType == QueryViewerChartType.StackedColumn100 ||  qViewer.RealChartType == QueryViewerChartType.StackedBar ||  qViewer.RealChartType == QueryViewerChartType.StackedBar100 ||  qViewer.RealChartType == QueryViewerChartType.StackedArea ||  qViewer.RealChartType == QueryViewerChartType.StackedArea100 ||  qViewer.RealChartType == QueryViewerChartType.StackedLine ||  qViewer.RealChartType == QueryViewerChartType.StackedLine100;
	}

	function IsCircularChart(qViewer) {
		return qViewer.RealChartType == QueryViewerChartType.Pie || qViewer.RealChartType == QueryViewerChartType.Pie3D || qViewer.RealChartType == QueryViewerChartType.Doughnut || qViewer.RealChartType == QueryViewerChartType.Doughnut3D;
	}

	function IsFunnelChart(qViewer) {
		return qViewer.RealChartType == QueryViewerChartType.Funnel || qViewer.RealChartType == QueryViewerChartType.Pyramid;
	}

	function IsPolarChart(qViewer) {
		return qViewer.RealChartType == QueryViewerChartType.Radar || qViewer.RealChartType == QueryViewerChartType.FilledRadar || qViewer.RealChartType == QueryViewerChartType.PolarArea;
	}

	function IsSingleSerieChart(qViewer) {
		return IsCircularChart(qViewer) || IsFunnelChart(qViewer);
	}

	function IsCombinationChart(qViewer) {
		return (qViewer.RealChartType == QueryViewerChartType.ColumnLine || qViewer.RealChartType == QueryViewerChartType.Column3DLine) && qViewer.Chart.Series.DataFields.length > 1 ;
	}

	function IsGaugeChart(qViewer) {
		return qViewer.RealChartType == QueryViewerChartType.CircularGauge || qViewer.RealChartType == QueryViewerChartType.LinearGauge;
	}

	function IsAreaChart(qViewer) {
		return qViewer.RealChartType == QueryViewerChartType.Area || qViewer.RealChartType == QueryViewerChartType.StackedArea || qViewer.RealChartType == QueryViewerChartType.StackedArea100 || qViewer.RealChartType == QueryViewerChartType.SmoothArea  || qViewer.RealChartType == QueryViewerChartType.StepArea;
	}

	function IsLineChart(qViewer) {
		return qViewer.RealChartType == QueryViewerChartType.Line || qViewer.RealChartType == QueryViewerChartType.StackedLine || qViewer.RealChartType == QueryViewerChartType.StackedLine100 || qViewer.RealChartType == QueryViewerChartType.SmoothLine  || qViewer.RealChartType == QueryViewerChartType.StepLine || qViewer.RealChartType == QueryViewerChartType.Sparkline || IsTimelineChart(qViewer);
	}

	function IsBarChart(qViewer) {
		return qViewer.RealChartType == QueryViewerChartType.Bar || qViewer.RealChartType == QueryViewerChartType.StackedBar || qViewer.RealChartType == QueryViewerChartType.StackedBar100;
	}

	function HasYAxis(qViewer) {
		return !IsCircularChart(qViewer) && !IsFunnelChart(qViewer) && !IsGaugeChart(qViewer);
	}

	function IsSplittedChart(qViewer) {
		if (IsStackedChart(qViewer))
			return false;						// Para las gráficas Stacked no tiene sentido separar en varias gráficas pues dejan de apilarse las series
		else
			return (qViewer.PlotSeries == QueryViewerPlotSeries.InSeparateCharts || IsSingleSerieChart(qViewer)) && qViewer.Chart.Series.DataFields.length > 1;	// Fuerzo gráficas separadas para este tipo de gráficas porque sino no se pueden dibujar
	}

	function NumberOfCharts(qViewer) {
		return IsSplittedChart(qViewer) ? qViewer.Chart.Series.DataFields.length : 1;
	}

	function splitChartContainer(qViewer) {
		var viewerId = qViewer.userControlId();
		var container = qv.util.dom.getEmptyContainer(qViewer);
		if ((IsTimelineChart(qViewer) || IsSplittedChart(qViewer)) && container.offsetHeight == 0) {
			container.style.height = "400px";		// Necesito tener un alto distinto de cero antes de dibujar las gráficas, si no todas quedan con alto 400px
		}
		if (IsTimelineChart(qViewer)) {
			qv.util.dom.createDiv(container, optionsId(viewerId), "QVTimelineHeaderContainer", "", { width: "100%", height: TimelineHeaderHeight + "px" }, "");
			var centerDiv = qv.util.dom.createDiv(container, centerId(viewerId), "", "", { width: "100%", height: "calc(100% - " + TimelineHeaderHeight + "px - " + TimelineFooterHeight + "px)" }, "");
			qv.util.dom.createDiv(container, footerId(viewerId), "gx-qv-footer", "", { width: "100%", height: TimelineFooterHeight + "px" }, "");
			container.style.padding = DEFAULTCHARTSPACING + "px";
			container = centerDiv;
		}
		if (IsSplittedChart(qViewer)) {
			var totDIVs = qViewer.Chart.Series.DataFields.length;
			var divHeight = parseInt(100 / totDIVs);
			var percentLeft = 100 % totDIVs;
			var baseId;
			if (IsTimelineChart(qViewer))
				baseId = centerId(viewerId);
			else
				baseId = viewerId;
			for (var i = 0; i < totDIVs; i++)
				qv.util.dom.createDiv(container, baseId + "_chart" + i.toString(), "", "", { width: "100%", height: (divHeight + (i < percentLeft ? 1 : 0)).toString() + "%" }, "");
		}
	}

	function getHoverPoints(qViewer, index) {
		var points = [];
		for (var i = 0; i < qViewer.Charts.length; i++) {
			for (var j = 0; j < qViewer.Charts[i].series.length; j++) {
				var point = qViewer.Charts[i].series[j].data[index];
				points.push(point);
			}
		}
		return points;
	}

	function syncPoints(qViewer, container, index, visible, highlightIfVisible) {
		for (var i = 0; i < qViewer.Charts.length; i++) {
			if (container.id != qViewer.Charts[i].container.id) {
				for (var j = 0; j < qViewer.Charts[i].series.length; j++) {
					var point = qViewer.Charts[i].series[j].data[index];
					if (visible) {
						if (highlightIfVisible) point.setState('hover');
						qViewer.Charts[i].tooltip.hide(0);
					}
					else {
						point.setState();
					}
				}
			}
		}
	}

	function getChartType_forHightCharts(chartType) {
		switch (chartType) {
			case QueryViewerChartType.Column:
			case QueryViewerChartType.Column3D:
			case QueryViewerChartType.StackedColumn:
			case QueryViewerChartType.StackedColumn3D:
			case QueryViewerChartType.StackedColumn100:
			case QueryViewerChartType.PolarArea:
				return "column";
			case QueryViewerChartType.Bar:
			case QueryViewerChartType.StackedBar:
			case QueryViewerChartType.StackedBar100:
			case QueryViewerChartType.LinearGauge:
				return "bar";
			case QueryViewerChartType.Area:
			case QueryViewerChartType.StackedArea:
			case QueryViewerChartType.StackedArea100:
			case QueryViewerChartType.FilledRadar:
			case QueryViewerChartType.StepArea:
				return "area";
			case QueryViewerChartType.SmoothArea:
				return "areaspline";
			case QueryViewerChartType.Line:
			case QueryViewerChartType.StackedLine:
			case QueryViewerChartType.StackedLine100:
			case QueryViewerChartType.Radar:
			case QueryViewerChartType.Timeline:
			case QueryViewerChartType.StepTimeline:
			case QueryViewerChartType.Sparkline:
			case QueryViewerChartType.StepLine:
				return "line";
			case QueryViewerChartType.SmoothLine:
			case QueryViewerChartType.SmoothTimeline:
				return "spline";
			case QueryViewerChartType.ColumnLine:
			case QueryViewerChartType.Column3DLine:
				return "column";
			case QueryViewerChartType.Pie:
			case QueryViewerChartType.Pie3D:
			case QueryViewerChartType.Doughnut:
			case QueryViewerChartType.Doughnut3D:
				return "pie";
			case QueryViewerChartType.Funnel:
				return "funnel";
			case QueryViewerChartType.Pyramid:
				return "pyramid";
			case QueryViewerChartType.CircularGauge:
				return "solidgauge";
			default:
				return "line";
		}
	}

	function SetHighchartsOptions() {
		Highcharts.setOptions({
			lang: {
				months: [gx.getMessage("GXPL_QViewerJanuary"), gx.getMessage("GXPL_QViewerFebruary"), gx.getMessage("GXPL_QViewerMarch"), gx.getMessage("GXPL_QViewerApril"), gx.getMessage("GXPL_QViewerMay"), gx.getMessage("GXPL_QViewerJune"), gx.getMessage("GXPL_QViewerJuly"), gx.getMessage("GXPL_QViewerAugust"), gx.getMessage("GXPL_QViewerSeptember"), gx.getMessage("GXPL_QViewerOctober"), gx.getMessage("GXPL_QViewerNovember"), gx.getMessage("GXPL_QViewerDecember")],
				weekdays: [gx.getMessage("GXPL_QViewerSunday"), gx.getMessage("GXPL_QViewerMonday"), gx.getMessage("GXPL_QViewerTuesday"), gx.getMessage("GXPL_QViewerWednesday"), gx.getMessage("GXPL_QViewerThursday"), gx.getMessage("GXPL_QViewerFriday"), gx.getMessage("GXPL_QViewerSaturday")],
				shortMonths: [gx.getMessage("GXPL_QViewerJanuary").substring(0, 3), gx.getMessage("GXPL_QViewerFebruary").substring(0, 3), gx.getMessage("GXPL_QViewerMarch").substring(0, 3), gx.getMessage("GXPL_QViewerApril").substring(0, 3), gx.getMessage("GXPL_QViewerMay").substring(0, 3), gx.getMessage("GXPL_QViewerJune").substring(0, 3), gx.getMessage("GXPL_QViewerJuly").substring(0, 3), gx.getMessage("GXPL_QViewerAugust").substring(0, 3), gx.getMessage("GXPL_QViewerSeptember").substring(0, 3), gx.getMessage("GXPL_QViewerOctober").substring(0, 3), gx.getMessage("GXPL_QViewerNovember").substring(0, 3), gx.getMessage("GXPL_QViewerDecember").substring(0, 3)],
				numericSymbols: null
			}
		});
	}

	function SetItemClickData(eventData, qViewer, name, type, value, selected, row) {

		
		function GetContextElement(axisOrDatum, value) {
			var contextElement = {};
			contextElement.Name = axisOrDatum.Name;
			var pictureProperties = qv.util.GetPictureProperties(axisOrDatum.DataType, axisOrDatum.Picture);
			var formattedValue = qv.util.ApplyPicture(value, axisOrDatum.Picture, axisOrDatum.DataType, pictureProperties);
			contextElement.Values = [formattedValue];
			return contextElement;
		}

		eventData.Name = name;
		eventData.Type = type;
		eventData.Axis = "";
		eventData.Value = value;
		eventData.Selected = selected;
		eventData.Context = [];
		
		for (var i = 0; i < qViewer.Metadata.Axes.length; i++) {
			var axis = qViewer.Metadata.Axes[i];
			if (!axis.IsComponent) {
				var contextElement = GetContextElement(axis, row[axis.DataField]);
				eventData.Context.push(contextElement);
			}
		}
		for (var i = 0; i < qViewer.Metadata.Data.length; i++) {
			var datum = qViewer.Metadata.Data[i];
			if (!datum.IsComponent) {
				var contextElement = GetContextElement(datum, row[datum.DataField]);
				eventData.Context.push(contextElement);
			}
		}
		eventData.Filters = [];
	}

	function ToggleChartsSelection(charts, index) {
		var selectedResult = false;
		for (var i = 0; i < charts.length; i++) {
			var chart = charts[i];
			for (var j = 0; j < chart.series.length; j++) {
				var point = chart.series[j].points[index];
				if (point.selected) {
					point.select();
					break;
				}
				else {
					point.select(true, j > 0);
					selectedResult = true;
				}
			}
		}
		return selectedResult;
	}

	function GetRowsToSelect(qViewer, selection) {
		var rowsToSelect = [];
		for (var i = 0; i < qViewer.Data.Rows.length; i++) {
			var row = qViewer.Data.Rows[i];
			var selected = true;
			for (j = 0; j < selection.length; j++) {
				var selectionItem = selection[j];
				if (row[selectionItem.DataField])
					if (qv.util.trim(row[selectionItem.DataField]) != qv.util.trim(selectionItem.Value)) {
						selected = false;
						break;
					}
			}
			if (selected)
				rowsToSelect.push(i);
		}
		return rowsToSelect;
	}

	function SelectChartsPoints(charts, indexes) {
		for (var i = 0; i < charts.length; i++) {
			var chart = charts[i];
			var accumulate = false;
			for (var j = 0; j < indexes.length; j++) {
				var index = indexes[j];
				for (var k = 0; k < chart.series.length; k++) {
					var point = chart.series[k].points[index];
					point.select(true, accumulate);
					if (!accumulate)
						accumulate = true;
				}
			}
		}
	}

	function DeselectChartsPoints(charts) {
		for (var i = 0; i < charts.length; i++) {
			var chart = charts[i];
			var points = chart.getSelectedPoints();
			if (points.length > 0)
				points[0].select(false, false);
		}
	}

	function formattedPointsTimeline(qViewer, points) {
		var categories = qViewer.Chart.Categories.DataFields;
		var indicators = qViewer.Chart.Series.DataFields;
		var result = points.map(function (point) {
			var newPoint = {};

			categories.forEach(function (category) {
				newPoint[category] = point.x;
			});

			indicators.forEach(function (indicator, index) {
				newPoint[indicator] = point['y' + (index + 1)];
			});

			return newPoint;
		});

		return result;
	}



	function onHighchartsItemClickEventHandler(event) {

		var qViewer = qv.collection[this.chart.options.qv.viewerId];
		var seriesIndex = IsSplittedChart(qViewer) ? this.chart.options.qv.seriesIndex : event.point.series.index;
		var selected = false;
		if (qViewer.SelectionAllowed()) {
			if (qViewer.SelectionType == "Point") {
				event.point.select();
				selected = event.point.selected;
				if (qViewer.PlotSeries == QueryViewerPlotSeries.InSeparateCharts && selected) {
					for (var i = 0; i < qViewer.Charts.length; i++) {
						var chart = qViewer.Charts[i];
						var point = chart.series[0].points[event.point.index];
						if (point != event.point)
							point.select(false);
					}
				}
			}
			else
				selected = ToggleChartsSelection(qViewer.Charts, event.point.index);
		}
		if (qViewer.ItemClick && qViewer.Metadata.Data[seriesIndex].RaiseItemClick) {
			var serie = qViewer.Chart.Series.ByIndex[seriesIndex];
			var formattedValue = qv.util.formatNumber(event.point.y, serie.NumberFormat.DecimalPrecision, serie.Picture, false);
			var row = IsTimelineChart(qViewer) ? qViewer.Chart.GroupByPoints[event.point.index] : qViewer.Data.Rows[event.point.index];
			SetItemClickData(qViewer.ItemClickData, qViewer, serie.FieldName, QueryViewerElementType.Datum, formattedValue, selected, row);
			qViewer.ItemClick();
		}
	}

	function onHighchartsXAxisClickEventHandler(event, tickInd, tick, chart, raiseItemClick, selectionAllowed) {
		var qViewer = qv.collection[chart.options.qv.viewerId];
		var selected = false;
		if (selectionAllowed && !IsTimelineChart(qViewer))
			selected = ToggleChartsSelection(qViewer.Charts, tick.pos);
		if (raiseItemClick) {
			var name;
			if (qViewer.Chart.Categories.DataFields.length == 1) {
				var dataField = qViewer.Chart.Categories.DataFields[0];
				var axis = qv.util.GetAxisByDataField(qViewer, dataField);
				name = axis.Name;
			}
			else
				name = "";
			var row = qViewer.Data.Rows[tickInd];
			SetItemClickData(qViewer.ItemClickData, qViewer, name, QueryViewerElementType.Axis, tick.label.textStr, selected, row);
			qViewer.ItemClick();
		}
	}

	function GetBoldText(text) {
		return qv.util.dom.createSpan(null, "", "", "", { fontWeight: "bold" }, null, text).outerHTML;
	}

	function GetBoldRightText(text) {
		return qv.util.dom.createSpan(null, "", "", "", { fontWeight: "bold", textAlign:"right"}, null, text).outerHTML;
	}


	function CircularGaugeTooltipAndDataLabelFormatter(evArg, qViewer) {
		var seriesIndex = IsSplittedChart(qViewer) ? evArg.series.chart.options.qv.seriesIndex : evArg.series.index;
		var serie = qViewer.Chart.Series.ByIndex[seriesIndex];
		var chartSize = Math.min(qViewer.getContainerControl().offsetHeight, qViewer.getContainerControl().offsetWidth) / NumberOfCharts(qViewer);
		var fontSize = chartSize / 13;
		return qv.util.dom.createSpan(null, "", "", "", { color: GetColorStringFromHighchartsObject(qViewer, evArg), fontSize: fontSize + "px" }, null, qv.util.formatNumber(evArg.point.y, 2, "ZZZZZZZZZZZZZZ9.99", true) + "%").outerHTML;
	}

	function DataLabelFormatter(evArg, qViewer) {
		var seriesIndex = IsSplittedChart(qViewer) ? evArg.series.chart.options.qv.seriesIndex : evArg.series.index;
		seriesIndex = seriesIndex % qViewer.Chart.Series.ByIndex.length;	// Cuando comparo hay el doble de series en la gráfica
		var chartSerie = qViewer.Chart.Series.ByIndex[seriesIndex];
		var multiplier = qViewer.RealChartType == QueryViewerChartType.LinearGauge ? chartSerie.TargetValue / 100 : 1;
		var value = qv.util.formatNumber(evArg.point.y * multiplier, chartSerie.NumberFormat.DecimalPrecision, chartSerie.Picture, false);
		var chartType = evArg.series.chart.options.chart.type;
		var label = value;
		return label;
	}

	function TooltipFormatter(evArg, chartSeries, sharedTooltip)
	{
		var qViewer;
		if (!sharedTooltip) {
			qViewer = qv.collection[evArg.series.chart.options.qv.viewerId];
			var seriesIndex = evArg.series.index;
			var serie = chartSeries[seriesIndex];
			var picture = IsGaugeChart(qViewer) ? "ZZZZZZZZZZZZZZ9.99" : serie.Picture;
			var decimalPrecision = IsGaugeChart(qViewer) ? 2 : serie.NumberFormat.DecimalPrecision;
			var removeTrailingZeroes = IsGaugeChart(qViewer);
			return (qv.util.isRTL(qViewer)) ? (IsGaugeChart(qViewer) ? "%" : "") + qv.util.formatNumber(evArg.point.y, decimalPrecision, picture, removeTrailingZeroes) + '<b>: ' + (evArg.point.name != "" ? evArg.point.name : evArg.series.name) + '<b>' :
				'<b>' + (evArg.point.name != "" ? evArg.point.name : evArg.series.name) + '</b>: ' + qv.util.formatNumber(evArg.point.y, decimalPrecision, picture, removeTrailingZeroes) + (IsGaugeChart(qViewer) ? "%" : "");
		}
		else {
			var firstPoint;
			var index;
			if (!evArg.points) {
				firstPoint = evArg.point;
				index = firstPoint.index;
			}
			else {
				firstPoint = evArg.points[0];
				index = firstPoint.point.index;
			}
			qViewer = qv.collection[firstPoint.series.chart.options.qv.viewerId];
			var hoverPoints = getHoverPoints(qViewer, index);
			var x = (!evArg.key ? (!evArg.x ? "" : evArg.x) : evArg.key);
			var hasTitle = x != "" && qViewer.RealChartType != QueryViewerChartType.Sparkline;	// en Sparkline la x no viene formateada
			var res = "";
			if (hasTitle)
				(qv.util.isRTL(qViewer)) ? res += GetBoldRightText(x) : res += GetBoldText(x);
			for (var i = 0; i < hoverPoints.length; i++) {
				var point = hoverPoints[i];
				var seriesIndex = point.series.chart.options.qv.seriesIndex;
				var serie = chartSeries[seriesIndex];
				if (qv.util.isRTL(qViewer)) {
					res += (hasTitle || i > 0 ? '<br/>' : '') + qv.util.formatNumber(point.y, serie.NumberFormat.DecimalPrecision, serie.Picture, false);
					res += ' :' + point.series.name;
				}	
				else {
					res += (hasTitle || i > 0 ? '<br/>' : '') + point.series.name + ': ';
					res += qv.util.formatNumber(point.y, serie.NumberFormat.DecimalPrecision, serie.Picture, false);
				}
			}
			return res;
		}
	}

	function PieTooltipFormatter(evArg, sharedTooltip) {
		var qViewer = qv.collection[evArg.point.series.chart.options.qv.viewerId];
		if (!sharedTooltip) {
			var percentage = Math.round(evArg.point.percentage * 100) / 100;
			return (qv.util.isRTL(qViewer)) ? ('%' + percentage + '<b>: ' + (evArg.point.name != "" ? evArg.point.name : evArg.point.series.name) + '</b>') : ('<b>' + (evArg.point.name != "" ? evArg.point.name : evArg.point.series.name) + '</b>: ' + percentage + '%');
		}
		else {
			var hoverPoints = getHoverPoints(qViewer, evArg.point.index);
			var x = hoverPoints.length > 0 ? hoverPoints[0].id : "";
			var hasTitle = x != "";
			var res = "";
			if (hasTitle)
				(qv.util.isRTL(qViewer)) ? res += GetBoldRightText(x) : res += GetBoldText(x);
			for (var i = 0; i < hoverPoints.length; i++) {
				var point = hoverPoints[i];
				var percentage = Math.round(point.percentage * 100) / 100;
				if (qv.util.isRTL(qViewer)) {
					res += (hasTitle || i > 0 ? '<br/>' : '') + '%' + percentage;
					res += ' :' + point.series.name;
				} else {
					res += (hasTitle || i > 0 ? '<br/>' : '') + point.series.name + ': ';
					res += percentage + '%';
				}
			}
			return res;
		}
	}

	function Stacked100TooltipFormatter(evArg, qViewer) {
		var percentage = Math.round(evArg.point.percentage * 100) / 100;
		return (qv.util.isRTL(qViewer)) ? ('%' + percentage + '<b>: ' + (evArg.point.id != "" ? evArg.point.id : evArg.series.name)  + '</b>') : ('<b>' + (evArg.point.id != "" ? evArg.point.id : evArg.series.name) + '</b>: ' + percentage + '%');

	}

	function DateTimeTooltipFormatter(evArg, chartSeries) {

		function GetDuration(point) {

			var value = point.y;
			var points = point.series.data;
			var index = point.index;
			var duration = "";
			var max = index;
			for (var i = index + 1; i < points.length; i++) {
				if (points[i].y != value)
					break;
				max = i;
			}
			if (max < points.length - 1)
				max++;
			var min = index;
			for (var i = index - 1; i >= 0; i--) {
				if (points[i].y != value)
					break;
				min = i;
			}
			var seconds = (points[max].x - points[min].x) / 1000;
			duration = " (" + gx.getMessage("GXPL_QViewerDuration") + ": " + qv.util.seconsdToText(seconds) + ")";
			return duration;
		}

		var hoverPoints;
		var viewerId = evArg.points[0].series.chart.options.qv.viewerId;
		var qViewer = qv.collection[viewerId];
		if (IsSplittedChart(qViewer))
			hoverPoints = getHoverPoints(qViewer, evArg.points[0].point.index);
		else {
			hoverPoints = [];
			jQuery.each(evArg.points, function (index, point) {
				hoverPoints.push(point.point);
			});
		}
		// Agrupa la lista de puntos por índice de la serie
		var points_by_strIndex = {};
		var compare = gx.dom.el(viewerId + "_options_compare_enable").checked;
		for (var i = 0; i < hoverPoints.length; i++) {
			var index = compare ? Math.trunc(hoverPoints[i].series.index / 2) : hoverPoints[i].series.index;
			var strIndex = index.toString(); 
			if (points_by_strIndex[strIndex] == undefined) {
				points_by_strIndex[strIndex] = [];
			}
			points_by_strIndex[strIndex].push(hoverPoints[i]);
		}
		var res = '';
		var currentTotal = 0;
		var previousTotal = 0;
		var oldUtc;
		var oldSeriesName;
		for (var strIndex in points_by_strIndex) {
			var seriesIndex = parseInt(strIndex);
			var serie = chartSeries[seriesIndex];
			var seriesName = serie.Name;
			var points = points_by_strIndex[strIndex];
			for (var ind = 0; points[ind] != undefined; ind++) {
				var p = points[ind];
				var utc = parseInt(p.real_x ? p.real_x : p.x);
				if (p.real_x) {
					previousTotal += p.y;
				} else {
					currentTotal += p.y;
				}
				if (compare) {
					if (oldSeriesName != seriesName) {
						(qv.util.isRTL(qViewer)) ? res += GetBoldRightText(seriesName) + '<br/>' : res += GetBoldText(seriesName) + '<br/>';
						oldSeriesName = seriesName;
					}
				}
				else {
					if (oldUtc != utc) {
						(qv.util.isRTL(qViewer)) ? res += GetBoldRightText(p.name) + '<br/>' : res += GetBoldText(p.name) + '<br/>';
						oldUtc = utc;
					}
				}
				var duration = qViewer.RealChartType == QueryViewerChartType.StepTimeline ? GetDuration(p) : "";
				var keySpan;
				var valueSpan = qv.util.dom.createSpan(null, "", "", "", {}, null, qv.util.formatNumber(p.y, serie.NumberFormat.DecimalPrecision, serie.Picture, false)).outerHTML;

				(qv.util.isRTL(qViewer)) ? keySpan = qv.util.dom.createSpan(null, "", "", "", {}, null, ": " + (compare ? p.name : seriesName)).outerHTML : keySpan = qv.util.dom.createSpan(null, "", "", "", {}, null, (compare ? p.name : seriesName) + ": ").outerHTML;				
				(qv.util.isRTL(qViewer)) ? res +=  duration+ valueSpan + keySpan + '<br/>' : res += keySpan + valueSpan + duration + '<br/>';

			}
		}
		return res;
	}

	function selectionEventHandler(event) {
		if (typeof _avoidSelectionEventHandler === "undefined")
			_avoidSelectionEventHandler = false;
		if (!_avoidSelectionEventHandler) {
			// Desmarca el botón de zoom seleccionado cuando se hace un zoom seleccionando puntos en la gráfica
			deselectZoom(prevClickedZoomId);
			prevClickedZoomId = null;
			if (event.xAxis) {
				var qvOptions = event.target.options.qv;
				var xAxis = event.xAxis[0];
				var minPercent = (xAxis.min - qvOptions.dataMin) / (qvOptions.dataMax - qvOptions.dataMin) * 100;
				var maxPercent = (xAxis.max - qvOptions.dataMin) / (qvOptions.dataMax - qvOptions.dataMin) * 100;
				InitializeSlider(event.target.options.qv.viewerId, minPercent, maxPercent);
			}
			else
				InitializeSlider(event.target.options.qv.viewerId, 0, 100);
			var qViewer = qv.collection[event.target.options.qv.viewerId];
			if (IsSplittedChart(qViewer)) {
				var containers;
				var containerId = qViewer.getContainerControl().id;
				containers = jQuery("[id^=" + containerId + "_chart]");
				var charts = [];
				jQuery.each(containers, function (index, div) {
					if (div.id != event.target.renderTo.id) {
						var chart = jQuery("#" + div.id).highcharts();
						charts.push(chart);
					}
				});
				jQuery.each(charts, function (index, chart) {
					if (event.xAxis) {
						chart.get('xaxis').setExtremes(xAxis.min, xAxis.max);
					}
					else {
						_avoidSelectionEventHandler = true;
						chart.zoomOut();
						_avoidSelectionEventHandler = false;
					}
				});
			}
		}
	}

	function groupPoints(chartCategories, chartSeriePoints, xAxisDataType, aggregation, groupOption)
	{

		function getGroupStartPoint(dateStr, name, xAxisDataType, dateFormat, groupOption) {

			function yearWith4Digits(xAxisDataType, name) {
				return xAxisDataType == QueryViewerDataType.Date ? name.length == 10 : name.charAt(10) == " ";
			}

			function formatDate(dateStr, dateFormat, yearWith4Digits, includeMonth, includeDay) {
				var year = dateStr.substr(0, 4);
				var month = dateStr.substr(5, 2);
				var day = dateStr.substr(8, 2);
				var date = dateFormat;
				if (!includeMonth) date = date.replace("M", "");
				if (!includeDay) date = date.replace("D", "");
				var newDate = "";
				for (var i = 0; i < date.length; i++) {
					newDate += i == 0 ? "" : "/";
					newDate += date.charAt(i);
				}
				date = newDate.replace("Y", yearWith4Digits ? year : year.substr(2, 2));
				if (includeMonth)
					date = date.replace("M", month);
				if (includeDay)
					date = date.replace("D", day);
				return date;
			}

			var dateStrStartPoint;
			var nameStartPoint;
			if (dateStr != "") {
				groupOption = groupOption || (xAxisDataType == QueryViewerDataType.Date ? "Days" : "Seconds");
				switch (groupOption) {
					case "Years":
						dateStrStartPoint = dateStr.substr(0, 4) + "-01-01";
						nameStartPoint = formatDate(dateStrStartPoint, dateFormat, yearWith4Digits(xAxisDataType, name), false, false);
						break;
					case "Months":
						dateStrStartPoint = dateStr.substr(0, 7) + "-01";
						nameStartPoint = formatDate(dateStrStartPoint, dateFormat, yearWith4Digits(xAxisDataType, name), true, false);
						break;
					case "Semesters":
						var startingMonth = dateStr.substr(5, 2) <= "06" ? "01" : "07";
						dateStrStartPoint = dateStr.substr(0, 5) + startingMonth + "-01";
						var semester = dateStr.substr(5, 2) <= "06" ? "01" : "02";
						dateStrSemester = dateStr.substr(0, 5) + semester + "-01";
						nameStartPoint = formatDate(dateStrSemester, dateFormat, yearWith4Digits(xAxisDataType, name), true, false);
						break;
					case "Quarters":
						var startingMonth = dateStr.substr(5, 2) <= "03" ? "01" : (dateStr.substr(5, 2) <= "06" ? "04" : (dateStr.substr(5, 2) <= "09" ? "07" : "10"));
						dateStrStartPoint = dateStr.substr(0, 5) + startingMonth + "-01";
						var quarter = dateStr.substr(5, 2) <= "03" ? "01" : (dateStr.substr(5, 2) <= "06" ? "02" : (dateStr.substr(5, 2) <= "09" ? "03" : "04"));
						dateStrQuarter = dateStr.substr(0, 5) + quarter + "-01";
						nameStartPoint = formatDate(dateStrQuarter, dateFormat, yearWith4Digits(xAxisDataType, name), true, false);
						break;
					case "Weeks":
						var date = new gx.date.gxdate(dateStr, "Y4MD");
						var dow = gx.date.dow(date);
						date = gx.date.dtadd(date, -86400 * (dow - 1));
						dateStrStartPoint = qv.util.dateToString(date, false);
						nameStartPoint = formatDate(dateStrStartPoint, dateFormat, yearWith4Digits(xAxisDataType, name), true, true);
						break;
					case "Days":
						dateStrStartPoint = xAxisDataType == QueryViewerDataType.Date ? dateStr : dateStr.substr(0, 10);
						nameStartPoint = xAxisDataType == QueryViewerDataType.Date ? name : name.substr(0, 10);
						break;
					case "Hours":
						dateStrStartPoint = dateStr.substr(0, 13) + ":00:00";
						nameStartPoint = name.substr(0, 13) + ":00";
						break;
					case "Minutes":
						dateStrStartPoint = dateStr.substr(0, 16) + ":00";
						nameStartPoint = name.substr(0, 16);
						break;
					case "Seconds":
						dateStrStartPoint = dateStr;
						nameStartPoint = name;
						break;
				}
			}
			else {
				dateStrStartPoint = "";
				nameStartPoint = "";
			}
			return { dateStr: dateStrStartPoint, name: nameStartPoint };
		}

		var point;
		var lastStartPoint = { dateStr: null, name: null };
		var currentYValues = [];
		var currentYQuantities = [];
		var points = [];
		for (i = 0; i < chartSeriePoints.length; i++) {
			var name = chartCategories.Values[i].ValueWithPicture;
			var xValue = chartCategories.Values[i].Value;
			var yValue;
			var yQuantity;
			if (chartSeriePoints[i].Value != null) {
				if (aggregation == QueryViewerAggregationType.Count) {
					yValue = 0;		// No se utiliza
					yQuantity = parseFloat(qv.util.trim(chartSeriePoints[i].Value));
				}
				else {
					if (aggregation == QueryViewerAggregationType.Average) {
						yValue = parseFloat(qv.util.trim(chartSeriePoints[i].Value_N));
						yQuantity = parseFloat(qv.util.trim(chartSeriePoints[i].Value_D));
					}
					else {
						yValue = parseFloat(qv.util.trim(chartSeriePoints[i].Value));
						yQuantity = 1;
					}
				}
			}
			else {
				yValue = null;
				yQuantity = 0;
			}
			var currentStartPoint = getGroupStartPoint(xValue, name, xAxisDataType, gx.dateFormat, groupOption);
			if (currentStartPoint.dateStr == lastStartPoint.dateStr || i == 0) {
				if (yValue != null) {
					currentYValues.push(yValue);
					currentYQuantities.push(yQuantity);
				}
				if (i == 0)
					lastStartPoint = currentStartPoint;
			}
			else {
				point = { x: lastStartPoint.dateStr, y: qv.util.aggregate(aggregation, currentYValues, currentYQuantities), name: lastStartPoint.name };
				points.push(point);
				lastStartPoint = currentStartPoint;
				currentYValues = [yValue];
				currentYQuantities = [yQuantity];
			}
		}
		if (currentYValues.length > 0 && currentYQuantities.length > 0) {
			point = { x: lastStartPoint.dateStr, y: qv.util.aggregate(aggregation, currentYValues, currentYQuantities), name: lastStartPoint.name };
			points.push(point);
		}
		return points;
	}

	function getSpacing(qViewer)
	{
		var spacingTop;
		var spacingRight;
		var spacingBottom;
		var spacingLeft;
		if (IsTimelineChart(qViewer)) {
			spacingTop = DEFAULTCHARTSPACING;
			spacingRight = 0;
			spacingBottom = DEFAULTCHARTSPACING;
			spacingLeft = 0;
		}
		else {
			spacingTop = DEFAULTCHARTSPACING;
			spacingRight = DEFAULTCHARTSPACING;
			spacingBottom = DEFAULTCHARTSPACING;
			spacingLeft = DEFAULTCHARTSPACING;
		}
		return [spacingTop, spacingRight, spacingBottom, spacingLeft];
	}

	function circularGaugeWidths(chartSeriesCount, serieNumber) {
		var width;
		var center;
		var lowerExtreme;
		var upperExtreme;
		if (chartSeriesCount <= 3)
			width = 24;
		else
			width = 50 / (chartSeriesCount - 1) - 1;		// Para que no pase más del 50% del Gauge hacia adentro;
		center = 100 - (width + 1) * (serieNumber - 1);
		lowerExtreme = center - width / 2;
		upperExtreme = center + width / 2;
		return { Width: width, Center: center, LowerExtreme: lowerExtreme, UpperExtreme: upperExtreme};
	}

	function linearGaugeWidths(chartSeriesCount, serieNumber) {
		var width = 1 / chartSeriesCount / 2;
		var center = -0.5 + (serieNumber - 0.5) / chartSeriesCount;
		var lowerExtreme = center - width / 2;
		var upperExtreme = center + width / 2;
		return { Width: width, Center: center, LowerExtreme: lowerExtreme, UpperExtreme: upperExtreme };
	}

	function GetColorStringFromHighchartsObject(qViewer, highchartsObject) {

		function GetHighchartsDefaultColors(qViewer) {

			function LoadColorsObj(colorsObj, rules, rulePrefix, loadedColors) {
				if (!loadedColors)
					loadedColors = 0;
				for (var i = 0; i < rules.length; i++) {
					var rule = rules[i];
					if (rule instanceof CSSStyleRule) {
						if (rule.selectorText && rule.selectorText.indexOf(rulePrefix) == 0) {
							var key = rule.selectorText.replace(rulePrefix, "");
							colorsObj[key] = rule.style.fill;
							loadedColors++;
						}
						if (loadedColors === HIGHCHARTS_MAX_COLORS)
							break;
					}
					else if (rule instanceof CSSImportRule) {
						var importedRules = rule.styleSheet.rules || rule.styleSheet.cssRules;
						LoadColorsObj(colorsObj, importedRules, rulePrefix, loadedColors);
					}
					else if (rule instanceof CSSLayerBlockRule) {
						var layeredRules = rule.cssRules;
						LoadColorsObj(colorsObj, layeredRules, rulePrefix, loadedColors);
					}
				}
			}

			if (!qViewer._HighchartsDefaultColors) {
				qViewer._HighchartsDefaultColors = [];
				var colorsObj = {};
				var styleSheet;
				var rulePrefix;
				styleSheet = qv.util.GetQueryViewerStyleSheet(qViewer);		// Inicializo con los colores default del QueryViewer
				rulePrefix = ".highcharts-color-";
				LoadColorsObj(colorsObj, styleSheet.cssRules, rulePrefix);
				if (qViewer.Class != "") {
					styleSheet = qv.util.GetThemeStyleSheet(qViewer);			// Sustituyo con los colores definidos en el tema
					rulePrefix = "." + qv.util.GetContainerControlClass(qViewer) + " " + ".highcharts-color-";
					LoadColorsObj(colorsObj, styleSheet.cssRules, rulePrefix);
				}
				for (var i = 0; i < HIGHCHARTS_MAX_COLORS; i++)
					qViewer._HighchartsDefaultColors.push(colorsObj[i.toString()]);
			}
			return qViewer._HighchartsDefaultColors;
		}

		var classPrefix = "highcharts-color-";
		var colorIndex;
		var color;
		if (highchartsObject.className && highchartsObject.className.indexOf(classPrefix) == 0)
			colorIndex = parseInt(highchartsObject.className.replace(classPrefix, ""));
		else
			colorIndex = highchartsObject.colorIndex;
		if (colorIndex < HIGHCHARTS_MAX_COLORS) {
			var defaultColors = GetHighchartsDefaultColors(qViewer);
			color = defaultColors[colorIndex];
		}
		else {
			color = HIGHCHARTS_CUSTOM_COLOR[colorIndex - HIGHCHARTS_MAX_COLORS];
			if (qv.util.color.IsHexaColor(color))
				color = "#" + color;
		}
		return color;
	}

	function SetHighchartsColor(qViewer, highchartsObject, color, colorIndexForDefaultColors) {

		function AddHighchartsCustomColor(qViewer, color) {

			var localColorIndex = HIGHCHARTS_CUSTOM_COLOR.indexOf(color);
			var globalColorIndex;
			if (localColorIndex < 0) {
				HIGHCHARTS_CUSTOM_COLOR.push(color);
				localColorIndex = HIGHCHARTS_CUSTOM_COLOR.length - 1;
				globalColorIndex = HIGHCHARTS_MAX_COLORS + localColorIndex;
				var prefix = qv.util.color.IsHexaColor(color) ? "#" : "";
				var rule = "." + HIGHCHARTS_COLOR_PREFIX + globalColorIndex + " {fill: " + prefix + color + "; stroke: " + prefix + color + ";}";
				var themeStyleSheet = qv.util.GetThemeStyleSheet(qViewer);
				themeStyleSheet.insertRule(rule, themeStyleSheet.cssRules.length);
			}
			else
				globalColorIndex = HIGHCHARTS_MAX_COLORS + localColorIndex;
			return globalColorIndex;
		}

		if (!qv.util.IsNullColor(color)) {
			var colorIndex;
			if (color.IsDefault)
				colorIndex = color.ColorIndex;
			else
				colorIndex = AddHighchartsCustomColor(qViewer, color.Color);
			if (colorIndexForDefaultColors)
				highchartsObject.colorIndex = colorIndex;
			else
				highchartsObject.className = HIGHCHARTS_COLOR_PREFIX + colorIndex;	// Para PlotBands, por ejemplo, no anda setear el colorIndex
		}
	}

	function AddHighchartsCSSRules(qViewer) {
		// Workaround por no poder hacer estos seteos mediante la propiedad className en el tooltip
		if (qViewer.RealChartType == QueryViewerChartType.CircularGauge) {
			var themeStyleSheet = qv.util.GetThemeStyleSheet(qViewer);
			var rule = "#" + qViewer.ContainerName + " .highcharts-tooltip-box {fill: none !important; stroke-width: 0 !important; }";
			themeStyleSheet.insertRule(rule, themeStyleSheet.cssRules.length);
		}
	}

	function getHighchartOptions(qViewer, chartSerie, serieIndex) {

		function getChartObject(qViewer, serieIndex) {
			var chart = {};
			chart.styledMode = true;
			chart.spacing = getSpacing(qViewer);
			if (!IsSplittedChart(qViewer)) {
				if (!IsTimelineChart(qViewer))
					chart.renderTo = qViewer.getContainerControl();
				else
					chart.renderTo = document.getElementById(centerId(qViewer.userControlId()));
			}
			else {
				var viewerId = qViewer.userControlId();
				var baseId;
				if (IsTimelineChart(qViewer))
					baseId = centerId(viewerId);
				else
					baseId = viewerId;
				chart.renderTo = document.getElementById(baseId + "_chart" + serieIndex.toString());
			}
			if (!IsCombinationChart(qViewer)) {
				chart.type = getChartType_forHightCharts(qViewer.RealChartType);
			}
			if (qViewer.RealChartType == QueryViewerChartType.Radar || qViewer.RealChartType == QueryViewerChartType.FilledRadar || qViewer.RealChartType == QueryViewerChartType.PolarArea)
				chart.polar = true;
			else if (qViewer.RealChartType == QueryViewerChartType.Column3D || qViewer.RealChartType == QueryViewerChartType.StackedColumn3D || qViewer.RealChartType == QueryViewerChartType.Column3DLine)
				chart.options3d = { enabled: true, alpha: 15, beta: 15, depth: 50, viewDistance: 25 };
			else if (qViewer.RealChartType == QueryViewerChartType.Pie3D || qViewer.RealChartType == QueryViewerChartType.Doughnut3D)
				chart.options3d = { enabled: true, alpha: 45, beta: 0 };
			else if (IsTimelineChart(qViewer)) {
				chart.zoomType = 'x';
				chart.resetZoomButton = { theme: { display: 'none' } };
				chart.events = {};
				chart.events.selection = function (event) {
					selectionEventHandler(event);
				};
			}
			return chart;
		}

		function getNoCreditsObject() {
			var credits = { enabled: false };
			return credits;
		}

		function getLegendObject(qViewer) {
			var legend = { enabled: (qViewer.Chart.Series.DataFields.length > 1 && !IsSplittedChart(qViewer)) || IsSingleSerieChart(qViewer), margin: 0, rtl: qv.util.isRTL(qViewer)};
			return legend;
		}

		function getTitleObject(qViewer, serieIndex) {
			var title;
			if (qViewer.Title == "")
				title = { text: null };
			else {
				var titleStr = (serieIndex == null || serieIndex == 0) ? qv.util.getTranslation(qViewer.Title) : null;
				title = { text: titleStr };
			}
			return title;
		}

		function getSubtitleObject(qViewer, chartSerie) {
			var subtitle = {};
			if (IsSplittedChart(qViewer) && (IsSingleSerieChart(qViewer) || qViewer.RealChartType == QueryViewerChartType.CircularGauge)) {
				subtitle.text = chartSerie.Name;
				subtitle.floating = true;
				subtitle.align = (qv.util.isRTL(qViewer)) ? 'right' : 'left';
				subtitle.verticalAlign = "middle";
			}
			return subtitle;
		}

		function getXAxisObject(qViewer, serieIndex) {
			xAxis = {};
			xAxis.tickWidth = 1;
			xAxis.tickLength = 10;
			xAxis.reversed = qv.util.isRTL(qViewer);
			if (qViewer.RealChartType != QueryViewerChartType.CircularGauge) {
				var isDatetimeXAxis = IsDatetimeXAxis(qViewer);
				if (qViewer.RealChartType != QueryViewerChartType.Radar && qViewer.RealChartType != QueryViewerChartType.FilledRadar && qViewer.RealChartType != QueryViewerChartType.PolarArea && qViewer.RealChartType != QueryViewerChartType.LinearGauge && qViewer.RealChartType != QueryViewerChartType.Sparkline)
					xAxis.title = { text: XAxisTitle(qViewer) };
				else {
					if (qViewer.RealChartType == QueryViewerChartType.Sparkline && IsSplittedChart(qViewer))
						xAxis.title = { text: qViewer.Chart.Series.ByIndex[serieIndex].Name };
					xAxis.lineWidth = 0;
					if (qViewer.RealChartType == QueryViewerChartType.LinearGauge || qViewer.RealChartType == QueryViewerChartType.Sparkline)
						xAxis.tickPositions = [];
					if (qViewer.RealChartType == QueryViewerChartType.Radar || qViewer.RealChartType == QueryViewerChartType.FilledRadar)
						xAxis.tickmarkPlacement = "on";
					else
						xAxis.tickmarkPlacement = "between";
				}
				if (qViewer.RealChartType == QueryViewerChartType.LinearGauge) {
					var widths;
					if (IsSplittedChart(qViewer))
						widths = linearGaugeWidths(1, 1);
					xAxis.plotBands = [];
					for (var i = 0; i < qViewer.Chart.Series.ByIndex.length; i++) {
						if (!IsSplittedChart(qViewer) || i == serieIndex) {
							var chartSerie = qViewer.Chart.Series.ByIndex[i];
							if (!IsSplittedChart(qViewer))
								widths = linearGaugeWidths(qViewer.Chart.Series.DataFields.length, i + 1);
							plotBand = {};
							var color;
							if (!qv.util.IsNullColor(chartSerie.Color))
								color = chartSerie.Color;
							else
								color = chartSerie.Points[0].Color;
							SetHighchartsColor(qViewer, plotBand, color, false)
							plotBand.from = widths.LowerExtreme;
							plotBand.to = widths.UpperExtreme;
							xAxis.plotBands.push(plotBand);
						}
					}
				}
				if (!isDatetimeXAxis)
					xAxis.categories = [];
				var anyCategoryLabel = false;
				for (var i = 0; i < qViewer.Chart.Categories.Values.length; i++) {
					if (qViewer.Chart.Categories.Values[i].ValueWithPicture != "")
						anyCategoryLabel = true;
					if (!isDatetimeXAxis) {
						xAxis.categories[i] = qViewer.Chart.Categories.Values[i].ValueWithPicture;
					}
				}
				if (!isDatetimeXAxis) {
					xAxis.labels = {};
					xAxis.labels.enabled = anyCategoryLabel;
					if (qViewer.XAxisLabels != QueryViewerXAxisLabels.Horizontally && !IsBarChart(qViewer) && !IsPolarChart(qViewer)) {
						var angle;
						var offsetY;
						if (qViewer.XAxisLabels == QueryViewerXAxisLabels.Vertically) {
							angle = 90;
							offsetY = 5;
						}
						else {
							angle = parseInt(qViewer.XAxisLabels.replace("Rotated", ""));
							offsetY = 10;
						}
						xAxis.labels.rotation = 360 - angle;
						xAxis.labels.y = offsetY;
						xAxis.labels.align = "right";
					}
				}
				else {
					xAxis.type = 'datetime';
					xAxis.id = 'xaxis';
					xAxis.minRange = 1;		// 1ms máximo zoom (el default es demasiado grande)
					if (qv.util.XAxisDataType(qViewer) == QueryViewerDataType.Date) {
						if (qViewer.Chart.Categories.MaxValue != null && qViewer.Chart.Categories.MinValue != null) {
							var minDate = new gx.date.gxdate(qViewer.Chart.Categories.MinValue, "Y4MD");
							var maxDate = new gx.date.gxdate(qViewer.Chart.Categories.MaxValue, "Y4MD");
							if (maxDate.Value.getTime() - minDate.Value.getTime() < 10 * 24 * 3600 * 1000)
								xAxis.tickInterval = 24 * 3600 * 1000;
						}
					}
				}
				if (IsPolarChart(qViewer))
					xAxis.className = "highcharts-no-axis-line highcharts-yes-grid-line";		// Clases no estándar de Highcharts
				else if (qViewer.RealChartType == QueryViewerChartType.Sparkline)
					xAxis.className = "highcharts-no-axis-line highcharts-no-grid-line";		// Clases no estándar de Highcharts

				if (qViewer.RealChartType == QueryViewerChartType.Bar || qViewer.RealChartType == QueryViewerChartType.StackedBar || qViewer.RealChartType == QueryViewerChartType.StackedBar100) {
					xAxis.opposite = (qv.util.isRTL(qViewer));
				}
			}
			return xAxis;
		}

		function getYAxisObject(qViewer, chartSerie, seriesIndex) {
		
			function SamePicture(series) {
				if (series.length == 0)
					return false;
				else {
					var picture;
					for (var i = 0; i < series.length; i++) {
						if (i == 0)
							picture = series[i].Picture;
						else {
							if (series[i].Picture != picture)
								return false;
						}
					}
					return true;
				}
			}
			
			if (qViewer.RealChartType == QueryViewerChartType.Sparkline)
				yAxis = { visible: false };
			else {
				var yAxisName;
				if (qViewer.RealChartType == QueryViewerChartType.CircularGauge)
					yAxisName = null;
				else
					yAxisName = IsSplittedChart(qViewer) ? chartSerie.Name : YAxisTitle(qViewer);
				if (IsCombinationChart(qViewer) && !IsSplittedChart(qViewer)) {
					yAxis = [];
					yAxis[0] = { title: { text: yAxisName } };
					yAxis[1] = { title: { text: "" }, opposite: true };		// El eje secundario por ahora no es posible setearle titulo
				} else {
					yAxis = { title: { text: yAxisName } };
				}
				yAxis.plotLines = [];
				yAxis.plotBands = [];
				if (HasYAxis(qViewer)) {
					for (var i = 0; i < qViewer.Chart.PlotBands.length; i++) {
						var chartPlotBand = qViewer.Chart.PlotBands[i];
						if (chartSerie == null || chartSerie.Name == chartPlotBand.SeriesName) {
							if (chartPlotBand.From == chartPlotBand.To && chartPlotBand.From != null) {
								var plotLine = { value: chartPlotBand.From, width: 1, zIndex: 3 };
								SetHighchartsColor(qViewer, plotLine, chartPlotBand.Color, false);
								yAxis.plotLines.push(plotLine);
							}
							else {
								var plotBand = {};
								SetHighchartsColor(qViewer, plotBand, chartPlotBand.Color, false);
								plotBand.from = !chartPlotBand.From ? Number.MIN_VALUE : chartPlotBand.From;
								plotBand.to = !chartPlotBand.To ? Number.MAX_VALUE : chartPlotBand.To;
								yAxis.plotBands.push(plotBand);
							}
						}
					}
					if (IsSplittedChart(qViewer) || qViewer.Chart.Series.ByIndex.length == 1 || SamePicture(qViewer.Chart.Series.ByIndex)) {
						var firstSerie = IsSplittedChart(qViewer) ? chartSerie : qViewer.Chart.Series.ByIndex[0];
						yAxis.labels = {};
						yAxis.labels.formatter = function () {
							return qv.util.formatNumber(this.value, firstSerie.NumberFormat.DecimalPrecision, firstSerie.Picture, true);
						};
					}
				}
				if (qViewer.RealChartType == QueryViewerChartType.Radar || qViewer.RealChartType == QueryViewerChartType.FilledRadar || qViewer.RealChartType == QueryViewerChartType.PolarArea) {
					yAxis.min = 0;
					if (qViewer.RealChartType == QueryViewerChartType.Radar || qViewer.RealChartType == QueryViewerChartType.FilledRadar)
						yAxis.gridLineInterpolation = "polygon";
					else
						yAxis.gridLineInterpolation = "circle";
				}
				if (IsGaugeChart(qViewer)) {
					yAxis.min = 0;
					yAxis.max = 0;
					for (var seriesIndexAux = 0; seriesIndexAux < qViewer.Chart.Series.ByIndex.length; seriesIndexAux++) {						
						if (!IsSplittedChart(qViewer) || seriesIndexAux == seriesIndex) {
							var chartSerieAux = qViewer.Chart.Series.ByIndex[seriesIndexAux];
							yAxis.max = Math.max(yAxis.max, 100 * chartSerieAux.MaximumValue / chartSerieAux.TargetValue);
						}
					}
					if (qViewer.RealChartType == QueryViewerChartType.LinearGauge || yAxis.max != 100) {
						var plotLine = {};
						plotLine.className = "highcharts-dashed-plot-line";		// Clase no estándar de Highcharts
						plotLine.value = 100;
						if (IsSplittedChart(qViewer) || qViewer.Chart.Series.DataFields.length == 1) {
							var cs = IsSplittedChart(qViewer) ? chartSerie : qViewer.Chart.Series.ByIndex[0];
							var y;
							var x;
							var align;
							if (qViewer.RealChartType == QueryViewerChartType.LinearGauge) {
								y = -10;
								x = -5;
								align = "right";
							}
							else {
								y = 15;
								x = 0;
								align = "center";
							}
							plotLine.label = { text: cs.TargetValue, verticalAlign: 'bottom', rotation: 0, y: y, x: x, align: align };
						}
						yAxis.plotLines.push(plotLine);
					}
				}
				if (qViewer.RealChartType == QueryViewerChartType.LinearGauge) {
					yAxis.className = "highcharts-no-axis-line highcharts-no-grid-line";		// Clases no estándar de Highcharts
					yAxis.labels = { enabled: false };
				} else if (qViewer.RealChartType == QueryViewerChartType.CircularGauge) {
					yAxis.lineWidth = 0;
					yAxis.tickPositions = [];
				}
				//Check the direction
				if (qViewer.RealChartType == QueryViewerChartType.Bar || qViewer.RealChartType == QueryViewerChartType.StackedBar || qViewer.RealChartType == QueryViewerChartType.StackedBar100 || qViewer.RealChartType == QueryViewerChartType.LinearGauge) {
					yAxis.reversed = (qv.util.isRTL(qViewer));
				} else {
					yAxis.opposite = qv.util.isRTL(qViewer);
				}
				// Check series min and max values
				var anyPositiveValue = false;
				var anyNegativeValue = false;
				for (var seriesIndex = 0; seriesIndex < qViewer.Chart.Series.ByIndex.length; seriesIndex++) {
					var chartSerieAux = qViewer.Chart.Series.ByIndex[seriesIndex];
					if (chartSerieAux.PositiveValues)
						anyPositiveValue = true;
					if (chartSerieAux.NegativeValues)
						anyNegativeValue = true;
				}
				if (!anyNegativeValue && !anyPositiveValue) {
					if (IsCombinationChart(qViewer) && !IsSplittedChart(qViewer)) {
						yAxis[0].min = 0;
						yAxis[1].min = 0;
						yAxis[0].max = 1;
						yAxis[1].max = 1;
					}
					else {
						yAxis.min = 0;
						yAxis.max = 1;
					}
				}
				else if (gx.lang.gxBoolean(qViewer.XAxisIntersectionAtZero)) {
					if (!anyNegativeValue) {
						if (IsCombinationChart(qViewer) && !IsSplittedChart(qViewer)) {
							yAxis[0].min = 0;
							yAxis[1].min = 0;
						}
						else
							yAxis.min = 0;
					}
					if (!anyPositiveValue) {
						if (IsCombinationChart(qViewer) && !IsSplittedChart(qViewer)) {
							yAxis[0].max = 0;
							yAxis[1].max = 0;
						}
						else
							yAxis.max = 0;
					}
				}
			}
			return yAxis;
		}

		function getPlotOptionsObject(chartType, qViewer) {

			function LinearGaugePlotHeight(qViewer) {
				var marginBottom;
				if (IsSplittedChart(qViewer) || qViewer.Chart.Series.DataFields.length == 1)
					marginBottom = 23 * NumberOfCharts(qViewer);	// por el título del eje Y
				else
					marginBottom = 29;	// por la leyenda
				return qViewer.getContainerControl().offsetHeight - marginBottom;
			}

			function getMarker(qViewer) {
				var marker = { radius: 3, symbol: "circle", states: { hover: { radius: 4 } } };
				if (qViewer.SelectionAllowed()) {
					marker.states.select = { radius: 5, lineWidth: 1 };
				}
				return marker;
			}

			function connector90degrees(labelPosition, connectorPosition, options) {
				var connectorPadding = options.connectorPadding,
					touchingSliceAt = connectorPosition.touchingSliceAt,
					alignment = labelPosition.alignment;
				return ['M',
					labelPosition.x + (alignment === 'left' ? 1 : -1) * connectorPadding,
					labelPosition.y,
					'L',
					touchingSliceAt.x,
					labelPosition.y,
					'L',
					touchingSliceAt.x,
					touchingSliceAt.y
				];
			}
			
			var showvalues = gx.lang.gxBoolean(qViewer.ShowValues);
			var plotOptions = {};
			plotOptions.series = {};
			plotOptions.series.events = {};
			if (qViewer.RealChartType == QueryViewerChartType.CircularGauge) {
				plotOptions.series.dataLabels = {};
				plotOptions.series.dataLabels.enabled = (qViewer.Chart.Series.DataFields.length == 1 && gx.lang.gxBoolean(qViewer.ShowValues)) || IsSplittedChart(qViewer);
				plotOptions.series.dataLabels.y = 0;
				plotOptions.series.dataLabels.borderWidth = 0;
				plotOptions.series.dataLabels.formatter = function () {
					return CircularGaugeTooltipAndDataLabelFormatter(this, qViewer);
				}
				plotOptions.series.marker = { enabled: false };
			}
			else {
				if (showvalues) {
					plotOptions.series.dataLabels = {};
					plotOptions.series.dataLabels.enabled = true;
					plotOptions.series.dataLabels.connectorColor = '#000000'
					plotOptions.series.dataLabels.formatter = function () {
						return DataLabelFormatter(this, qViewer);
					}
					if (qViewer.RealChartType == QueryViewerChartType.LinearGauge)
						plotOptions.series.dataLabels.inside = true;
				}
			}
			if (IsSplittedChart(qViewer) && qViewer.RealChartType != QueryViewerChartType.CircularGauge) {
				plotOptions.series.point = {};
				plotOptions.series.point.events = {};
				var highlightIfVisible = qViewer.RealChartType != QueryViewerChartType.LinearGauge;
				plotOptions.series.point.events.mouseOver = function () { syncPoints(qViewer, this.series.chart.container, this.index, true, highlightIfVisible); };
				plotOptions.series.point.events.mouseOut = function () { syncPoints(qViewer, this.series.chart.container, this.index, false, highlightIfVisible); };
			}
			if (qViewer.ItemClick || qViewer.SelectionAllowed())
				plotOptions.series.events.click = onHighchartsItemClickEventHandler;	// Asocia el manejador para el evento click de la chart
			switch (chartType) {
				case "bar":
					plotOptions.bar = {};
					if (qViewer.RealChartType == QueryViewerChartType.StackedBar) {
						plotOptions.series.stacking = 'normal';
						plotOptions.bar.stacking = 'normal';
					} else if (qViewer.RealChartType == QueryViewerChartType.StackedBar100) {
						plotOptions.series.stacking = 'percent';
						plotOptions.bar.stacking = 'percent';
					}
					if (qViewer.RealChartType == QueryViewerChartType.LinearGauge) {
						var widths = linearGaugeWidths(qViewer.Chart.Series.DataFields.length, 1);
						var width = widths.Width * LinearGaugePlotHeight(qViewer);
						plotOptions.bar.pointWidth = width;
						plotOptions.bar.pointPadding = 0;
						plotOptions.bar.groupPadding = 0;
						var minValue = Number.MAX_VALUE;
						for (var i = 0; i < qViewer.Chart.Series.DataFields.length; i++) {
							var chartSerie = qViewer.Chart.Series.ByIndex[i];
							var value = chartSerie.Points[0].Value / chartSerie.TargetValue;
							if (value < minValue)
								minValue = value;
						}
						var minLength = minValue * qViewer.getContainerControl().offsetWidth;
						plotOptions.bar.borderRadius = Math.min(width / 2, minLength / 2);
					}
					break;
				case "column":
					plotOptions.column = {};
					if (qViewer.RealChartType == QueryViewerChartType.StackedColumn || qViewer.RealChartType == QueryViewerChartType.StackedColumn3D || qViewer.RealChartType == QueryViewerChartType.PolarArea) {
						plotOptions.series.stacking = 'normal';
						plotOptions.column.stacking = 'normal';
					} else if (qViewer.RealChartType == QueryViewerChartType.StackedColumn100) {
						plotOptions.series.stacking = 'percent';
						plotOptions.column.stacking = 'percent';
					}
					if (qViewer.RealChartType == QueryViewerChartType.PolarArea) {
						plotOptions.column.pointPadding = 0;
						plotOptions.column.groupPadding = 0;
					}
					break;
				case "area":
					plotOptions.area = {};
					if (qViewer.RealChartType == QueryViewerChartType.StepArea)
						plotOptions.area.step = "center";
					plotOptions.area.marker = getMarker(qViewer);
					if (qViewer.RealChartType == QueryViewerChartType.StackedArea)
						plotOptions.area.stacking = 'normal';
					else if (qViewer.RealChartType == QueryViewerChartType.StackedArea100)
						plotOptions.area.stacking = 'percent';
					break;
				case "areaspline":
					plotOptions.areaspline = {};
					plotOptions.areaspline.marker = getMarker(qViewer);
					break;
				case "line":
					plotOptions.line = {};
					plotOptions.line.marker = getMarker(qViewer);
					if (qViewer.RealChartType == QueryViewerChartType.StepLine)
						plotOptions.line.step = "center";
					else if (qViewer.RealChartType == QueryViewerChartType.StepTimeline)
						plotOptions.line.step = "left";
					if (IsTimelineChart(qViewer))
						plotOptions.series.connectNulls = true;		// Para el caso de la time se setea esta configuracion para que la Highcharts interpole los datos, evitando que se generen saltos (gaps) en la la linea graficada. Cuando se tienen datos faltantes para el eje x (fechas para las cuales no se obtuvieron datos)
					else if (qViewer.RealChartType == QueryViewerChartType.StackedLine)
						plotOptions.line.stacking = 'normal';
					else if (qViewer.RealChartType == QueryViewerChartType.StackedLine100)
						plotOptions.line.stacking = 'percent';
					break;
				case "spline":
					plotOptions.spline = {};
					plotOptions.spline.marker = getMarker(qViewer);
					break;
				case "pie":
					plotOptions.pie = {};
					if (qViewer.RealChartType == QueryViewerChartType.Doughnut || qViewer.RealChartType == QueryViewerChartType.Doughnut3D)
						plotOptions.pie.innerSize = '35%';
					if (qViewer.RealChartType == QueryViewerChartType.Pie3D || qViewer.RealChartType == QueryViewerChartType.Doughnut3D)
						plotOptions.pie.depth = 35;
					plotOptions.pie.dataLabels = {
						enabled: showvalues,
						connectorColor: '#c3c4c8',
						connectorShape: connector90degrees
					};
					plotOptions.pie.showInLegend = true;
					break;
				case "solidgauge":
					plotOptions.solidgauge = {};
					plotOptions.solidgauge.showInLegend = true;
					plotOptions.solidgauge.rounded = true;
					break;
				case "funnel":
					plotOptions.funnel = {};
					plotOptions.funnel.showInLegend = true;
					plotOptions.funnel.dataLabels = {
						enabled: showvalues,
						connectorColor: '#c3c4c8',
						connectorShape: connector90degrees
					};
					break;
				case "pyramid":
					plotOptions.pyramid = {};
					plotOptions.pyramid.showInLegend = true;
					plotOptions.pyramid.dataLabels = {
						enabled: showvalues,
						connectorColor: '#c3c4c8',
						connectorShape: connector90degrees
					};
					break;
			}
			return plotOptions;
		}

		function getTooltipObject(qViewer) {
			var tooltip = {};
			if (IsTimelineChart(qViewer)) {
				tooltip.borderRadius = 1;
				tooltip.shadow= true;
				tooltip.shared = qViewer.Metadata.Data.length > 1;
				tooltip.formatter = function() {
					if (qViewer.Metadata.Data.length === 1)
						return TooltipFormatter(this, qViewer.Chart.Series.ByIndex, IsSplittedChart(qViewer));
					else
						return DateTimeTooltipFormatter(this, qViewer.Chart.Series.ByIndex)
				}
			}
			else {
				if (qViewer.RealChartType == QueryViewerChartType.StackedColumn100 || qViewer.RealChartType == QueryViewerChartType.StackedBar100 || qViewer.RealChartType == QueryViewerChartType.StackedArea100 || qViewer.RealChartType == QueryViewerChartType.StackedLine100)
					tooltip.formatter = function () {
						return Stacked100TooltipFormatter(this, qViewer);
					}
				else if (IsCircularChart(qViewer))
					tooltip.formatter = function () {
						return PieTooltipFormatter(this, IsSplittedChart(qViewer));
					}
				else if (qViewer.RealChartType == QueryViewerChartType.CircularGauge) {
					tooltip.enabled = (qViewer.Chart.Series.DataFields.length > 1 || !gx.lang.gxBoolean(qViewer.ShowValues)) && !IsSplittedChart(qViewer);
					tooltip.formatter = function () {
						return CircularGaugeTooltipAndDataLabelFormatter(this, qViewer);
					};
					tooltip.positioner = function (labelWidth, labelHeight) {
						return { x: (this.chart.plotWidth - labelWidth) / 2, y: (this.chart.plotHeight) / 2 };
					}
				}
				else
					tooltip.formatter = function () {
						return TooltipFormatter(this, qViewer.Chart.Series.ByIndex, IsSplittedChart(qViewer) && !IsGaugeChart(qViewer));
					}
			}
			tooltip.useHTML = qv.util.isRTL(qViewer);
			return tooltip;
		}
		
		function initializeTimelinePoints(qViewer){
			qViewer.Chart.GroupByPoints = [];
			var pointsGroup = [];
			var points;
			var chartSerie;
			var groupOption = "Days"; //The default initial value is "Days"
			for (var seriesIndex = 0; seriesIndex < qViewer.Chart.Series.ByIndex.length; seriesIndex++) {
				chartSerie = qViewer.Chart.Series.ByIndex[seriesIndex];
				points = groupPoints(qViewer.Chart.Categories, chartSerie.Points, qv.util.XAxisDataType(qViewer), chartSerie.Aggregation, groupOption);
				pointsGroup.push(points);
			}
			qViewer.Chart.GroupByPoints = formattedPointsTimeline(qViewer, getAllSeriesPointsTimeline(pointsGroup));
		}
		
		function getSeriesObject(qViewer, serieIndex, groupOption) {

			function getSerieObject(qViewer, chartSerie, serieIndex, series, groupOption) {
				var serie = {};
				if ((qViewer.ItemClick && qViewer.Metadata.Data[serieIndex].RaiseItemClick))
					serie.className = "highcharts-drilldown-point";
				serie.visible = chartSerie.Visible == QueryViewerVisible.Yes || chartSerie.Visible == QueryViewerVisible.Always;
				serie.events = {
					legendItemClick: function(e) {
						if (chartSerie.Visible == QueryViewerVisible.Always)
							e.preventDefault();
						else {
							var runtimeElements = qv.chart.GetRuntimeMetadata(qViewer);
							var elementName = qViewer.Chart.Series.ByIndex[e.target.index].FieldName;
							var runtimeElement = qv.util.GetElementInCollection(runtimeElements, "Name", elementName);
							runtimeElement.Hidden = !runtimeElement.Hidden; 
							qv.util.autorefresh.UpdateLayoutSameGroup(qViewer, runtimeElements, false);
						}
					}
				};
				if (IsTimelineChart(qViewer)) {
					serie.name = chartSerie.Name;
					serie.data = [];
					serie.turboThreshold = 0;
					if (!qv.util.IsNullColor(chartSerie.Color))
						SetHighchartsColor(qViewer, serie, chartSerie.Color, true);
					var points = groupPoints(qViewer.Chart.Categories, chartSerie.Points, qv.util.XAxisDataType(qViewer), chartSerie.Aggregation, groupOption);
					for (j = 0; j < points.length; j++) {
						var name = points[j].name;
						var xValue = points[j].x;
						var value = points[j].y;
						var date = new gx.date.gxdate(xValue, "Y4MD");
						serie.data[j] = { x: date.Value.getTime() - date.Value.getTimezoneOffset() * 60000, y: value, name: name };
						if (qv.util.IsNullColor(chartSerie.Color))
							SetHighchartsColor(qViewer, serie.data[j], chartSerie.Points[j].Color, true);
					}
					initializeTimelinePoints(qViewer);
				}
				else {
					var widths;
					if (qViewer.RealChartType == QueryViewerChartType.CircularGauge) {
						if (IsSplittedChart(qViewer))
							widths = circularGaugeWidths(1, 1);
						else
							widths = circularGaugeWidths(qViewer.Chart.Series.DataFields.length, serieIndex + 1);
					}
					serie.name = chartSerie.Name;
					serie.data = [];
					serie.turboThreshold = 0;
					if (!qv.util.IsNullColor(chartSerie.Color)) {
						SetHighchartsColor(qViewer, serie, chartSerie.Color, true);
					}
					if ((qViewer.RealChartType == QueryViewerChartType.Radar || qViewer.RealChartType == QueryViewerChartType.FilledRadar || qViewer.RealChartType == QueryViewerChartType.PolarArea))
						serie.pointPlacement = (qViewer.RealChartType == QueryViewerChartType.Radar || qViewer.RealChartType == QueryViewerChartType.FilledRadar ? "on" : null);
					for (j = 0; j < chartSerie.Points.length; j++) {
						var value = chartSerie.Points[j].Value != null ? parseFloat(qv.util.trim(chartSerie.Points[j].Value).replace(",", ".")) : null;
						if (IsGaugeChart(qViewer))
							value = value / chartSerie.TargetValue * 100;
						var name = qViewer.Chart.Categories.Values[j].ValueWithPicture;
						serie.data[j] = {};
						serie.data[j].y = value;
						serie.data[j].name = IsGaugeChart(qViewer) ? "" : name;
						serie.data[j].id = serie.data[j].name;
						if (IsDatetimeXAxis(qViewer)) {
							var xValue = qViewer.Chart.Categories.Values[j].Value;
							var date = new gx.date.gxdate(xValue, "Y4MD");
							serie.data[j].x = date.Value.getTime() - date.Value.getTimezoneOffset() * 60000;
							serie.data[j].id = date;
						}
						if (qViewer.RealChartType == QueryViewerChartType.CircularGauge) {
							serie.data[j].radius = (widths.UpperExtreme).toString() + '%';
							serie.data[j].innerRadius = (widths.LowerExtreme).toString() + '%';
						}
						if (qViewer.RealChartType == QueryViewerChartType.CircularGauge) {
							var color;
							if (!qv.util.IsNullColor(chartSerie.Color))
								color = chartSerie.Color;
							else
								color = chartSerie.Points[0].Color;
							SetHighchartsColor(qViewer, serie.data[j], color, true);
						}
						else if (qv.util.IsNullColor(chartSerie.Color))
							SetHighchartsColor(qViewer, serie.data[j], chartSerie.Points[j].Color, true);
					}
				}
				return serie;
			}

			var series = [];
			for (var seriesIndexAux = 0; seriesIndexAux < qViewer.Chart.Series.ByIndex.length; seriesIndexAux++) {
				if (!IsSplittedChart(qViewer) || seriesIndexAux == serieIndex) {
					var chartSerie = qViewer.Chart.Series.ByIndex[seriesIndexAux];
					var serie = getSerieObject(qViewer, chartSerie, seriesIndexAux, series, groupOption)
					var k = serieIndex != null ? serieIndex : seriesIndexAux;
					if (IsCombinationChart(qViewer)) {
						if (k % 2 == 0) {
							serie.type = 'column';
							serie.yAxis = 0;
						}
						else {
							serie.type = 'line';
							serie.yAxis = IsSplittedChart(qViewer) ? 0 : 1;
						}
					}
					series.push(serie);
				}
			}

			return series;

		}

		function getPaneObject(qViewer, serieIndex) {
			var pane = {};
			if (qViewer.RealChartType == QueryViewerChartType.CircularGauge) {
				pane.background = [];
				var widths;
				if (IsSplittedChart(qViewer))
					widths = circularGaugeWidths(1, 1);
				for (var seriesIndexAux = 0; seriesIndexAux < qViewer.Chart.Series.ByIndex.length; seriesIndexAux++) {
					if (!IsSplittedChart(qViewer) || seriesIndexAux == serieIndex) {
						var chartSerie = qViewer.Chart.Series.ByIndex[seriesIndexAux];
						var oneBackground = {};
						if (!IsSplittedChart(qViewer))
							widths = circularGaugeWidths(qViewer.Chart.Series.DataFields.length, seriesIndexAux + 1);
						oneBackground.outerRadius = (widths.UpperExtreme).toString() + '%';
						oneBackground.innerRadius = (widths.LowerExtreme).toString() + '%';
						var color;
						if (!qv.util.IsNullColor(chartSerie.Color))
							color = chartSerie.Color;
						else
							color = chartSerie.Points[0].Color;
						SetHighchartsColor(qViewer, oneBackground, color, false);
						oneBackground.borderWidth = 0;
						pane.background.push(oneBackground);
					}
				}
			}
			return pane;
		}

		var groupOption = qv.util.XAxisDataType(qViewer) == QueryViewerDataType.Date ? "Days" : "Seconds";

		var options = {};
		options.qv = {};
		options.qv.viewerId = qViewer.userControlId(); // Almacena el identificador del control en las opciones de la grafica
		options.qv.seriesIndex = serieIndex;

		options.chart = getChartObject(qViewer, serieIndex);
		options.credits = getNoCreditsObject();
		options.legend = getLegendObject(qViewer);
		options.title = getTitleObject(qViewer, serieIndex);
		options.subtitle = getSubtitleObject(qViewer, chartSerie);
		options.pane = getPaneObject(qViewer, serieIndex);
		options.xAxis = getXAxisObject(qViewer, serieIndex);
		options.yAxis = getYAxisObject(qViewer, chartSerie, serieIndex);
		options.plotOptions = getPlotOptionsObject(options.chart.type, qViewer);
		options.tooltip = getTooltipObject(qViewer);
		options.series = getSeriesObject(qViewer, serieIndex, groupOption);

		return options;
	}

	function getAllHighchartOptions(qViewer) {
		var arrOptions = [];
		if (!IsSplittedChart(qViewer)) {
			var options = getHighchartOptions(qViewer, null, null);
			arrOptions.push(options);
		}
		else {
			for (var seriesIndex = 0; seriesIndex < qViewer.Chart.Series.ByIndex.length; seriesIndex++) {
				var chartSerie = qViewer.Chart.Series.ByIndex[seriesIndex];
				var options = getHighchartOptions(qViewer, chartSerie, seriesIndex);
				arrOptions.push(options);
			}
		}
		return arrOptions;
	}

	function GetDatumByDataField(qViewer, dataField) {
		for (var i = 0; i < qViewer.Metadata.Data.length; i++)
			if (qViewer.Metadata.Data[i].DataField == dataField)
				return qViewer.Metadata.Data[i];
	}

	function XAxisTitle(qViewer) {
		var xAxisTitle = "";
		if (qViewer.XAxisTitle == "")
			for (var i = 0; i < qViewer.Metadata.Axes.length; i++) {
				var axis = qViewer.Metadata.Axes[i];
				if (axis.Visible == QueryViewerVisible.Yes || axis.Visible == QueryViewerVisible.Always)
					xAxisTitle += (xAxisTitle == "" ? "" : ", ") + qv.util.getTranslation(axis.Title);		// Se concatenan los títulos
			}
		else
			xAxisTitle = qv.util.getTranslationAlsoIfStatic(qViewer.XAxisTitle);
		return xAxisTitle;
	}

	function YAxisTitle(qViewer) {
		var yAxisTitle = "";
		if (qViewer.YAxisTitle == "") {
			if (qViewer.Chart.Series.DataFields.length == 1) {
				var fieldTitle = GetDatumByDataField(qViewer, qViewer.Chart.Series.DataFields[0]).Title;
				yAxisTitle = qv.util.getTranslation(fieldTitle);
			}
		}
		else
			yAxisTitle = qv.util.getTranslationAlsoIfStatic(qViewer.YAxisTitle);
		return yAxisTitle;
	}

	function renderChart(qViewer) {
		var i = 0;
		var qvClasses = qv.util.GetContainerControlClasses(qViewer);
		if (qvClasses != "")
			qv.util.SetUserControlClass(qViewer, qvClasses);
		var errMsg = qv.util.ProcessDataAndMetadata(qViewer);
		if (errMsg == "") {
			splitChartContainer(qViewer);
			var arrOptions = getAllHighchartOptions(qViewer);
			AddHighchartsCSSRules(qViewer);
			SetHighchartsOptions();
			var HCCharts = [];
			for (var serie = 0; serie < arrOptions.length; serie++) {
				HCChart = new Highcharts.Chart(arrOptions[serie], HCFinishedLoadingCallback);
				HCCharts.push(HCChart);
			}
			qViewer.Charts = HCCharts;
			if (IsTimelineChart(qViewer))
				FillHeaderAndFooter(HCCharts, arrOptions);
			qViewer._ControlRenderedTo = qViewer.RealType;
			qv.util.hideActivityIndicator(qViewer);
		}
		else
			qv.util.renderError(qViewer, errMsg);
	}

	// ------------------------------------------------------ Timeline ------------------------------------------------------

	var prevClickedZoomId = null
	var viewerId = null
	var TimelineHeaderHeight = 35;
	var TimelineFooterHeight = 50;

	function isNumeric(n) {
		return !isNaN(parseFloat(n)) && isFinite(n);
	}

	// Determina si el navegador es Microsoft Internet Explorer en una version anterior a la 9	
	function isOldIEf() {
		return gx.util.browser.isIE() && gx.util.browser.ieVersion() <= 8.0;
	}

	function getZoomId(z) {
		return (viewerId + "_Zoom_" + z + "m");
	}

	function getZoomControl(z) {
		if (isNumeric(z))
			return gx.dom.el(getZoomId(z));
		else //control id
			return gx.dom.el(z);
	}

	function changeZoomControlUnderline(z, decoration) {
		zoom = getZoomControl(z);
		if (zoom)
			zoom.style.textDecoration = decoration;
	}
	
	function selectZoom(z) {
		changeZoomControlUnderline(z, "underline");
	}

	function deselectZoom(z) {
		changeZoomControlUnderline(z, "none");
	}

	function triggerZoom(z) {
		zoom = getZoomControl(z);
		if (zoom)
			zoom.onclick();
		else
			if (z != 0) {		// Intento con un zoom más alejado
				var newZoom;
				switch (z) {
					case 12:
						newZoom = 6;
						break;
					case 6:
						newZoom = 3;
						break;
					case 3:
						newZoom = 2;
						break;
					case 2:
						newZoom = 1;
						break;
					case 1:
						newZoom = 0;
						break;
				}
				triggerZoom(newZoom);
			}
	}

	function hideZoom(z) {
		zoom = getZoomControl(z);
		if (zoom)
			zoom.style.display = "none";
	}

	function showZoom(z) {
		zoom = getZoomControl(z);
		if (zoom)
			zoom.style.display = "";
	}

	function getSelectedZoomFactor() {
		return parseInt(prevClickedZoomId.substring(0, prevClickedZoomId.length - 1).substring(prevClickedZoomId.indexOf("_Zoom_") + 6));
	}

	//Esta funcion se invoca mas arriba en el handler del evento de seleccion de la timeline
	function deselectActiveZoom() {
		deselectZoom(prevClickedZoomId);
	}

	function EnableDisableCompareControls(qViewerId, enabled) {
		gx.dom.el(qViewerId + "_options_compare_enable").disabled = !enabled;
		gx.dom.el(qViewerId + "_options_compare_text").disabled = !enabled;
		gx.dom.el(qViewerId + "_options_compare_text").style.opacity = (!enabled ? 0.5 : 1);
		gx.dom.el(qViewerId + "_options_compare_options").disabled = !enabled;
		gx.dom.el(qViewerId + "_options_compare_options").style.opacity = (!enabled ? 0.5 : 1);
	}

	function EnableCompareControls(qViewerId, enabled) {
		EnableDisableCompareControls(qViewerId, true);
	}

	function DisableCompareControls(qViewerId, enabled) {
		EnableDisableCompareControls(qViewerId, false);
	}

	var sliderCursorWidth = 10;
	var sliderClickedOffsetX = 0;
	var sliderClickedqViewerId = "";
	var sliderClickedPaddingLeft = 0;
	var sliderClickedPaddingRight = 0;
	var sliderClickedRangeWidth = 0;
	var sliderClickedContainerWidth = 0;
	var sliderResizingLeft = false;
	var sliderResizingRight = false;
	var sliderMovingBar = false;

	function optionsId(qViewerId) {
		return qViewerId + "_options";
	}

	function centerId(qViewerId) {
		return qViewerId + "_center";
	}

	function footerId(qViewerId) {
		return qViewerId + "_footer";
	}

	function footerSliderId(qViewerId) {
		return qViewerId + "_footer_slider";
	}

	function footerChartId(qViewerId) {
		return qViewerId + "_footer_chart";
	}

	function footerRangeId(qViewerId) {
		return qViewerId + "_footer_range";
	}

	function footerLeftCursorId(qViewerId) {
		return qViewerId + "_footer_left_cursor";
	}

	function footerRightCursorId(qViewerId) {
		return qViewerId + "_footer_right_cursor";
	}

	function footerCenterId(qViewerId) {
		return qViewerId + "_footer_center";
	}

	function InitializeSlider(qViewerId, minValue, maxValue) {
		minValue = setMinAndMax(minValue, 0, 100);
		maxValue = setMinAndMax(maxValue, 0, 100);

		jQuery("#" + footerId(qViewerId))
			.css("width", "100%")
			.css("height", TimelineFooterHeight.toString() + "px");
		jQuery("#" + footerChartId(qViewerId))
			.css("width", "100%")
			.css("height", (TimelineFooterHeight-2).toString() + "px");

		var controlWidth = qv.collection[qViewerId].getContainerControl().offsetWidth;
		var paddingLeft = minValue * controlWidth / 100;
		var paddingRight = (100 - maxValue) * controlWidth / 100;
		// Fix: PaddingLeft y PaddingRight deben dejar lugar para los cursores. Esto hace que no se pueda llegar a un rango de tamaño cero nunca, pero queda feo si se solapan los cursores
		if (controlWidth - paddingLeft - paddingRight < 2 * sliderCursorWidth) {
			var pixelsToRemove = 2 * sliderCursorWidth - (controlWidth - paddingLeft - paddingRight);
			var pixelsToRemoveLeft;
			var pixelsToRemoveRight;
			if (pixelsToRemove % 2 == 0)
				pixelsToRemoveLeft = pixelsToRemove / 2;
			else
				pixelsToRemoveLeft = (pixelsToRemove + 1) / 2;
			pixelsToRemoveRight = pixelsToRemove - pixelsToRemoveLeft;
			paddingLeft -= pixelsToRemoveLeft;
			paddingRight -= pixelsToRemoveRight;
			if (paddingLeft < 0)
			{
				paddingRight += paddingLeft;
				paddingLeft = 0;
			}
			if (paddingRight < 0)
			{
				paddingLeft += paddingRight;
				paddingRight = 0;
			}
		}
		var width = controlWidth - paddingLeft - paddingRight;

		jQuery("#" + footerSliderId(qViewerId))
			.css("width", "100%")
			.css("height", TimelineFooterHeight.toString() + "px")
			.css("padding-left", (100 * paddingLeft / controlWidth).toString() + "%")
			.css("padding-right", (100 * paddingRight / controlWidth).toString() + "%");
		jQuery("#" + footerRangeId(qViewerId))
			.css("width", "100%")
			.css("height", TimelineFooterHeight.toString() + "px");
		jQuery("#" + footerLeftCursorId(qViewerId))
			.css("width", sliderCursorWidth.toString() + "px")
			.css("height", TimelineFooterHeight.toString() + "px");
		jQuery("#" + footerRightCursorId(qViewerId))
			.css("width", sliderCursorWidth.toString() + "px")
			.css("height", TimelineFooterHeight.toString() + "px");
		jQuery("#" + footerCenterId(qViewerId))
			.css("width", "calc(100% - " + 2 * sliderCursorWidth + "px)")
			.css("height", TimelineFooterHeight.toString() + "px")
			.css("left", sliderCursorWidth.toString() + "px");
	}

	function setMin(value, minValue)
	{
		return Math.max(value, minValue);
	}

	function setMax(value, maxValue) {
		return Math.min(value, maxValue);
	}

	function setMinAndMax(value, minValue, maxValue) {
		return setMax(setMin(value, minValue), maxValue);
	}

	function normalizedSliderOffset(qViewerId, event) {
		var paddingLeft = parseInt(jQuery("#" + footerSliderId(qViewerId)).css("padding-left"));
		var barWidth = parseInt(jQuery("#" + footerRangeId(qViewerId)).css("width"));
		var offsetX;
		if (event.originalEvent.touches)
			offsetX = event.originalEvent.touches[0].pageX - event.originalEvent.touches[0].target.offsetLeft;
		else
			offsetX = event.offsetX;
		switch (event.target.id) {
			case footerSliderId(qViewerId):
				return offsetX;
			case footerLeftCursorId(qViewerId):
				return offsetX + paddingLeft;
			case footerCenterId(qViewerId):
				return offsetX + paddingLeft;
			case footerRightCursorId(qViewerId):
				return offsetX + paddingLeft + barWidth - sliderCursorWidth;
		}
	}

	function attachSliderEvents(qViewerId) {

		function leftCursorMousedown(event) {
			event.preventDefault();
			sliderResizingLeft = true;
		}

		function rightCursorMousedown(event) {
			event.preventDefault();
			sliderResizingRight = true;
		}

		function centerMousedown(event) {
			event.preventDefault();
			if (!sliderResizingLeft && !sliderResizingRight)
				sliderMovingBar = true;
		}

		function sliderMousedown(event) {
			event.preventDefault();
			sliderClickedqViewerId = qViewerId;
			var slider = jQuery("#" + footerSliderId(sliderClickedqViewerId));
			var range = jQuery("#" + footerRangeId(sliderClickedqViewerId));
			var paddingLeft = parseInt(slider.css("padding-left"));
			sliderClickedOffsetX = normalizedSliderOffset(sliderClickedqViewerId, event);
			sliderClickedPaddingLeft = parseInt(slider.css("padding-left"));
			sliderClickedPaddingRight = parseInt(slider.css("padding-right"));
			sliderClickedContainerWidth = parseInt(slider.css("width"));
			sliderClickedRangeWidth = parseInt(range.css("width"));
		}

		function documentMouseup(event) {
			if (sliderMovingBar || sliderResizingRight || sliderResizingLeft) {
				var slider = jQuery("#" + footerSliderId(sliderClickedqViewerId));
				var qViewer = qv.collection[sliderClickedqViewerId];
				var compare = gx.dom.el(sliderClickedqViewerId + '_options_compare_enable').checked;
				var controlWidth = qViewer.getContainerControl().offsetWidth;
				var containerId;
				var containers;
				if (IsTimelineChart(qViewer))
					containerId = centerId(qViewer.userControlId());
				else
					containerId = qViewer.getContainerControl().id;
				if (IsSplittedChart(qViewer))
					containers = jQuery("[id^=" + containerId + "_chart]");
				else
					containers = jQuery("#" + containerId);
				var charts = [];
				jQuery.each(containers, function (index, div) {
					var chart = jQuery("#" + div.id).highcharts();
					charts.push(chart);
				});
				var firstChart = charts[0];
				var paddingLeft = parseInt(slider.css("padding-left"));
				var paddingRight = parseInt(slider.css("padding-right"));
				var minPercent = 100 * paddingLeft / controlWidth;
				var maxPercent = 100 * (1 - paddingRight / controlWidth);
				if (minPercent == 0 && maxPercent == 100)
					jQuery.each(charts, function (index, chart) {
						chart.zoomOut();
					});
				else {
					var extremes = firstChart.get('xaxis').getExtremes();
					var qvOptions = firstChart.options.qv;
					var minDate = qvOptions.dataMin + minPercent / 100 * (qvOptions.dataMax - qvOptions.dataMin);
					var maxDate = qvOptions.dataMin + maxPercent / 100 * (qvOptions.dataMax - qvOptions.dataMin);
					var redraw = (compare) ? false : true;
					jQuery.each(charts, function (index, chart) {
						chart.get('xaxis').setExtremes(minDate, maxDate, redraw);
					});
				}
				if (compare)
					GroupAndCompareFunction(charts);
				if (sliderResizingRight || sliderResizingLeft) {
					deselectZoom(prevClickedZoomId);
					prevClickedZoomId = null;
				}
			}
			sliderMovingBar = false;
			sliderResizingLeft = false;
			sliderResizingRight = false;
		}

		function sliderMousemove(event) {
			if (sliderMovingBar || sliderResizingRight || sliderResizingLeft) {
				var increment = normalizedSliderOffset(sliderClickedqViewerId, event) - sliderClickedOffsetX;
				if (sliderResizingLeft)
					increment = setMax(increment, sliderClickedRangeWidth - 2 * sliderCursorWidth);
				else
					increment = setMax(increment, sliderClickedPaddingRight);
				if (sliderResizingRight)
					increment = setMin(increment, -sliderClickedRangeWidth + 2 * sliderCursorWidth);
				else
					increment = setMin(increment, -sliderClickedPaddingLeft)
				if (increment != 0) {
					var center = jQuery("#" + footerCenterId(sliderClickedqViewerId));
					var slider = jQuery("#" + footerSliderId(sliderClickedqViewerId));
					var range = jQuery("#" + footerRangeId(sliderClickedqViewerId));
					if (sliderResizingLeft)
						slider.css("padding-left", (100 * (sliderClickedPaddingLeft + increment) / sliderClickedContainerWidth).toString() + "%");
					else if (sliderResizingRight)
						slider.css("padding-right", (100 * (sliderClickedPaddingRight - increment) / sliderClickedContainerWidth).toString() + "%");
					else {
						slider.css("padding-left", (100 * (sliderClickedPaddingLeft + increment) / sliderClickedContainerWidth).toString() + "%");
						slider.css("padding-right", (100 * (sliderClickedPaddingRight - increment) / sliderClickedContainerWidth).toString() + "%");
					}
				}

			}
		}

		var leftCursor = jQuery("#" + footerLeftCursorId(qViewerId));
		var rightCursor = jQuery("#" + footerRightCursorId(qViewerId));
		var center = jQuery("#" + footerCenterId(qViewerId));
		var slider = jQuery("#" + footerSliderId(qViewerId));
		var range = jQuery("#" + footerRangeId(qViewerId));

		// Attachments for mouse events
		leftCursor.mousedown(function (event) {
			leftCursorMousedown(event);
		});
		rightCursor.mousedown(function (event) {
			rightCursorMousedown(event);
		});
		center.mousedown(function (event) {
			centerMousedown(event);
		});
		slider.mousedown(function (event) {
			sliderMousedown(event);
		});
		jQuery(document).mouseup(function (event) {
			documentMouseup(event);
		});
		slider.mousemove(function (event) {
			sliderMousemove(event);
		});


		// Attachments for finger events
		leftCursor.on("touchstart", function (event) {
			leftCursorMousedown(event);
		});
		rightCursor.on("touchstart", function (event) {
			rightCursorMousedown(event);
		});
		center.on("touchstart", function (event) {
			centerMousedown(event);
		});
		slider.on("touchstart", function (event) {
			sliderMousedown(event);
		});
		jQuery(document).on("touchend", function (event) {
			documentMouseup(event);
		});
		jQuery(document).on("touchcancel", function (event) {
			documentMouseup(event);
		});
		slider.on("touchmove", function (event) {
			sliderMousemove(event);
		});

	}

	function CreateFooter(parent, qViewerId) {
		var div1 = qv.util.dom.createDiv(parent, footerSliderId(qViewerId), "gx-qv-footer-slider", "", {}, "");
		var div2 = qv.util.dom.createDiv(div1, footerRangeId(qViewerId), "gx-qv-footer-range", "", {}, "");
		qv.util.dom.createDiv(div2, footerLeftCursorId(qViewerId), "gx-qv-footer-left-cursor", "", {}, "");
		qv.util.dom.createDiv(div2, footerRightCursorId(qViewerId), "gx-qv-footer-right-cursor", "", {}, "");
		qv.util.dom.createDiv(div2, footerCenterId(qViewerId), "gx-qv-footer-center", "", {}, "");
		qv.util.dom.createDiv(parent, footerChartId(qViewerId), "gx-qv-footer-chart", "", {}, "");
	}

	function getTimelineFooterChartOptions(qViewer, arrOptions)
	{
		var containerId = footerChartId(qViewer.userControlId());
		var chartType = (qViewer.RealChartType == QueryViewerChartType.SmoothTimeline ? "spline" : "line");
		var step = qViewer.RealChartType == QueryViewerChartType.StepTimeline ? "left" : "";
		var series = [];
		if (!IsSplittedChart(qViewer))
			for (var i = 0; i < arrOptions[0].series.length; i++)
				series.push(arrOptions[0].series[i]);
		else {
			for (var i = 0; i < arrOptions.length; i++)
				series.push(arrOptions[i].series[0]);
		}
		return qv.chart.getSparklineChartOptions(qViewer, containerId, chartType, false, step, series);
	}

	function getAllSeriesPointsTimeline(pointsGroupByIndex) {
		var result = pointsGroupByIndex.reduce(function (accumulator, serie, index) {
			serie.forEach(function (e) {
				var key = 'y' + (index + 1);
				if (!accumulator[e.x]) {
					accumulator[e.x] = { x: e.x };
				}
				accumulator[e.x][key] = e.y;
			});
			return accumulator;
		}, {});

		return Object.values(result);
	}


	function GroupAndCompareFunction(charts) {
		var firstChart = charts[0];
		var viewerId = firstChart.options.qv.viewerId;
		var qViewer = qv.collection[viewerId];

		// Chequea si esta marcado el chkbox que indica que se quiere comparar
		var compare = gx.dom.el(viewerId + "_options_compare_enable").checked;

		// Obtiene el tipo de periodo contra el que se quiere comparar
		var extremes = firstChart.get('xaxis').getExtremes();
		if (extremes.userMin != undefined)
			extremes.min = extremes.userMin;	//Sin esto, la llamada a setextremes (con redraw en false) realizado en el zoom no actualiza el min hasta el próximo dibujado.
		if (extremes.userMax != undefined)
			extremes.max = extremes.userMax;	//Sin esto, la llamada a setextremes (con redraw en false) realizado en el zoom no actualiza el min hasta el próximo dibujado.

		if (compare) {

			var options = gx.dom.el(viewerId + "_options_compare_options").children;
			var selectedOptionValue;
			for (ind = 0; options[ind] != undefined && selectedOptionValue == undefined; ind++) {
				if (options[ind].selected) {
					selectedOptionValue = options[ind].value;
				}
			}
			var minDateCompare;
			var maxDateCompare;
			if (selectedOptionValue == 'PrevPeriod') {
				maxDateCompare = new Date(extremes.min);
				minDateCompare = new Date(extremes.min - (extremes.max - extremes.min));
			} else if (selectedOptionValue == 'PrevYear') {
				minDateCompare = new Date(extremes.min);
				minDateCompare = new Date(minDateCompare.setFullYear(minDateCompare.getFullYear() - 1));
				maxDateCompare = new Date(extremes.max);
				maxDateCompare = new Date(maxDateCompare.setFullYear(maxDateCompare.getFullYear() - 1));
			}
			minDateCompare = minDateCompare.getTime();
			maxDateCompare = maxDateCompare.getTime();

			hideZoom(viewerId + "_Zoom_0m");//Si esta habilitada la comparación oculto el zoom all
		}
		else
			showZoom(viewerId + "_Zoom_0m");

		// Elimina todas las series existentes de la grafica
		jQuery.each(charts, function (index, chart) {
			var series_colorIndexes = []
			while (chart.series.length > 0) {
				if (!chart.options.qv.colorIndexesUsed) {
					series_colorIndexes.push(chart.series[0].colorIndex);
				}
				chart.series[0].remove(true)
			}
			if (!chart.options.qv.colorIndexesUsed) {
				chart.options.qv.colorIndexesUsed = series_colorIndexes;
			}
		});

		// Carga las series con los datos que correspondan
		var ns = 0
		var pointsGroupByIndex= []
		for (var seriesIndex = 0; seriesIndex < qViewer.Chart.Series.ByIndex.length; seriesIndex++) {
			var chartSerie = qViewer.Chart.Series.ByIndex[seriesIndex];
			seriesName = chartSerie.Name;
			var chart;
			var serieColorIndex;
			if (IsSplittedChart(qViewer)) {
				chart = charts[ns];
				serieColorIndex = chart.options.qv.colorIndexesUsed[0];
			}
			else {
				chart = firstChart;
				serieColorIndex = chart.options.qv.colorIndexesUsed[ns];
			}

			// Serie con el periodo seleccionado por el usuario
			var serie1 = {};
			serie1.turboThreshold = 0;
			serie1.colorIndex = serieColorIndex;
			serie1.id = seriesName + "1";
			serie1.name = seriesName;
			serie1.data = [];

			if (compare) {
				// Serie con el periodo contra el que se va a comparar
				var serie2 = {};
				serie2.className = "highcharts-dashed-series-line";
				serie2.turboThreshold = 0;
				serie2.colorIndex = serieColorIndex;
				serie2.id = seriesName + "2";
				serie2.name = seriesName;
				serie2.data = [];
			}

			var points;
			var groupOption = document.getElementById(viewerId + "_options_group_options").value;
			points = groupPoints(qViewer.Chart.Categories, chartSerie.Points, qv.util.XAxisDataType(qViewer), chartSerie.Aggregation, groupOption);
			pointsGroupByIndex.push(points);
			for (i = 0; i < points.length; i++) {
				var value = points[i].y;
				var date = new gx.date.gxdate(points[i].x, "Y4MD");
				var name = points[i].name;
				var timeValue1 = date.Value.getTime() - date.Value.getTimezoneOffset() * 60000;
				var original_time_value = date.Value.getTime() - date.Value.getTimezoneOffset() * 60000;
				if (compare) {
					var addToSerie1 = false;
					var addToSerie2 = false;
					if (timeValue1 <= extremes.max && timeValue1 >= extremes.min) {
						addToSerie1 = true;
					}
					if (timeValue1 <= maxDateCompare && timeValue1 >= minDateCompare) {
						addToSerie2 = true;
						var tmpDate = new Date(timeValue1);
						var timeValue2;
						if (selectedOptionValue == "PrevPeriod") {
							if (chart.options.qv.predef_zoom == "1m") {
								timeValue2 = tmpDate.setMonth(tmpDate.getMonth() + 1);
							} else if (chart.options.qv.predef_zoom == "2m") {
								timeValue2 = tmpDate.setMonth(tmpDate.getMonth() + 2);
							} else if (chart.options.qv.predef_zoom == "3m") {
								timeValue2 = tmpDate.setMonth(tmpDate.getMonth() + 3);
							} else if (chart.options.qv.predef_zoom == "6m") {
								timeValue2 = tmpDate.setMonth(tmpDate.getMonth() + 6);
							} else if (chart.options.qv.predef_zoom == "12m") {
								timeValue2 = tmpDate.setFullYear(tmpDate.getFullYear() + 1);
							} else {
								timeValue2 += extremes.max - extremes.min;
							}
						} else if (selectedOptionValue == "PrevYear") {
							timeValue2 = tmpDate.setFullYear(tmpDate.getFullYear() + 1);
						}
					}
					if (addToSerie1) {
						var point = {};
						point.x = timeValue1;
						point.y = value;
						point.name = name;
						serie1.data.push(point);
					}
					if (addToSerie2) {
						var point = {};
						point.x = timeValue2;
						point.y = value;
						point.name = name;
						point.real_x = original_time_value;
						serie2.data.push(point);
					}
				} else {
					serie1.data.push({ x: timeValue1, y: value, name: name });
				}
			}

			chart.addSeries(serie1);
			if (compare) {
				chart.addSeries(serie2);
			}
			ns++;
		}
		
		qViewer.Chart.GroupByPoints = formattedPointsTimeline(qViewer, getAllSeriesPointsTimeline(pointsGroupByIndex));
	}
	
	function getSuitableZoomFactor(points, maxPoints) {
		if (points.length < maxPoints)
			return 0;
		else {
			var maxValue = points[points.length - 1].x;
			var minValue = points[points.length - maxPoints].x;
			var cantMeses = (maxValue - minValue) / 1000 / 3600 / 24 / (365 / 12);
			if (cantMeses <= 1)
				return 1;
			else if (cantMeses <= 2)
				return 2;
			else if (cantMeses <= 3)
				return 3;
			else if (cantMeses <= 6)
				return 6;
			else
				return 12;
		}
	}

	function FillHeaderAndFooter(charts, arrOptions)
	{

		function CreateGroupByCombo(parent, qViewer, showYears, showSemesters, showQuarters, showMonths, showWeeks, showHours, showMinutes) {
			var qViewerId = qViewer.userControlId();
			var select = qv.util.dom.createSelect(parent, optionsId(qViewerId) + "_group_options");
			if (qv.util.XAxisDataType(qViewer) == QueryViewerDataType.DateTime) {
				qv.util.dom.createOption(select, "Seconds", qViewer._groupOption == "Seconds", gx.getMessage("GXPL_QViewerSeconds"));
				if (showMinutes) {
					qv.util.dom.createOption(select, "Minutes", qViewer._groupOption == "Minutes", gx.getMessage("GXPL_QViewerMinutes"));
					if (showHours) {
						qv.util.dom.createOption(select, "Hours", qViewer._groupOption == "Hours", gx.getMessage("GXPL_QViewerHours"));
					}
				}
			}
			if (showDays || qv.util.XAxisDataType(qViewer) == QueryViewerDataType.Date) {
				qv.util.dom.createOption(select, "Days", qViewer._groupOption == "Days", gx.getMessage("GXPL_QViewerDays"));
				if (showWeeks) {
					qv.util.dom.createOption(select, "Weeks", qViewer._groupOption == "Weeks", gx.getMessage("GXPL_QViewerWeeks"));
					if (showMonths) {
						qv.util.dom.createOption(select, "Months", qViewer._groupOption == "Months", gx.getMessage("GXPL_QViewerMonths"));
						if (showQuarters) {
							qv.util.dom.createOption(select, "Quarters", qViewer._groupOption == "Quarters", gx.getMessage("GXPL_QViewerQuarters"));
							if (showSemesters) {
								qv.util.dom.createOption(select, "Semesters", qViewer._groupOption == "Semesters", gx.getMessage("GXPL_QViewerSemesters"));
								if (showYears) {
									qv.util.dom.createOption(select, "Years", qViewer._groupOption == "Years", gx.getMessage("GXPL_QViewerYears"));
								}
							}
						}
					}
				}
			}
			return select;
		}

		function CreateHeader(parent, qViewer, include1m, include2m, include3m, include6m, include1y, showYears, showSemesters, showQuarters, showMonths, showWeeks, showHours, showMinutes) {

			function CreateHeaderGroup(parent) {
				return qv.util.dom.createDiv(parent, "", "QVTimelineHeaderGroup", "", { height: TimelineHeaderHeight + "px", flexGrow: 1 }, "");
			}

			function CreateZoomItem(parent, text, id) {
				return qv.util.dom.createAnchor(parent, id, { cursor: "pointer", paddingLeft: "6px" }, text);
			}

			var qViewerId = qViewer.userControlId();
			var divFlexTable = qv.util.dom.createDiv(parent, "", "QVTimelineHeader", "", { display: "flex", flexDirection: "row", flexWrap: "wrap" }, "");
			var headerGroup1 = CreateHeaderGroup(divFlexTable);
			var headerGroup2 = CreateHeaderGroup(divFlexTable);
			var headerGroup3 = CreateHeaderGroup(divFlexTable);

			var headerGroup1Div = qv.util.dom.createDiv(headerGroup1, "", "", "", { "float": "left" }, "");

			// Zoom
			qv.util.dom.createText(headerGroup1Div, gx.getMessage("GXPL_QViewerJSChartZoom"));
			if (include1m) {
				CreateZoomItem(headerGroup1Div, gx.getMessage("GXPL_QViewerJSChartZoomLevelToOneMonth"), qViewerId + "_Zoom_1m");
				if (include2m) {
					CreateZoomItem(headerGroup1Div, gx.getMessage("GXPL_QViewerJSChartZoomLevelToTwoMonth"), qViewerId + "_Zoom_2m");
					if (include3m) {
						CreateZoomItem(headerGroup1Div, gx.getMessage("GXPL_QViewerJSChartZoomLevelToThreeMonth"), qViewerId + "_Zoom_3m");
						if (include6m) {
							CreateZoomItem(headerGroup1Div, gx.getMessage("GXPL_QViewerJSChartZoomLevelToSixMonth"), qViewerId + "_Zoom_6m");
							if (include1y) {
								CreateZoomItem(headerGroup1Div, gx.getMessage("GXPL_QViewerJSChartZoomLevelToOneYear"), qViewerId + "_Zoom_12m");
							}
						}
					}
				}
			}
			CreateZoomItem(headerGroup1Div, gx.getMessage("GXPL_QViewerJSChartZoomLevelToAll"), qViewerId + "_Zoom_0m");

			// Group by
			var headerGroup2Div = qv.util.dom.createDiv(headerGroup2, "", "", "", { "float": "right", paddingLeft: "12px" }, "");
			qv.util.dom.createSpan(headerGroup2Div, optionsId(qViewerId) + "_groupby_text", "", "", { whiteSpace: "nowrap", paddingRight: "6px" }, null, gx.getMessage("GXPL_QViewerGroupBy"));
			CreateGroupByCombo(headerGroup2Div, qViewer, showYears, showSemesters, showQuarters, showMonths, showWeeks, showHours, showMinutes);

			// Compare to
			var headerGroup3Div = qv.util.dom.createDiv(headerGroup3, "", "", "", { "float": "right", paddingLeft: "12px" }, "");
			qv.util.dom.createInput(headerGroup3Div, optionsId(qViewerId) + "_compare_enable", "checkbox", { verticalAlign: "text-bottom" });
			qv.util.dom.createSpan(headerGroup3Div, optionsId(qViewerId) + "_compare_text", "", "", { whiteSpace: "nowrap", paddingRight: "6px", paddingLeft: "6px" }, null, gx.getMessage("GXPL_QViewerCompareWith"));
			var select = qv.util.dom.createSelect(headerGroup3Div, optionsId(qViewerId) + "_compare_options");
			qv.util.dom.createOption(select, "PrevPeriod", false, gx.getMessage("GXPL_QViewerPreviousPeriod"));
			qv.util.dom.createOption(select, "PrevYear", false, gx.getMessage("GXPL_QViewerPreviousYear"));

			return divFlexTable;
		}

		// Crea un nuevo div conteniendo los links para hacer zoom predefenidos programaticamente.
		var firstChart = charts[0];
		viewerId = firstChart.options.qv.viewerId;
		var qViewer = qv.collection[viewerId];
		var divOptions = document.getElementById(optionsId(viewerId));
		var divFooter = document.getElementById(footerId(viewerId));

		var extremes = firstChart.get('xaxis').getExtremes();
		var winTime = extremes.dataMax - extremes.dataMin;
		jQuery.each(charts, function (index, chart) {
			chart.options.qv.dataMax = extremes.dataMax;
			chart.options.qv.dataMin = extremes.dataMin;
		});
		var moreThanOneMonth = winTime > 30.42 * 24 * 3600 * 1000;
		var moreThanTwoMonths = winTime > 60.83 * 24 * 3600 * 1000;
		var moreThanThreeMonths = winTime > 91.25 * 24 * 3600 * 1000;
		var moreThanSixMonths = winTime > 182.5 * 24 * 3600 * 1000;
		var moreThanOneYear = winTime > 365 * 24 * 3600 * 1000;

		qViewer._groupOption = qViewer._groupOption || (qv.util.XAxisDataType(qViewer) == QueryViewerDataType.Date ? "Days" : "Seconds")

		var minDate = new gx.date.gxdate('');
		var maxDate = new gx.date.gxdate('');
		minDate.Value.setTime(extremes.dataMin + minDate.Value.getTimezoneOffset() * 60000);
		maxDate.Value.setTime(extremes.dataMax + maxDate.Value.getTimezoneOffset() * 60000);

		var showYears = true;
		var showSemesters = true;
		var showQuarters = true;
		var showMonths = true;
		var showWeeks = true;
		var showDays = true;
		var showHours = true;
		var showMinutes = true;

		if (gx.date.year(minDate) == gx.date.year(maxDate)) {
			showYears = false;
			if (!(gx.date.month(minDate) <= 6 && gx.date.month(maxDate) >= 7)) {
				showSemesters = false;
				if (!((gx.date.month(minDate) <= 3 && gx.date.month(maxDate) >= 4) || (gx.date.month(minDate) <= 6 && gx.date.month(maxDate) >= 7) || (gx.date.month(minDate) <= 9 && gx.date.month(maxDate) >= 10))) {
					showQuarters = false;
					if (gx.date.month(minDate) == gx.date.month(maxDate)) {
						showMonths = false;
						if ((gx.date.day(minDate) - gx.date.dow(minDate)) == (gx.date.day(maxDate) - gx.date.dow(maxDate))) {
							showWeeks = false;
							if (gx.date.day(minDate) == gx.date.day(maxDate)) {
								showDays = false;
								if (gx.date.hour(minDate) == gx.date.hour(maxDate)) {
									showHours = false;
									if (gx.date.minute(minDate) == gx.date.minute(maxDate)) {
										showMinutes = false;
									}
								}
							}
						}
					}
				}
			}
		}


		CreateHeader(divOptions, qViewer, moreThanOneMonth, moreThanTwoMonths, moreThanThreeMonths, moreThanSixMonths, moreThanOneYear, showYears, showSemesters, showQuarters, showMonths, showWeeks, showHours, showMinutes);
		CreateFooter(divFooter, viewerId);
		attachSliderEvents(viewerId);

		////////////////////////////////////////////////////////////////////////////////////////////
		// Event handlers para las opciones de "compare to past"
		////////////////////////////////////////////////////////////////////////////////////////////

		gx.dom.el(divOptions.id + '_compare_enable').onclick = function () {
			GroupAndCompareFunction(charts);
		};
		gx.dom.el(divOptions.id + '_compare_options').onchange = function () {
			if (gx.dom.el(divOptions.id + '_compare_enable').checked) {
				GroupAndCompareFunction(charts);
			}
		};
		gx.dom.el(divOptions.id + '_group_options').onchange = function () {
			GroupAndCompareFunction(charts);
		};
		var doZoom = function (zoomFactor) {

			var compare = gx.dom.el(divOptions.id + '_compare_enable').checked;

			if (zoomFactor > 0) {

				var minDate, maxDate;
				var extremes = firstChart.get('xaxis').getExtremes();
				maxDate = extremes.dataMax;
				minDate = maxDate - 30.417 * zoomFactor * 24 * 3600 * 1000; //30.4166 = 365dias/12meses
				var redraw = (compare) ? false : true;
				jQuery.each(charts, function (index, chart) {
					chart.get('xaxis').setExtremes(minDate, maxDate, redraw);
				});
				var qvOptions = firstChart.options.qv;
				var minPercent = (minDate - qvOptions.dataMin) / (qvOptions.dataMax - qvOptions.dataMin) * 100;
				var maxPercent = (maxDate - qvOptions.dataMin) / (qvOptions.dataMax - qvOptions.dataMin) * 100;
				InitializeSlider(firstChart.options.qv.viewerId, minPercent, maxPercent);

				EnableCompareControls(firstChart.options.qv.viewerId, true);
			}
			else //Zoom All
			{
				jQuery.each(charts, function (index, chart) {
					chart.zoomOut();
				});
				DisableCompareControls(firstChart.options.qv.viewerId, false);
			}

			//Resalto el selector de zoom seleccionado
			deselectZoom(prevClickedZoomId);
			selectZoom(this.id);

			jQuery.each(charts, function (index, chart) {
				chart.options.qv.predef_zoom = zoomFactor + "m";
			});
			prevClickedZoomId = this.id;

			//Si esta habilitada la comparación recalculo las fechas
			if (compare)
				GroupAndCompareFunction(charts);

		};

		////////////////////////////////////////////////////////////////////////////////////////////		
		// Carga los links de zooms con los event handlers necesarios
		// Zoom automatico a x meses		
		var array_zooms = [0, 1, 2, 3, 6, 12];
		for (var index in array_zooms) {
			var x = array_zooms[index];
			var zoomXm = gx.dom.el(viewerId + "_Zoom_" + x + "m");
			if (zoomXm) {
				zoomXm.onclick = doZoom.closure(zoomXm, [x]);
			}
		}
		////////////////////////////////////////////////////////////////////////////////////////////

		// Al final, se muestra un rango de fechas que despliegue un máximo de 20 puntos
		var zoomFactor = getSuitableZoomFactor(firstChart.series[0].points, 20);
		triggerZoom(zoomFactor);

		var footerChartOptions = getTimelineFooterChartOptions(qViewer, arrOptions);
		var FooterHCChart = new Highcharts.Chart(footerChartOptions);	// Agrego la gráfica del footer


	}

	//This function execute when the Highcharts object is finished loading and rendering.
	function HCFinishedLoadingCallback(chart) {

		var qViewer = qv.collection[chart.options.qv.viewerId];
		if (!IsDatetimeXAxis(qViewer)) {
			var selectionAllowed = qViewer.SelectionAllowed();
			var raiseItemClick = false;
			if (qViewer.ItemClick)
				for (var i = 0; i < qViewer.Metadata.Axes.length; i++)
					if (qViewer.Metadata.Axes[i].RaiseItemClick) {
						raiseItemClick = true;
						break;
					}
			if (raiseItemClick || selectionAllowed) {
				// Asocia el manejador para el evento click sobre el eje x
				jQuery.each(chart.xAxis[0].ticks, function (tick_index, tick) {
					if (tick && tick.label) {
						if (raiseItemClick)
							tick.label.addClass("gx-qv-clickable-element");
						tick.label.on("click", function (event) {
							onHighchartsXAxisClickEventHandler(event, tick_index, tick, chart, raiseItemClick, selectionAllowed);
						});
					}
				});
			}
		}
	}

	// ---------------------------------------------------- end Timeline ----------------------------------------------------

	return {

		tryToRenderChart: function (qViewer) {
			var errMsg = "";

			// Ejecuto el primer servicio y verifico que no haya habido error
			var d1 = new Date();
			var t1 = d1.getTime();

			qViewer.xml = qViewer.xml || {};

			qv.services.GetRecordsetCacheKeyIfNeeded(qViewer, function (resText, qViewer) {			// Servicio GetRecordsetCacheKey
				var newRecordsetCacheKey = false;
				if (resText != qViewer.xml.recordsetCacheKey) {
					qViewer.xml.recordsetCacheKey = resText;
					newRecordsetCacheKey = true;
				}
				if (!qv.util.anyError(resText)) {
					if (newRecordsetCacheKey)
						qv.services.parseRecordsetCacheKeyXML(qViewer);

					qv.services.GetMetadataIfNeeded(qViewer, function (resText, qViewer) {			// Servicio GetMetadata
						var newMetadata = false;
						if (resText != qViewer.xml.metadata) {
							qViewer.xml.metadata = resText;
							newMetadata = true;
						}
						var d2 = new Date();
						var t2 = d2.getTime();
						if (!qv.util.anyError(resText)) {
							if (newMetadata)
								qv.services.parseMetadataXML(qViewer);

							if (qViewer.Metadata.ParserResult.Success) {
								qv.services.GetDataIfNeeded(qViewer, function (resText, qViewer) {		// Servicio GetData
									var newData = false;
									if (resText != qViewer.xml.data) {
										qViewer.xml.data = resText;
										newData = true;
									}
									var d3 = new Date();
									var t3 = d3.getTime();
									if (!qv.util.anyError(resText)) {
										if (newData)
											qv.services.parseDataXML(qViewer);
										renderChart(qViewer);
									} else {
										// Error en el servicio GetData
										errMsg = qv.util.getErrorFromText(resText);
										qv.util.renderError(qViewer, errMsg);
									}
								});
							}
							else
								qv.util.renderError(qViewer, qViewer.Metadata.ParserResult.Message);
						}
						else {
							// Error en el servicio GetMetadata
							errMsg = qv.util.getErrorFromText(resText);
							qv.util.renderError(qViewer, errMsg);
						}
					});

				}
				else {
					// Error en el servicio GetRecordsetCachekey
					errMsg = qv.util.getErrorFromText(resText);
					qv.util.renderError(qViewer, errMsg);
				}
			});

		},

		GetMetadataChart: function (qViewer) {

			function UpdateMetadata(qViewer, designtimeMetadata) {

				function UpdateField(designtimeMetadata, name, visible) {
					for (var i = 0; i < designtimeMetadata.length; i++) {
						var element = designtimeMetadata[i];
						if (element.Name == name) {
							element.Visible = visible ? QueryViewerVisible.Yes : QueryViewerVisible.No;
							break;
						}
					}
				}
				
				if (qViewer.PlotSeries == QueryViewerPlotSeries.InTheSameChart)
					for (var serieIndex = 0; serieIndex < qViewer.Charts[0].series.length; serieIndex++) {
						var serie = qViewer.Charts[0].series[serieIndex];
						var name = qViewer.Chart.Series.ByIndex[serieIndex].FieldName;
						UpdateField(designtimeMetadata, name, serie.visible);
					}
				else
					for (var serieIndex = 0; serieIndex < qViewer.Charts.length; serieIndex++) {
						var serie = qViewer.Charts[serieIndex].series[0];
						var name = qViewer.Chart.Series.ByIndex[serieIndex].FieldName;
						UpdateField(designtimeMetadata, name, serie.visible);
					}
			}
			
			var designtimeMetadata = qv.util.GetDesigntimeMetadata(qViewer);
			UpdateMetadata(qViewer, designtimeMetadata);
			return designtimeMetadata;
		},

		GetRuntimeMetadata: function(qViewer) {
		
			function GetRuntimeElement(name, type, axis, position, visible) {
				return { Name: name, Type: type, Axis: axis, Position: position, Hidden: visible == QueryViewerVisible.Never || element.Visible == QueryViewerVisible.No};
			}
			
			var elements = [];
			var lastPosition;
			lastPosition = 0;
			for (var i = 0; i < qViewer.Metadata.Axes.length; i++) {
				var element = qViewer.Metadata.Axes[i];
				if (element.Visible != QueryViewerVisible.Never)
					lastPosition += 1;
				elements.push(GetRuntimeElement(element.Name, QueryViewerElementType.Axis, element.Axis, element.Visible != QueryViewerVisible.Never ? lastPosition : null, element.Visible));
			}
			lastPosition = 0;
			for (var i = 0; i < qViewer.Metadata.Data.length; i++) {
				var element = qViewer.Metadata.Data[i];
				if (element.Visible != QueryViewerVisible.Never)
					lastPosition += 1;
				elements.push(GetRuntimeElement(element.Name, QueryViewerElementType.Datum, "", element.Visible != QueryViewerVisible.Never ? lastPosition : null, element.Visible));
			}
			if (qViewer.PlotSeries == QueryViewerPlotSeries.InTheSameChart)
				for (var serieIndex = 0; serieIndex < qViewer.Charts[0].series.length; serieIndex++) {
					var serie = qViewer.Charts[0].series[serieIndex];
					var name = qViewer.Chart.Series.ByIndex[serieIndex].FieldName;
					element = qv.util.GetElementInCollection(elements, "Name", name);
					element.Hidden = !serie.visible;
				}
			else
				for (var serieIndex = 0; serieIndex < qViewer.Charts.length; serieIndex++) {
					var serie = qViewer.Charts[serieIndex].series[0];
					var name = qViewer.Chart.Series.ByIndex[serieIndex].FieldName;
					element = qv.util.GetElementInCollection(elements, "Name", name);
					element.Hidden = !serie.visible;
				}
			return elements;
		},
		
		GetDataChart: function (qViewer) {
			return qViewer.xml.data;
		},

		getSparklineChartOptions: function (qViewer, containerId, chartType, noBackground, step, series) {
			var options = {};
			options.chart = {};
			options.chart.renderTo = containerId;
			options.chart.margin = 0;
			options.chart.type = chartType;
			options.chart.styledMode = true;
			if (noBackground)
				options.chart.className = "highcharts-no-background";		// Clase no estándar de Highcharts
			options.title = {};
			options.title.text = "";
			options.credits = {};
			options.credits.enabled = false;
			options.xAxis = {};
			options.xAxis.visible = false;
			options.yAxis = {};
			options.yAxis.visible = false;
			options.legend = {};
			options.legend.enabled = false;
			options.tooltip = {};
			options.tooltip.enabled = false;
			options.plotOptions = {};
			options.plotOptions.series = {};
			options.plotOptions.series.animation = false;
			options.plotOptions.series.connectNulls = true;
			options.plotOptions.series.enableMouseTracking = false;
			options.plotOptions.series.lineWidth = 1;
			options.plotOptions.series.shadow = false;
			options.plotOptions.series.states = {};
			options.plotOptions.series.states.hover = {};
			options.plotOptions.series.states.hover.lineWidth = 1;
			options.plotOptions.series.marker = {};
			options.plotOptions.series.marker.radius = 0;
			options.plotOptions.series.marker.states = {};
			options.plotOptions.series.marker.states.hover = {};
			options.plotOptions.series.marker.states.hover.radius = 2;
			if (step != "")
				options.plotOptions.series.step = step;
			options.series = []
			for (var i = 0; i < series.length; i++)
				options.series.push(series[i]);
			return options;
		},

		IsDatetimeXAxis: function (qViewer) {
			return IsDatetimeXAxis(qViewer);
		},

		IsSingleSerieChart: function (qViewer) {
			return IsSingleSerieChart(qViewer);
		},
		
		IsAreaChart: function (qViewer) {
			return IsAreaChart(qViewer);
		},
		
		IsLineChart: function (qViewer) {
			return IsLineChart(qViewer);
		},
		
		IsSplittedChart: function (qViewer) {
			return IsSplittedChart(qViewer);
		},

		IsGaugeChart: function (qViewer) {
			return IsGaugeChart(qViewer);
		},

		Select: function (qViewer, selection) {
			var rowsToSelect = GetRowsToSelect(qViewer, selection);
			if (rowsToSelect.length > 0)
				SelectChartsPoints(qViewer.Charts, rowsToSelect);
			else
				DeselectChartsPoints(qViewer.Charts);
		},

		Deselect: function (qViewer) {
			DeselectChartsPoints(qViewer.Charts);
		}

	}

})()
/* END OF FILE - ..\Sources\Chart.src.js - */
/* START OF FILE - ..\Sources\Card.src.js - */
qv.card = (function () {

	function selectStyle(datum, value) {

		if (datum.ConditionalStyles.length == 0)
			return qv.util.css.parseStyle(datum.Style);
		else {
			for (var i = 0; i < datum.ConditionalStyles.length; i++) {
				var conditionalStyle = datum.ConditionalStyles[i];
				if (qv.util.satisfyStyle(value, conditionalStyle))
					return (qv.util.css.parseStyle(conditionalStyle.StyleOrClass));
			}
			return qv.util.css.parseStyle(datum.Style);
		}
	}

	function analizeSeries(qViewer, datum, xDataField, xDataType) {

		function analizeMain(start, regressionStart, xDataField, yDataField, rows, xDataType) {
			var minValue = null;
			var maxValue = null;
			var minWhen = null;
			var maxWhen = null;
			var chartSeriesData = [];
			var lr = {AnyTrend: false};
			if (xDataField != "") {
				var end = rows.length - 1;
				var n = 0;
				var sum_x = 0;
				var sum_y = 0;
				var sum_xy = 0;
				var sum_xx = 0;
				var sum_yy = 0;
				var regressionStartDate = null;
				var regressionStartY = null;
				for (var i = start; i <= end; i++) {
					if (rows[i][xDataField] != undefined && rows[i][yDataField] != undefined) {
						n += 1;
						var date = new gx.date.gxdate(rows[i][xDataField], "Y4MD");
						var yValue = parseFloat(rows[i][yDataField]);
						chartSeriesData.push({ x: date.Value.getTime() - date.Value.getTimezoneOffset() * 60000, y: yValue });
						if (minValue == null && maxValue == null) {
							minValue = yValue;
							maxValue = yValue;
							minWhen = rows[i][xDataField];
							maxWhen = rows[i][xDataField];
						}
						else {
							if (yValue > maxValue) {
								maxWhen = rows[i][xDataField];
								maxValue = yValue;
							}
							if (yValue < minValue) {
								minWhen = rows[i][xDataField];
								minValue = yValue;
							}
						}
						if (i >= regressionStart) {
							if (regressionStartDate == null && regressionStartY == null) {
								regressionStartDate = date;
								regressionStartY = yValue;
							}
							// Cambio de variable para no manejar números tan grandes
							var x = xDataType == QueryViewerDataType.Date ? gx.date.daysDiff(date, regressionStartDate) : gx.date.secDiff(date, regressionStartDate);
							var y = yValue - regressionStartY;
							sum_x += x;
							sum_y += y;
							sum_xy += x * y;
							sum_xx += x * x;
							sum_yy += y * y;
						}
					}
				}
				lr.AnyTrend = n > 1;
				lr.Slope = (n * sum_xy - sum_x * sum_y) / (n * sum_xx - sum_x * sum_x);
				lr.Intercept = (sum_y - lr.Slope * sum_x) / n;
				lr.R2 = Math.pow((n * sum_xy - sum_x * sum_y) / Math.sqrt((n * sum_xx - sum_x * sum_x) * (n * sum_yy - sum_y * sum_y)), 2);
			}
			var data = {};
			data.LinearRegression = lr;
			data.MinValue = minValue;
			data.MinWhen = minWhen;
			data.MaxValue = maxValue;
			data.MaxWhen = maxWhen;
			data.ChartSeriesData = chartSeriesData;
			return data;
		}

		function getRegressionStartDateStr(trendPeriod, xDataType) {
			var endDate = gx.date.now();
			var startDate;
			switch (trendPeriod) {
				case QueryViewerTrendPeriod.LastYear:
					startDate = gx.date.addyr(endDate, -1);
					break;
				case QueryViewerTrendPeriod.LastSemester:
					startDate = gx.date.addmth(endDate, -6);
					break;
				case QueryViewerTrendPeriod.LastQuarter:
					startDate = gx.date.addmth(endDate, -3);
					break;
				case QueryViewerTrendPeriod.LastMonth:
					startDate = gx.date.addmth(endDate, -1);
					break;
				case QueryViewerTrendPeriod.LastWeek:
					startDate = gx.date.dtadd(endDate, -86400 * 7);
					break;
				case QueryViewerTrendPeriod.LastDay:
					startDate = gx.date.dtadd(endDate, -86400);
					break;
				case QueryViewerTrendPeriod.LastHour:
					startDate = gx.date.dtadd(endDate, -3600);
					break;
				case QueryViewerTrendPeriod.LastMinute:
					startDate = gx.date.dtadd(endDate, -60);
					break;
				case QueryViewerTrendPeriod.LastSecond:
					startDate = gx.date.dtadd(endDate, -1);
					break;
			}
			var startDateStr = qv.util.dateToString(startDate, xDataType == QueryViewerDataType.DateTime);
			return startDateStr;
		}

		// Busco un eje de tipo date o datetime
		var data = {};
		var noTrend = { AnyTrend: false };
		var regressionStart;
		if (qViewer.IncludeTrend) {
			if (qViewer.TrendPeriod == QueryViewerTrendPeriod.SinceTheBeginning || qViewer.TrendPeriod == "")
				regressionStart = 0;
			else {
				var trendStartDate = getRegressionStartDateStr(qViewer.TrendPeriod, xDataType);
				regressionStart = qViewer.Data.Rows.length - 1;
				for (var i = qViewer.Data.Rows.length - 2; i >= 0; i--) {
					var currentDate = qViewer.Data.Rows[i][xDataField];
					if (currentDate < trendStartDate)
						break;
					regressionStart = i;
				}
			}
		}
		else
			regressionStart = qViewer.Data.Rows.length - 1;	// Start = End para que no calcule regresión lineal
		var start = qViewer.IncludeSparkline || qViewer.IncludeMaxAndMin ? 0 : regressionStart;
		data = analizeMain(start, regressionStart, xDataField, datum.DataField, qViewer.Data.Rows, xDataType);
		return data;
	}

	function setEventData(eventData, qViewer, name, allRows) {

		function getContext(qViewer, allRows) {

			function getElementValues(dataField, rows, allRows) {
				var values = [];
				if (allRows)
					for (var i = 0; i < rows.length; i++)
						values.push(rows[i][dataField]);
				else
					values.push(rows[rows.length - 1][dataField]);
				return values;
			}

			var context = [];
			for (var i = 0; i < qViewer.Metadata.Axes.length; i++) {
				var axis = qViewer.Metadata.Axes[i];
				if (!axis.IsComponent) {
					var element = {};
					element.Name = axis.Name;
					element.Values = getElementValues(axis.DataField, qViewer.Data.Rows, allRows);
					context.push(element);
				}
			}
			for (var i = 0; i < qViewer.Metadata.Data.length; i++) {
				var datum = qViewer.Metadata.Data[i];
				if (!datum.IsComponent) {
					var element = {};
					element.Name = datum.Name;
					element.Values = getElementValues(datum.DataField, qViewer.Data.Rows, allRows);
					context.push(element);
				}
			}
			return context;
		}

		var clickedDatum = null;
		for (var i = 0; i < qViewer.Metadata.Data.length; i++) {
			if (qViewer.Metadata.Data[i].Name == name) {
				clickedDatum = qViewer.Metadata.Data[i];
				break;
			}
		}
		if (clickedDatum != null) {
			eventData.Name = clickedDatum.Name;
			eventData.Type = QueryViewerElementType.Datum;
			eventData.Axis = "";
			var lastRow;
			if (allRows)
				lastRow = qv.util.aggregateData(qViewer.Metadata.Data, qViewer.Data.Rows);
			else
				lastRow = qViewer.Data.Rows[qViewer.Data.Rows.length - 1];
			eventData.Value = lastRow[clickedDatum.DataField];
			eventData.Context = getContext(qViewer, allRows);
		}
	}

	function sparklineChartId(qViewerId, i) {
		return qViewerId + "_card_sparkline_" + i;
	}

	function GetSparklineOptions(qViewer, seriesData, i) {
		var containerId = sparklineChartId(qViewer.userControlId(), i);
		var series = [{ data: seriesData }];
		return qv.chart.getSparklineChartOptions(qViewer, containerId, "line", true, "", series);
	}

	function getMinMaxTable(parent, text1, text2, text3) {
		var styleObj = { textAlign: "center", paddingTop: "0px", paddingRight: "5px", paddingBottom: "0px", paddingLeft: "5px" };
		var table = qv.util.dom.createTable(parent, "", {});
		var tr;
		var td;
		var span;
		tr = qv.util.dom.createRow(table);
		td = qv.util.dom.createCell(tr, 1, "", styleObj, "");
		span = qv.util.dom.createSpan(td, "", "qv-card-max-and-min-value", text2, {}, null, text1);
		tr = qv.util.dom.createRow(table);
		td = qv.util.dom.createCell(tr, 1, "", styleObj, "");
		span = qv.util.dom.createSpan(td, "", "qv-card-max-and-min-title", text2, {}, null, text3);
		return table;
	}

	function age(dateStr) {
		var date = new gx.date.gxdate(dateStr, "Y4MD");
		var now = gx.date.now();
		var seconds = gx.date.secDiff(now, date);
		return gx.getMessage("GXPL_QViewerTimeAgo").replace("{0}", qv.util.seconsdToText(seconds));
	}

	function valueOrPercentage(qViewer, valueStr, datum, decimals) {
		var value;
		var percentage;
		if (valueStr != "") {
			value = qv.util.formatNumber(parseFloat(valueStr), decimals, datum.Picture, false);
			percentage = qv.util.formatNumber(parseFloat(valueStr * 100 / datum.TargetValue), 2, "ZZZZZZZZZZZZZZ9.99", false) + '%';
		}
		else {
			value = "";
			percentage = "";
		}
		switch (qViewer.ShowDataAs) {
			case QueryViewerShowDataAs.Values:
				return value;
			case QueryViewerShowDataAs.Percentages:
				return percentage;
			case QueryViewerShowDataAs.ValuesAndPercentages:
				return value + ' (' + percentage + ')';
			default:
				return value;
		}
	}

	function renderCard(qViewer) {

		function TrendIcon(parent, qViewer, data) {
			var icon;
			if (data.LinearRegression.Slope > 0)
				icon = "keyboard_arrow_up";
			else if (data.LinearRegression.Slope < 0)
				icon = "keyboard_arrow_down";
			else
				icon = "drag_handle";
			var trendTooltip;
			if (qViewer.TrendPeriod == "")
				trendTooltip = gx.getMessage("GXPL_QViewerSinceTheBeginningTrend");
			else
				trendTooltip = gx.getMessage("GXPL_QViewer" + qViewer.TrendPeriod + "Trend");
			var styleObj = { width: "0px", marginLeft: "5px" };
			if (!qViewer.IncludeSparkline) {
				styleObj.position = "relative";
				styleObj.top = "2px";
			}
			styleObj.fontSize = "36px";
			var icon = qv.util.dom.createIcon(parent, trendTooltip, styleObj, icon);
			return icon;
		}

		var anyRows = qViewer.Data.Rows.length > 0;
		var aggregateRows = true;
		var xDataField = "";
		var xDataType;
		for (var i = 0; i < qViewer.Metadata.Axes.length; i++) {
			var axis = qViewer.Metadata.Axes[i];
			if (axis.DataType == QueryViewerDataType.Date || axis.DataType == QueryViewerDataType.DateTime) {	// Si hay alguna fecha no agrego los datos porque voy a querer ver la evolución a lo largo del tiempo
				aggregateRows = false;
				xDataField = axis.DataField;
				xDataType = axis.DataType;
				break;
			}
		}
		var lastRow;
		if (anyRows) {
			if (aggregateRows)
				lastRow = qv.util.aggregateData(qViewer.Metadata.Data, qViewer.Data.Rows);
			else
				lastRow = qViewer.Data.Rows[qViewer.Data.Rows.length - 1];
		}
		var container = qv.util.dom.getEmptyContainer(qViewer);
		var width;
		var height;
		if (qViewer.IsAutoResize()) {
			width = "";
			height = "";
		}
		else {
			width = "100%";
			height = "100%";
		}
		var tableOuter = qv.util.dom.createTable(container, qv.util.GetContainerControlClasses(qViewer), { width: width, height: height });
		var trOuter = qv.util.dom.createRow(tableOuter);
		var tdOuter = qv.util.dom.createCell(trOuter, 1, "center", {}, "");
		width = qViewer.Orientation == QueryViewerOrientation.Horizontal ? "100%" : "";
		height = qViewer.Orientation == QueryViewerOrientation.Vertical ? "100%" : "";
		var tableInner = qv.util.dom.createTable(tdOuter, "", { width: width, height: height, whiteSpace: "nowrap" });											// Para todos los indicadores en la card
		var trInner;
		if (qViewer.Orientation == QueryViewerOrientation.Horizontal)
			trInner = qv.util.dom.createRow(tableInner);
		var dataAllSeries = [];
		for (var i = 0; i < qViewer.Metadata.Data.length; i++) {
			var datum = qViewer.Metadata.Data[i];
			if (datum.Visible == QueryViewerVisible.Yes || datum.Visible == QueryViewerVisible.Always) {
				var numberFormat = qv.util.ParseNumericPicture(datum.DataType, datum.Picture);
				var decimals = numberFormat.DecimalPrecision;
				var value;
				var valueStr;
				var ageStr;
				if (anyRows) {
					value = lastRow[datum.DataField];
					valueStr = valueOrPercentage(qViewer, lastRow[datum.DataField], datum, decimals);
					ageStr = age(lastRow[xDataField]);
				}
				else {
					value = "";
					valueStr = "";
					ageStr = "";
				}
				if ((gx.lang.gxBoolean(qViewer.IncludeTrend) || gx.lang.gxBoolean(qViewer.IncludeSparkline) || gx.lang.gxBoolean(qViewer.IncludeMaxAndMin)) && anyRows) {
					var data = analizeSeries(qViewer, datum, xDataField, xDataType);
					dataAllSeries.push(data);
				}
				var styleStr = selectStyle(datum, value);
				var styleObj = {};
				var elementValueClass = "qv-card-element-value";
				if (qv.util.startsWith(styleStr, "{") && qv.util.endsWith(styleStr, "}"))
					styleObj = JSON.parse(styleStr);
				else
					elementValueClass = styleStr;	// El style es en realidad el nombre de una clase
				var onClick = null;
				if (qViewer.ItemClick && datum.RaiseItemClick) {
					elementValueClass += (elementValueClass == "" ? "" : " ") + "gx-qv-clickable-element";
					onClick = function () {
						qv.card.fireItemClickEvent(event, qViewer, aggregateRows)
					};
				}
				if (qViewer.Orientation == QueryViewerOrientation.Vertical)
					trInner = qv.util.dom.createRow(tableInner);
				var horizontalPadding = qViewer.Orientation == QueryViewerOrientation.Horizontal ? "10px" : "";
				var verticalPadding = qViewer.Orientation == QueryViewerOrientation.Vertical ? "10px" : "";
				var tdInner = qv.util.dom.createCell(trInner, 1, "center", { paddingRight: horizontalPadding, paddingLeft: horizontalPadding, paddingBottom: verticalPadding, paddingTop: verticalPadding }, "");
				var table1 = qv.util.dom.createTable(tdInner, "", {});
				var tr1 = qv.util.dom.createRow(table1);
				var td1 = qv.util.dom.createCell(tr1, 1, "center", {}, "");
				var table2 = qv.util.dom.createTable(td1, "", {});
				var tr2 = qv.util.dom.createRow(table2);
				td2 = qv.util.dom.createCell(tr2, 1, "center", {}, "");
				var span2 = qv.util.dom.createSpan(td2, qViewer.getContainerControl().id + "_" + datum.Name, elementValueClass, (xDataField != "" ? ageStr : ""), styleObj, onClick, valueStr);
				var td2 = qv.util.dom.createCell(tr2, 1, "", {}, "");
				if (anyRows && qViewer.IncludeTrend && !qViewer.IncludeSparkline && data.LinearRegression.AnyTrend)
					TrendIcon(td2, qViewer, data);
				tr1 = qv.util.dom.createRow(table1);
				td1 = qv.util.dom.createCell(tr1, 1, "center", {}, "");
				span1 = qv.util.dom.createSpan(td1, "", "qv-card-element-title", (xDataField != "" ? ageStr : ""), {}, null, datum.Title);
				if (qViewer.IncludeSparkline && xDataField != "" && anyRows) {
					tr1 = qv.util.dom.createRow(table1);
					td1 = qv.util.dom.createCell(tr1, 1, "", {}, "");
					var table2 = qv.util.dom.createTable(td1, "", { width: "100%" });
					var tr2 = qv.util.dom.createRow(table2);
					var td2;
					td2 = qv.util.dom.createCell(tr2, 1, "", { width: "100%" }, "");
					var div = qv.util.dom.createDiv(td2, sparklineChartId(qViewer.userControlId(), i), "", "", { height: "50px", width: "100%", minWidth: "100px" }, "");
					td2 = qv.util.dom.createCell(tr2, 1, "", { width: "0%" }, "");
					if (anyRows && qViewer.IncludeTrend && data.LinearRegression.AnyTrend)
						TrendIcon(td2, qViewer, data);
				}
				if (qViewer.IncludeMaxAndMin && xDataField != "" && anyRows) {
					tr1 = qv.util.dom.createRow(table1);
					td1 = qv.util.dom.createCell(tr1, 1, "center", {}, "");
					var table2 = qv.util.dom.createTable(td1, "", { "margin-top": "10px" });
					var tr2 = qv.util.dom.createRow(table2);
					var td2;
					td2 = qv.util.dom.createCell(tr2, 1, "", {}, "");
					var table3;
					table3 = getMinMaxTable(td2, valueOrPercentage(qViewer, data.MinValue, datum, decimals), age(data.MinWhen), gx.getMessage("GXPL_QViewerCardMinimum"));
					td2 = qv.util.dom.createCell(tr2, 1, "", {}, "");
					table3 = getMinMaxTable(td2, valueOrPercentage(qViewer, data.MaxValue, datum, decimals), age(data.MaxWhen), gx.getMessage("GXPL_QViewerCardMaximum"));
				}
			}
		}
		if (qViewer.IncludeSparkline && xDataField != "" && anyRows) {
			for (var i = 0; i < qViewer.Metadata.Data.length; i++) {
				var sparklineOptions = GetSparklineOptions(qViewer, dataAllSeries[i].ChartSeriesData, i);
				var SparklineHCChart = new Highcharts.Chart(sparklineOptions);
			}
		}
		qViewer._ControlRenderedTo = qViewer.RealType;
		qv.util.hideActivityIndicator(qViewer);
	}

	return {

		tryToRenderCard: function (qViewer) {
			var errMsg = "";

			// Ejecuto el primer servicio y verifico que no haya habido error
			var d1 = new Date();
			var t1 = d1.getTime();

			qViewer.xml = qViewer.xml || {};

			qv.services.GetRecordsetCacheKeyIfNeeded(qViewer, function (resText, qViewer) {				// Servicio GetRecordsetCacheKey
				var newRecordsetCacheKey = false;
				if (resText != qViewer.xml.recordsetCacheKey) {
					qViewer.xml.recordsetCacheKey = resText;
					newRecordsetCacheKey = true;
				}
				if (!qv.util.anyError(resText)) {
					if (newRecordsetCacheKey)
						qv.services.parseRecordsetCacheKeyXML(qViewer);

					qv.services.GetMetadataIfNeeded(qViewer, function (resText, qViewer) {				// Servicio GetMetadata
						var newMetadata = false;
						if (resText != qViewer.xml.metadata) {
							qViewer.xml.metadata = resText;
							newMetadata = true;
						}
						var d2 = new Date();
						var t2 = d2.getTime();
						if (!qv.util.anyError(resText)) {
							if (newMetadata)
								qv.services.parseMetadataXML(qViewer);

							if (qViewer.Metadata.ParserResult.Success) {
								qv.services.GetDataIfNeeded(qViewer, function (resText, qViewer) {			// Servicio GetData
									var newData = false;
									if (resText != qViewer.xml.data) {
										qViewer.xml.data = resText;
										newData = true;
									}
									var d3 = new Date();
									var t3 = d3.getTime();
									if (!qv.util.anyError(resText)) {
										if (newData)
											qv.services.parseDataXML(qViewer);
										renderCard(qViewer);
									} else {
										// Error en el servicio GetData
										errMsg = qv.util.getErrorFromText(resText);
										qv.util.renderError(qViewer, errMsg);
									}
								});
							}
							else
								qv.util.renderError(qViewer, qViewer.Metadata.ParserResult.Message);
						}
						else {
							// Error en el servicio GetMetadata
							errMsg = qv.util.getErrorFromText(resText);
							qv.util.renderError(qViewer, errMsg);
						}
					});

				}
				else {
					// Error en el servicio GetRecordsetCachekey
					errMsg = qv.util.getErrorFromText(resText);
					qv.util.renderError(qViewer, errMsg);
				}
			});

		},

		GetMetadataCard: function (qViewer) {
			return qv.util.GetDesigntimeMetadata(qViewer);
		},

		GetDataCard: function (qViewer) {
			return qViewer.xml.data;
		},

		fireItemClickEvent: function (ev, qViewer, allRows) {
			var id = ev.target.id;
			var name = id.substr(id.lastIndexOf("_") + 1);
			setEventData(qViewer.ItemClickData, qViewer, name, allRows);
			qViewer.ItemClick();
		}

	}

})()
/* END OF FILE - ..\Sources\Card.src.js - */
/* START OF FILE - ..\Sources\Map.src.js - */
qv.map = (function () {


	// ------------------------------------------------------ Common functions------------------------------------------------------

	//Establece el color a la serie, en caso de ser default toma un color de Highcharts
	function getColorSerie(qViewer) {
		if (qViewer.MapType == QueryViewerMapType.Choropleth || (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.Character) || (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint && qViewer.Chart.Series.DataFields[0] != "F0")) {
			if (qViewer.Chart.Series.ByIndex[0].Color.Color)
				return "#" + qViewer.Chart.Series.ByIndex[0].Color.Color;
			else
				return "#0F5B78";	// Default color for 1st serie
		} else if (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint && qViewer.Chart.Series.DataFields[0] == "F0") {			//Bubble Map con coord geopoint y dato asociado
			if (qViewer.Metadata.Axes[0].Style)
				return qViewer.Metadata.Axes[0].Style.substring(6, qViewer.Metadata.Axes[0].Style.length);
			else
				return "#0F5B78";	// Default color for 1st serie
		}
	}

	function getSerieData(qViewer) {

		function extractCoord(coordPoints) {

			var coord = coordPoints.substring(7, coordPoints.length - 1);
			for (var i = 0; i < coord.length; i++) {
				if (coord[i] == " ") {
					var lat = parseFloat(coord.substring(0, i));
					var lon = parseFloat(coord.substring(i + 1, coord.length));
				}
			}
			return [lat, lon];
		}

		var dataArray = [];
		if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.Character) {
			if (qViewer.Chart.Categories.DataFields.length > 0 && qViewer.Chart.Series.DataFields.length > 0) {
				for (var i = 0; i < qViewer.Chart.Categories.Values.length; i++) {
					var axisValue = qViewer.Chart.Categories.Values[i].Value;
					var datumValue = parseFloat(qViewer.Chart.Series.ByIndex[0].Points[i].Value);
					if (qViewer.MapLibrary === QueryViewerMapLibrary.ECharts)
						dataArray.push({ name: axisValue, value: datumValue });
					else
						dataArray.push([axisvalue, datumValue]);
				}
			}
		} else if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint) { //Bubble con tipo de dato geopoint

			var dataArray = [];
			var colorCond;
			var axis = qViewer.Metadata.Axes[0];
			for (var i = 0; i < qViewer.Data.Rows.length; i++) {
				var axisValue = extractCoord(qViewer.Data.Rows[i][axis.DataField]);
				var datumValue = parseFloat(qViewer.Chart.Series.ByIndex[0].Points[i].Value);
				if (qViewer.Chart.Series.DataFields[0] == "F0") { //La query no tiene un valor asociado a al coordenada un valor asociado 
					dataArray.push({ coord: [axisValue[0], axisValue[1]], additionalData: qViewer.Data.Rows[i]});
				} else { //La query tiene ademas de la coordenada un valor asociado 
					if (qViewer.Chart.colorAxis.dataClasses.length == 0) {
					dataArray.push({ coord: [axisValue[0], axisValue[1]], value: datumValue, itemStyle: { color: getColorSerie(qViewer) }, additionalData: qViewer.Data.Rows[i]});
					} else {
						colorCond = qViewer.Chart.Series.ByIndex[0].Points[i].Color.Color;
						if (checkIfIsHexColor(colorCond)) {
							colorCond = "#" + colorCond;
						}
						dataArray.push({ coord: [axisValue[0], axisValue[1]], value: datumValue, itemStyle: { color: colorCond }, additionalData: qViewer.Data.Rows[i]});

					}
				}
				
			}

		}


		return dataArray;

	}

	function SetItemClickDataMap(eventData, qViewer, name, type, value, selected, pointsValues, pointsCategories, index) {

		var axis = qViewer.Metadata.Axes[0];

		function GetContextElement(axisOrDatum, value) {
			var contextElement = {};
			contextElement.Name = axisOrDatum.Name;
			var pictureProperties = qv.util.GetPictureProperties(axisOrDatum.DataType, axisOrDatum.Picture);
			if (axisOrDatum.DataType != QueryViewerDataType.GeoPoint) {
				var formattedValue = qv.util.ApplyPicture(value, axisOrDatum.Picture, axisOrDatum.DataType, pictureProperties);
				contextElement.Values = [formattedValue];
			} else if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint && qViewer.MapType == QueryViewerMapType.Bubble) {
				contextElement.Values = value[axis.DataField];
			} else { 
				contextElement.Values = [value];
			}
			return contextElement;
		}

		eventData.Name = name;
		eventData.Type = type;
		eventData.Axis = "";
		eventData.Value = value;
		eventData.Selected = selected;
		eventData.Context = [];

		if (!axis.IsComponent) {
			if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint && qViewer.MapType == QueryViewerMapType.Bubble) {
				var contextElement = GetContextElement(axis, qViewer.Data.Rows[index]);
			} else if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint && qViewer.MapType == QueryViewerMapType.Choropleth) {
				var contextElement = GetContextElement(axis, pointsCategories[index].name);
			} else {
				var contextElement = GetContextElement(axis, pointsCategories[index].Value);
			}
			eventData.Context.push(contextElement);
		}

		for (var i = 0; i < qViewer.Metadata.Data.length; i++) {
			var datum = qViewer.Metadata.Data[i];
			if (!datum.IsComponent) {
				var contextElement;
				if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint && qViewer.MapType == QueryViewerMapType.Choropleth) {
					contextElement = GetContextElement(datum, pointsValues[index].value);
				} else {
					contextElement = GetContextElement(datum, pointsValues[index].Value);
				}
				eventData.Context.push(contextElement);
			}
		}
		eventData.Filters = [];
	}

	function initCursor(chart) {
		chart.on('mousedown', function (params) {
			chart.getZr().setCursorStyle('auto');
		});
		chart.on('mousemove', function (params) {
			chart.getZr().setCursorStyle('auto');
		});
		chart.on('mouseup', function (params) {
			chart.getZr().setCursorStyle('auto');
		});
		chart.on('mouseover', function (params) {
			chart.getZr().setCursorStyle('auto');
		});
		chart.on('mouseout', function (params) {
			chart.getZr().setCursorStyle('auto');
		});
	}

	function changeCursor(chart, qViewer) {
		chart.on('mousedown', function (params) {
			if (qViewer.MapType == QueryViewerMapType.Choropleth) {
				chart.getZr().setCursorStyle('pointer');
			} else {
				if (params.componentType === 'markPoint') {
					chart.getZr().setCursorStyle('pointer');
				} else {
					chart.getZr().setCursorStyle('auto');
				}
			}
		});
		chart.on('mousemove', function (params) {
			if (qViewer.MapType == QueryViewerMapType.Choropleth) {
				chart.getZr().setCursorStyle('pointer');
			} else {
				if (params.componentType === 'markPoint') {
					chart.getZr().setCursorStyle('pointer');
				} else {
					chart.getZr().setCursorStyle('auto');
				}
			}
		});
		chart.on('mouseup', function (params) {
			if (qViewer.MapType == QueryViewerMapType.Choropleth) {
				chart.getZr().setCursorStyle('pointer');
			} else {
				if (params.componentType === 'markPoint') {
					chart.getZr().setCursorStyle('pointer');
				} else {
					chart.getZr().setCursorStyle('auto');
				}
			}
		});
		chart.on('mouseover', function (params) {
			if (qViewer.MapType == QueryViewerMapType.Choropleth) {
				chart.getZr().setCursorStyle('pointer');
			} else {
				if (params.componentType === 'markPoint') {
					chart.getZr().setCursorStyle('pointer');
				} else {
					chart.getZr().setCursorStyle('auto');
				}
			}
		});
		chart.on('mouseout', function (params) {
			if (qViewer.MapType == QueryViewerMapType.Choropleth) {
				chart.getZr().setCursorStyle('pointer');
			} else {
				if (params.componentType === 'markPoint') {
					chart.getZr().setCursorStyle('pointer');
				} else {
					chart.getZr().setCursorStyle('auto');
				}
			}
		});
	}

	function MapsClickEvent(chart, qViewer) {
		chart.on('click', function (params) {
			if ((qViewer.MapType == QueryViewerMapType.Choropleth) || ((qViewer.MapType == QueryViewerMapType.Bubble) && (params.componentType === 'markPoint'))) {
				var serie = qViewer.Chart.Series.ByIndex[0];
				var formattedValue = qv.util.formatNumber(params.value, serie.NumberFormat.DecimalPrecision, serie.Picture, false);
				var pointsValues = qViewer.Chart.Series.ByIndex[0].Points;
				var pointsCategories;
				if (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint) {
					pointsCategories = qViewer.Data.Rows;
				} else if (qViewer.MapType == QueryViewerMapType.Choropleth && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint) {
					pointsValues = pointsCategories = geopointToCharacter(getSerieData(qViewer), chart, qViewer);
				} else {
					pointsCategories = qViewer.Chart.Categories.Values;
				}
				var selected;
				var option = chart.getOption();
				if (qViewer.SelectionAllowed()) {
					if (qViewer.MapType == QueryViewerMapType.Choropleth) {
						var point = option.series[0].selectedMap;
						if (point[Object.keys(point)[0]] == true) {
							selected = true;
						} else {
							selected = false;
						}
					} else {
						var colorBubble;
						if (qViewer.Chart.colorAxis.dataClasses.length == 0) { //cuando no tiene conditional style
							colorBubble = option.series[0].color;
						} else {
							colorBubble = qViewer.Chart.Series.ByIndex[0].Points[params.dataIndex].Color.Color;
							if (checkIfIsHexColor(colorBubble)) {
								colorBubble = "#" + colorBubble;
							}
						}
						if ((chart.BubbleSelect == params.dataIndex) && option.series[0].markPoint.data[params.dataIndex].itemStyle.color == colorBubble) {
							selected = true;
						} else if ((chart.BubbleSelect == params.dataIndex) && option.series[0].markPoint.data[params.dataIndex].itemStyle.color != colorBubble) {
							selected = false;
						} else if ((chart.BubbleSelect != params.dataIndex) && option.series[0].markPoint.data[params.dataIndex].itemStyle.color == colorBubble) {
							selected = true;
						} else {
							selected = false;
						}
					}
				} else {
					selected = false;
				}
				if (!(params.dataIndex > pointsCategories.length - 1 && Number.isNaN(params.value))) {
					SetItemClickDataMap(qViewer.ItemClickData, qViewer, serie.FieldName, QueryViewerElementType.Datum, formattedValue, selected, pointsValues, pointsCategories, params.dataIndex);
					qViewer.ItemClick();
				}
			}
		});
	}

	function bubblePoints(data, qViewer, chart) {

		function PointInPolygon(point, polygon) {

			var x = point[0], y = point[1];

			var inside = false;
			for (var i = 0, j = polygon.length - 1; i < polygon.length; j = i++) {
				var xi = polygon[i][0], yi = polygon[i][1];
				var xj = polygon[j][0], yj = polygon[j][1];

				var intersect = ((yi > y) != (yj > y)) && (x < (xj - xi) * (y - yi) / (yj - yi) + xi);
				if (intersect) {
					if (inside == false)
						inside = true;
					else
						inside = false;
				}
			}

			return inside;
		};

	
		function pointsInRegion(data, qViewer, chart) {

			var pointsSelected = [];

			function duplicateData(dataToVerificate) {
				var duplicate = false;

				for (var i = 0; i < pointsSelected.length; i++) {
					if (pointsSelected[i].coord === dataToVerificate.coord && pointsSelected[i].value === dataToVerificate.value) {
						duplicate = true;
					}
				}
				return duplicate;
			}

			//Verifico si pertenece a algun pais que contenga areas especiales
			if (qViewer.Region == QueryViewerRegion.Country && (qViewer.Country == QueryViewerCountry.US || qViewer.Country == QueryViewerCountry.ES || qViewer.Country == QueryViewerCountry.PT || qViewer.Country == QueryViewerCountry.FR || qViewer.Country == QueryViewerCountry.GQ || qViewer.Country == QueryViewerCountry.MU)) {

				var specialAreas = [[QueryViewerCountry.US, ['US-AK', 'US-HI', 'US-PR']], [QueryViewerCountry.ES, ['ES-CN', 'ES-IB']], [QueryViewerCountry.PT, ['PT-20', 'PT-30']], [QueryViewerCountry.FR, ['FR-GF', 'FR-RE', 'FR-GP', 'FR-MQ', 'FR-YT']], [QueryViewerCountry.GQ, ['GQ-AN', 'GQ-BS', 'GQ-BN']], [QueryViewerCountry.MU, ['MU-RO', 'MU-CC', 'MU-AG']]];
				var result;
				var xoffset;
				var yoffset;
				var width;
				var lon;
				var lat;
				var regions;
				var limitLon, limitLat;
				var areaWidth;
				var transform;

				for (var p = 0; p < specialAreas.length; p++) {
					if (specialAreas[p][0] == qViewer.Country) {
						regions = specialAreas[p];
						break;
					}
				}

				for (var i = 0; i < chart._coordSysMgr._coordinateSystems[0].regions.length; i++) {

					for (var j = 0; j < regions[1].length; j++) {

						for (var k = 0; k < data.length; k++) {

							if (chart._coordSysMgr._coordinateSystems[0].regions[i].name == regions[1][j]) {

								result = PointInPolygon(data[k].coord, chart._coordSysMgr._coordinateSystems[0].regions[i].properties.specialArea);

								if (result == true) {	//Punto pertenece a un specialArea, cambio las coordenadas

									lon = 0;
									lat = 0;
									height = chart._coordSysMgr._coordinateSystems[0].regions[i].properties.specialAreaHeight;
									xoffset = chart._coordSysMgr._coordinateSystems[0].regions[i]._rect.x;
									yoffset = chart._coordSysMgr._coordinateSystems[0].regions[i]._rect.y;
									width = chart._coordSysMgr._coordinateSystems[0].regions[i]._rect.width;

									if (chart._coordSysMgr._coordinateSystems[0].regions[i].properties.AreaWidth != undefined && chart._coordSysMgr._coordinateSystems[0].regions[i].properties.coordlimit) {

										limitLon = chart._coordSysMgr._coordinateSystems[0].regions[i].properties.coordlimit[0];
										limitLat = chart._coordSysMgr._coordinateSystems[0].regions[i].properties.coordlimit[1];
										areaWidth = chart._coordSysMgr._coordinateSystems[0].regions[i].properties.AreaWidth;
										areaHeight = chart._coordSysMgr._coordinateSystems[0].regions[i].properties.AreaHeight;
										lon = xoffset - [((limitLon - data[k].coord[0]) / areaWidth) * width];
										lat = yoffset + height - Math.abs((((limitLat - data[k].coord[1]) / areaHeight)) * height);

									} else {
										lon = data[k].coord[0] + (xoffset - data[k].coord[0]) + width;
										lat = ((((data[k].coord[1])) * (height)) / 90) + yoffset;
									}

									data[k].coord = [lon, lat];
									transform = data[k];
									transform['name'] = null;
									transform['name'] = chart._coordSysMgr._coordinateSystems[0].regions[i].name;
									pointsSelected.push(transform);
									break;
								}
							} else {

								for (var n = 0; n < chart._coordSysMgr._coordinateSystems[0].regions[i].geometries.length; n++) {

									if (PointInPolygon(data[k].coord, chart._coordSysMgr._coordinateSystems[0].regions[i].geometries[n].exterior)) {

										if (!duplicateData(data[k])) {
											transform = data[k];
											transform['name'] = null;
											transform['name'] = chart._coordSysMgr._coordinateSystems[0].regions[i].name;
											pointsSelected.push(transform);

										}
									}
								}

							}
						}
					}
				}
				return pointsSelected;

			} else if (qViewer.Region == QueryViewerRegion.World && qViewer.MapType != QueryViewerMapType.Choropleth) { //No es necesario filtrar por region ya que es un world map

				return data;

			} else { //En el caso que la region sea un continente o un pais sin areas especiales se filtra por los puntos pertenecientes a dicha region

				var find;
				var transform;

				for (var m = 0; m < data.length; m++) {

					find = false;

					for (var l = 0; l < chart._coordSysMgr._coordinateSystems[0].regions.length && find == false; l++) { //filtro por region

						for (var n = 0; n < chart._coordSysMgr._coordinateSystems[0].regions[l].geometries.length && find==false; n++) {

							if (PointInPolygon(data[m].coord, chart._coordSysMgr._coordinateSystems[0].regions[l].geometries[n].exterior)) {

								transform = data[m];
								transform['name'] = null;
								transform['name'] = chart._coordSysMgr._coordinateSystems[0].regions[l].name;
								pointsSelected.push(transform);
								find = true;
								break;
							}
						}
					}
				}

				return pointsSelected;

			}

		}

		var result = pointsInRegion(data, qViewer, chart);

		return result; 
	}



	function geopointToCharacter(data, chart, qViewer) {

		var transformData = [];
		var value = bubblePoints(data, qViewer, chart);
		var aggregationData = [];
		var resultAgg;
		

		function mergeData(dataToMerge) {
			var repetido = false;
			var values = [];

			for (var i = 0; i < aggregationData.length; i++) {
				if (aggregationData[i].name === dataToMerge.name) {
					values = aggregationData[i].additionalData;
					values.push(dataToMerge.additionalData[0]);
					aggregationData[i].additionalData = values;
					repetido = true;
				}
			}
			if (repetido == false) {
				aggregationData.push(dataToMerge);
			}
		}

		for (var j = 0; j < value.length; j++) {
			transformData.push({ name: value[j].name, value: 0 , additionalData: [value[j].additionalData] });
		}

		for (var k = 0; k < transformData.length; k++) {
			mergeData(transformData[k]);
		}

		for (var n = 0; n < aggregationData.length; n++) {
			resultAgg = qv.util.aggregateData(qViewer.Metadata.Data, aggregationData[n].additionalData, qViewer);
			aggregationData[n].value = resultAgg[qViewer.Metadata.Data[0].DataField];
		}
		
		return aggregationData;
	}


	// ------------------------------------------------------ Highcharts functions------------------------------------------------------

	//Devuelve la serie de un choroplethMap
	function choroplethMapSerie(qViewer) {

		var serie;

			serie = [
				{
					name: qv.util.getTranslation(qViewer.Title),
					type: 'map',
					borderColor: 'gray',
					colorByPoint: false,
					data: getSerieData(qViewer),
					joinBy: ['name', 'hc-key'],
					dataLabels: {
						enabled: true,
						format: '{point.name}'
					}
				}
			];
		

		return serie;
	}

	//Devuelve la serie de un BubbleMap
	function bubbleMapSerie(qViewer) {

		var series;

		//En el caso de ser BubbleData su serie va a ser distinta a si fuese un BubbleColor
		if (qViewer.Chart.colorAxis.dataClasses.length == 0) { // is a bubble data map no hay consitional style
			
			if (!qViewer.Chart.Series.ByIndex[0].Color.Color) {  //el usuario no establecio un color

				series = [{
					enableMouseTracking: false
				}, {
					name: qv.util.getTranslation(qViewer.Title),
					type: 'mapbubble',
					joinBy: ['name', 'hc-key'],
					data: getSerieData(qViewer),
					colorIndex: qViewer.Metadata.Data[0].colorIndex,
					opacity: 0.5,
					showInLegend: true,
					minSize: 4,
					maxSize: '12%'
				}
				];

			} else { // el usuario establecio un color

				series = [{
					color: '#E0E0E0',
					enableMouseTracking: false
				}, {
					name: qv.util.getTranslation(qViewer.Title),
					type: 'mapbubble',
					joinBy: ['name', 'hc-key'],
					data: getSerieData(qViewer),
					styledMode: false,
					color: getColorSerie(qViewer),
					showInLegend: true,
					minSize: 4,
					maxSize: '12%'
				}
				];


			}
			
		} else { // is a bubble color map

			series = [{
				color: '#E0E0E0',
				enableMouseTracking: false
			}, {
				name: qv.util.getTranslation(qViewer.Title),
				type: 'mapbubble',
				joinBy: ['name', 'hc-key'],
				data: getSerieData(qViewer),
				styledMode: false,
				showInLegend: true,
				minSize: 4,
				maxSize: '12%'
			}
			];

		}
		return series;
	}

	function getColorAxis(qViewer) {

		var colorAxis;
	

		if (qViewer.MapType == QueryViewerMapType.Choropleth && qViewer.Chart.colorAxis.dataClasses.length == 0) { // is a intensity color map

			colorAxis = {
				min: 0,
				maxColor: getColorSerie(qViewer)
			}
			return colorAxis;
		}
		if ((qViewer.MapType == QueryViewerMapType.Choropleth && qViewer.Chart.colorAxis.dataClasses.length != 0) || (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Chart.colorAxis.dataClasses.length != 0)) { // is a color scale map, bubble color map or point color map

			colorAxis = qViewer.Chart.colorAxis;
			return colorAxis;
		}

		if ((qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Chart.colorAxis.dataClasses.length == 0)) { // is a color scale map, bubble color map or point color map

			colorAxis = [];
			return colorAxis;
		}
	
		return colorAxis;
	}

	//Devuelve la legend de cada mapa segun el tipo que sea
	function getReferencyMap(qViewer) {

		var legend;
		

		if (qViewer.MapType == QueryViewerMapType.Choropleth) {

			legend = {
				enabled: true
			}

			return legend;

		}
		if (qViewer.MapType == QueryViewerMapType.Bubble) {

			var legend;

			if (qViewer.Chart.colorAxis.dataClasses.length != 0) { // is a bubble color map

				legend = {
					enabled: true
				}

			} else { // is a bubble data map

				legend = {
					enabled: false
				}

			}
			return legend;
		}


		return legend;

	}

	//Carga las series segun el tipo de mapa que se selecciono
	function getSerie(qViewer) {

		var serie;

		if (qViewer.MapType == QueryViewerMapType.Choropleth) {

			serie = choroplethMapSerie(qViewer);
			return serie;

		}

		if (qViewer.MapType == QueryViewerMapType.Bubble) {

			serie = bubbleMapSerie(qViewer);
			return serie;

		}

		return serie;
	}

	//Establece las tooltip para cada mapa segun el tipo que sea
	function getToolTipMaps(qViewer) {

		var tooltip;

		if (qViewer.MapType == QueryViewerMapType.Choropleth) {

			tooltip = {}
			return tooltip;

		}

		if (qViewer.MapType == QueryViewerMapType.Bubble) {

			tooltip = {}
			return tooltip;

		}


		return tooltip;
	}

	function getChartConfig(qViewer) {

		var chart;
		if ((qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Chart.Series.ByIndex[0].Color.Color) || (qViewer.MapType == QueryViewerMapType.Choropleth && qViewer.Chart.colorAxis.dataClasses.length != 0 && !qViewer.Chart.Series.ByIndex[0].Color.Color) || (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Chart.colorAxis.dataClasses.length != 0 && !qViewer.Chart.Series.ByIndex[0].Color.Color)) {
			chart = {
				map: qv.map.getMapDirectory(qViewer).mapKey,
				styledMode: false
			}
		} else {
			chart = {
				map: qv.map.getMapDirectory(qViewer).mapKey,
				styledMode: true
			}
		}

		return chart;
	}

	
	function mapaHighchartsOptions(container, qViewer) {

		// Create the chart
		Highcharts.mapChart(container, {

			chart: getChartConfig(qViewer),

			title: { text: qv.util.getTranslation(qViewer.Title) },

			mapNavigation: {
				enabled: true,
				buttonOptions: {
					verticalAlign: 'bottom'
				}
			},

			tooltip: getToolTipMaps(qViewer),

			series: getSerie(qViewer),

			colorAxis: getColorAxis(qViewer),

			legend: getReferencyMap(qViewer)

		
		});
		qViewer._ControlRenderedTo = qViewer.RealType;

	}

	// ------------------------------------------------------ Echarts functions ------------------------------------------------------

	function checkIfIsHexColor(inputString) {
		var re = /[0-9A-Fa-f]{6}/g;
		var isHex;
		if (re.test(inputString)) {
			isHex = true;
		} else {
			isHex = false;
		}
		re.lastIndex = 0;

		return isHex;
	}

	function convertData (data,chart,qViewer) {
		var res = [];
		var colorCond;

		if (qViewer.MapType == QueryViewerMapType.Choropleth && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint) {
			for (var j = 0; j < data.length; j++) {
				for (var i = 0; i < chart._coordSysMgr._coordinateSystems[0].regions.length; i++) {
					if (chart._coordSysMgr._coordinateSystems[0].regions[i].name == data[j].name) {
						if (qViewer.Chart.colorAxis.dataClasses.length != 0) {
							if (chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center != undefined) {
								colorCond = qViewer.Chart.Series.ByIndex[0].Points[j].Color.Color;
								if (checkIfIsHexColor(colorCond)) {
									colorCond = "#" + colorCond;
								}
								res.push({
									name: data[j].name,
									coord: [chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center[0], chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center[1]],
									value: data[j].value,
									itemStyle: {
										color: colorCond
									}
								});
							} else {
								res.push({
									name: data[j].name,
									coord: [chart._coordSysMgr._coordinateSystems[0].regions[i].center[0], chart._coordSysMgr._coordinateSystems[0].regions[i].center[1]],
									value: data[j].value,
									itemStyle: {
										color: colorCond
									}
								});
							}
						} else {
							if (chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center != undefined) {
								res.push({
									name: data[j].name,
									coord: [chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center[0], chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center[1]],
									value: data[j].value,
									itemStyle: {
										color: getColorSerie(qViewer)
									}
								});
							} else {
								res.push({
									name: data[j].name,
									coord: [chart._coordSysMgr._coordinateSystems[0].regions[i].center[0], chart._coordSysMgr._coordinateSystems[0].regions[i].center[1]],
									value: data[j].value,
									itemStyle: {
										color: getColorSerie(qViewer)
									}
								});
							}
						}
						break;
					}
				}
			}
		} else {
			for (var j = 0; j < qViewer.Chart.Categories.Values.length; j++) {
				for (var i = 0; i < chart._coordSysMgr._coordinateSystems[0].regions.length; i++) {
					if (chart._coordSysMgr._coordinateSystems[0].regions[i].name == qViewer.Chart.Categories.Values[j].Value) {
						if (qViewer.Chart.colorAxis.dataClasses.length != 0) {
							if (chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center != undefined) {
								colorCond = qViewer.Chart.Series.ByIndex[0].Points[j].Color.Color;
								if (checkIfIsHexColor(colorCond)) {
									colorCond = "#" + colorCond;
								}
								res.push({
									name: qViewer.Chart.Categories.Values[j].Value,
									coord: [chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center[0], chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center[1]],
									value: data[j].value,
									itemStyle: {
										color: colorCond
									}
								});
							} else {
								res.push({
									name: qViewer.Chart.Categories.Values[j].Value,
									coord: [chart._coordSysMgr._coordinateSystems[0].regions[i].center[0], chart._coordSysMgr._coordinateSystems[0].regions[i].center[1]],
									value: data[j].value,
									itemStyle: {
										color: colorCond
									}
								});
							}
						} else {
							if (chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center != undefined) {
								res.push({
									name: qViewer.Chart.Categories.Values[j].Value,
									coord: [chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center[0], chart._coordSysMgr._coordinateSystems[0].regions[i].properties.center[1]],
									value: data[j].value,
									itemStyle: {
										color: getColorSerie(qViewer)
									}
								});
							} else {
								res.push({
									name: qViewer.Chart.Categories.Values[j].Value,
									coord: [chart._coordSysMgr._coordinateSystems[0].regions[i].center[0], chart._coordSysMgr._coordinateSystems[0].regions[i].center[1]],
									value: data[j].value,
									itemStyle: {
										color: getColorSerie(qViewer)
									}
								});
							}
						}
						break;
					}
				}
			}
		}
			
		return res;
	}

	function mapaEchartsOptions(container, qViewer) {


		function getLegendObject(qViewer, data, chart) {

			function legendName(qViewer) {

				var pictureProperties = qv.util.GetPictureProperties(qViewer.Chart.Series.ByIndex[0].DataType, qViewer.Chart.Series.ByIndex[0].Picture);
				var names = [];
				var name;
				var operator;
				for (var i = 0; i < qViewer.Chart.colorAxis.dataClasses.length; i++) {
					operator = qViewer.Chart.colorAxis.dataClasses[i].Operator;
					if (operator == QueryViewerConditionOperatorSymbol.Interval) {
						name = qv.util.ApplyPicture(qViewer.Chart.colorAxis.dataClasses[i].from, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties) + operator + qv.util.ApplyPicture(qViewer.Chart.colorAxis.dataClasses[i].to, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties);
					} else if (operator == QueryViewerConditionOperatorSymbol.Equal) {
						name = "" + qv.util.ApplyPicture(qViewer.Chart.colorAxis.dataClasses[i].from, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties);
					} else if (operator == QueryViewerConditionOperatorSymbol.LessThan || operator == QueryViewerConditionOperatorSymbol.LessOrEqual) {
						name = operator + " " + qv.util.ApplyPicture(qViewer.Chart.colorAxis.dataClasses[i].to, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties);
					} else {
						name = operator + " " + qv.util.ApplyPicture(qViewer.Chart.colorAxis.dataClasses[i].from, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties);
					}
					names.push(name);
				}
				return names;
			}

			function legendSeriesBubble(qViewer, data, names, chart) {

				var series = [];
				var serieInicial;
				if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.Character) {
					serieInicial = {
						name: 'serie',
						type: 'map',
						markPoint: {
							nameProperty: "iso-code",
							data: data
						}
					};
				} else { //La query tiene asociado un eje del tipo geopoint
					var dataGeo = bubblePoints(data, qViewer, chart);
					var maxValue = Math.max.apply(Math, dataGeo.map(function (o) { return o.value; }));
					var container = qViewer.getContainerControl();
					var containerSize = Math.min(container.offsetWidth, container.offsetHeight);
					serieInicial = {
						name: 'serie',
						type: 'map',
						markPoint: {
							data: dataGeo,
							symbolSize: function (value) {
								if (value == undefined) {
									return 8;
								} else {
									return Math.sqrt(value / maxValue) * containerSize / 10;	// values represented by the bubble's areas (max size is 10% of the container's size)
								}
							}
						}
					};
				}
				series.push(serieInicial);


				for (var i = 0; i < qViewer.Chart.colorAxis.dataClasses.length; i++) {

					var serie = {
						name: names[i],
						type: 'map',
						data: []
					};
					series.push(serie);
				}
				return series;
			}

			function legendColors(qViewer) {
				if (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.Character)
					var colores = [''];
				else
					var colores = [];

				var color;
				for (var i = 0; i < qViewer.Chart.colorAxis.dataClasses.length; i++) {
					color = qViewer.Chart.colorAxis.dataClasses[i].color;
					colores.push(color);
				}
				return colores;
			}

			var legend = [];
			var names = legendName(qViewer);
			var colors = legendColors(qViewer);
			var series = legendSeriesBubble(qViewer, data, names, chart);

			legend.push(names, colors, series);
			return legend;
		}
		function getDataRange(qViewer, legendStyle) {

			function changeOrder(input, qViewer) {

				var rtlOrder = input;

				if (qv.util.isRTL(qViewer)) {
					var parts = input.split("-");
					var highInterval = parts[0].trim();
					var LowInterval = parts[1].trim();
					var interval_1 = highInterval.split(" ");
					var interval_2 = LowInterval.split(" ");
					rtlOrder = interval_2[1] + " " + interval_2[0] + " - " + interval_1[1] + " " + interval_1[0];
				}
				return rtlOrder;
			}

		function setColorSplitListMap(color) {

			var colorSplitList;

			if (color != null) { //El usuario definio color en el conditional Style 

				colorSplitList = color;

			} else { //El usuario no definio color en el conditional style

				colorSplitList = getColorSerie(qViewer);

			}

				return colorSplitList;
			}

			var dataRange;
			var pictureProperties = qv.util.GetPictureProperties(qViewer.Chart.Series.ByIndex[0].DataType, qViewer.Chart.Series.ByIndex[0].Picture);

		if ((qViewer.MapType == QueryViewerMapType.Choropleth && qViewer.Chart.colorAxis.dataClasses.length != 0) ) { //color Scale

			//le pasamos los datos de map.colorAxis tanto el color como los datos del conditionalStyle


			var splitListMap = [];
			
			for (var i = 0; i < qViewer.Chart.colorAxis.dataClasses.length; i++) {

					var splitList = {};
					var names = getLegendObject(qViewer, "", null)[0];
					if (qViewer.Chart.colorAxis.dataClasses[i].Operator == QueryViewerConditionOperatorSymbol.Interval) {
						splitList = {
							start: qViewer.Chart.colorAxis.dataClasses[i].from,
							end: qViewer.Chart.colorAxis.dataClasses[i].to,
							color: setColorSplitListMap(qViewer.Chart.colorAxis.dataClasses[i].color),
								label: changeOrder(names[i], qViewer) 
						}
					} else if (qViewer.Chart.colorAxis.dataClasses[i].Operator == QueryViewerConditionOperatorSymbol.Equal || qViewer.Chart.colorAxis.dataClasses[i].Operator == QueryViewerConditionOperatorSymbol.NotEqual) {
						splitList = {
							value: qViewer.Chart.colorAxis.dataClasses[i].from,
							color: setColorSplitListMap(qViewer.Chart.colorAxis.dataClasses[i].color),
							label: names[i]
						}
					} else if (qViewer.Chart.colorAxis.dataClasses[i].Operator == QueryViewerConditionOperatorSymbol.GreaterThan) {
						splitList = {
							start: qViewer.Chart.colorAxis.dataClasses[i].from,
							color: setColorSplitListMap(qViewer.Chart.colorAxis.dataClasses[i].color),
							label: names[i]
						}
					} else if (qViewer.Chart.colorAxis.dataClasses[i].Operator == QueryViewerConditionOperatorSymbol.GreaterOrEqual) {
						splitList = {
							start: qViewer.Chart.colorAxis.dataClasses[i].from - 1,
							color: setColorSplitListMap(qViewer.Chart.colorAxis.dataClasses[i].color),
							label: names[i]
						}
					} else if (qViewer.Chart.colorAxis.dataClasses[i].Operator == QueryViewerConditionOperatorSymbol.LessThan) {
						splitList = {
							end: qViewer.Chart.colorAxis.dataClasses[i].to,
							color: setColorSplitListMap(qViewer.Chart.colorAxis.dataClasses[i].color),
							label: names[i]
						}
					} else if (qViewer.Chart.colorAxis.dataClasses[i].Operator == QueryViewerConditionOperatorSymbol.LessOrEqual) {
						splitList = {
							end: qViewer.Chart.colorAxis.dataClasses[i].to + 1,
							color: setColorSplitListMap(qViewer.Chart.colorAxis.dataClasses[i].color),
							label: names[i]
						}
					}
					splitListMap.push(splitList);
				}
				dataRange = {
						x: (qv.util.isRTL(qViewer)) ? 'right' : 'left',
					orient: 'vertical',
					splitList: splitListMap,
					textStyle: legendStyle.TextStyle
				};

			} else if (qViewer.MapType == QueryViewerMapType.Choropleth && qViewer.Chart.colorAxis.dataClasses.length == 0) { //intensity scale

				var color = getColorSerie(qViewer);
				var maxValue;

				dataRange = {
					min: 0,
					calculable: true,
					orient: 'horizontal',
					left: 'center',
					color: [color, 'white'], //gradient color
					textStyle: legendStyle.TextStyle,
						inverse: (qv.util.isRTL(qViewer)),
					formatter: function (name) {
						return qv.util.ApplyPicture(name, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties);
					}
				};


				if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.Character) {
					maxValue = qViewer.Chart.Series.ByIndex[0].MaxValue;
					dataRange.max = maxValue;
				}
			}
			if (qViewer.MapType == QueryViewerMapType.Choropleth) {
				if (legendStyle.BoxStyle.backgroundColor)
					dataRange.backgroundColor = qv.util.color.resolveColor(legendStyle.BoxStyle.backgroundColor, legendStyle.BoxStyle.opacity);
				if (legendStyle.BoxStyle.borderColor)
					dataRange.borderColor = legendStyle.BoxStyle.borderColor;
				if (legendStyle.BoxStyle.borderWidth)
					dataRange.borderWidth = legendStyle.BoxStyle.borderWidth;
			}

		return dataRange;

		}

		function getThemeDefinitions(qViewer) {

			function inheritTextStyle(fatherStyle, childStyle) {
				if (fatherStyle.fontFamily && !childStyle.fontFamily)
					childStyle.fontFamily = fatherStyle.fontFamily;
				if (fatherStyle.fontSize && !childStyle.fontSize)
					childStyle.fontSize = fatherStyle.fontSize;
				if (fatherStyle.fontStyle && !childStyle.fontStyle)
					childStyle.fontStyle = fatherStyle.fontStyle;
				if (fatherStyle.fontWeight && !childStyle.fontWeight)
					childStyle.fontWeight = fatherStyle.fontWeight;
				if (fatherStyle.color && !childStyle.color)
					childStyle.color = fatherStyle.color;
			}

			function updateTextStyle(cssStyle, textStyle) {
				if (cssStyle.fontFamily)
					textStyle.fontFamily = qv.util.css.resolveVariable(cssStyle.fontFamily);
				if (cssStyle.fontSize)
					textStyle.fontSize = parseFloat(qv.util.css.resolveVariable(cssStyle.fontSize));
				if (cssStyle.fontStyle)
					textStyle.fontStyle = qv.util.css.resolveVariable(cssStyle.fontStyle);
				if (cssStyle.fontWeight)
					textStyle.fontWeight = qv.util.css.resolveVariable(cssStyle.fontWeight);
				if (cssStyle.color)
					textStyle.color = qv.util.css.resolveVariable(cssStyle.color);
			}

			function updateBoxStyle(cssStyle, boxStyle) {
				if (cssStyle.backgroundColor)
					boxStyle.backgroundColor = qv.util.css.resolveVariable(cssStyle.backgroundColor);
				if (cssStyle.opacity)
					boxStyle.opacity = qv.util.css.resolveVariable(cssStyle.opacity);
				if (cssStyle.borderWidth)
					boxStyle.borderWidth = parseFloat(qv.util.css.resolveVariable(cssStyle.borderWidth));
				if (cssStyle.borderColor)
					boxStyle.borderColor = qv.util.css.resolveVariable(cssStyle.borderColor);
			}

			function updateAllStyles(rules, containerControlClass, allStyles)
			{
				// Defaults
				allStyles.BackgroundColor = allStyles.BackgroundColor || "white";
				allStyles.SelectionColor = allStyles.SelectionColor || "lightcoral";
				allStyles.Opacity = allStyles.Opacity || "1";
				allStyles.TextStyle = allStyles.TextStyle || { fontFamily: "Source Sans Pro" };
				allStyles.Title = allStyles.Title || { TextStyle: {} };
				allStyles.SeriesLabels = allStyles.SeriesLabels || { TextStyle: {}, BoxStyle: {} };
				allStyles.Legend = allStyles.Legend || { TextStyle: {}, BoxStyle: {} };
				allStyles.Tooltip = allStyles.Tooltip || { TextStyle: {}, BoxStyle: {} };
				
				// Read all rules
				for (var i = 0; i < rules.length; i++) {
					var rule = rules[i];
					if (rule instanceof CSSStyleRule) {
						var cssStyle = rule.style;
						if (rule.selectorText === "." + containerControlClass)
							updateTextStyle(cssStyle, allStyles.TextStyle);
						else if (rule.selectorText === "." + containerControlClass + " .gx-qv-selected-element")
							allStyles.SelectionColor = qv.util.css.resolveVariable(cssStyle.backgroundColor);
						else if (rule.selectorText === "." + containerControlClass + ".qv-map") {
							allStyles.BackgroundColor = qv.util.css.resolveVariable(cssStyle.backgroundColor);
							allStyles.Opacity = qv.util.css.resolveVariable(cssStyle.opacity);
						}
						else if (rule.selectorText === "." + containerControlClass + " .gx-qv-title")
							updateTextStyle(cssStyle, allStyles.Title.TextStyle);
						else if (rule.selectorText === "." + containerControlClass + " .gx-qv-legend-box")
							updateBoxStyle(cssStyle, allStyles.Legend.BoxStyle);
						else if (rule.selectorText === "." + containerControlClass + " .gx-qv-legend-text")
							updateTextStyle(cssStyle, allStyles.Legend.TextStyle);
						else if (rule.selectorText === "." + containerControlClass + " .gx-qv-series-labels-box")
							updateBoxStyle(cssStyle, allStyles.SeriesLabels.BoxStyle);
						else if (rule.selectorText === "." + containerControlClass + " .gx-qv-series-labels-text")
							updateTextStyle(cssStyle, allStyles.SeriesLabels.TextStyle);
						else if (rule.selectorText === "." + containerControlClass + " .gx-qv-tooltip-box")
							updateBoxStyle(cssStyle, allStyles.Tooltip.BoxStyle);
						else if (rule.selectorText === "." + containerControlClass + " .gx-qv-tooltip-text")
							updateTextStyle(cssStyle, allStyles.Tooltip.TextStyle);
					}
					else if (rule instanceof CSSImportRule) {
						var importedRules = rule.styleSheet.rules || rule.styleSheet.cssRules;
						updateAllStyles(importedRules, containerControlClass, allStyles);
					}
					else if (rule instanceof CSSLayerBlockRule) {
						var layeredRules = rule.cssRules;
						updateAllStyles(layeredRules, containerControlClass, allStyles);
					}
				}
			}
			
			var themeStyleSheet = qv.util.GetThemeStyleSheet(qViewer);
			var rules = themeStyleSheet.rules || themeStyleSheet.cssRules;
			var containerControlClass = qv.util.GetContainerControlClass(qViewer);
			var allStyles = {};
			updateAllStyles(rules, containerControlClass, allStyles);
			inheritTextStyle(allStyles.TextStyle, allStyles.Title.TextStyle);
			inheritTextStyle(allStyles.TextStyle, allStyles.Legend.TextStyle);
			inheritTextStyle(allStyles.TextStyle, allStyles.SeriesLabels.TextStyle);
			inheritTextStyle(allStyles.TextStyle, allStyles.Tooltip.TextStyle);
			return allStyles;
		}

		function setLabelStyle(labelObject, style) {
			if (style.TextStyle.fontFamily)
				labelObject.fontFamily = style.TextStyle.fontFamily;
			if (style.TextStyle.fontSize)
				labelObject.fontSize = style.TextStyle.fontSize;
			if (style.TextStyle.fontStyle)
				labelObject.fontStyle = style.TextStyle.fontStyle;
			if (style.TextStyle.fontWeight)
				labelObject.fontWeight = style.TextStyle.fontWeight;
			if (style.TextStyle.color)
				labelObject.color = style.TextStyle.color;
			if (style.BoxStyle.backgroundColor)
				labelObject.backgroundColor = qv.util.color.resolveColor(style.BoxStyle.backgroundColor, style.BoxStyle.opacity);
			if (style.BoxStyle.borderColor)
				labelObject.borderColor = style.BoxStyle.borderColor;
			if (style.BoxStyle.borderWidth) {
				labelObject.padding = 3;
				labelObject.borderWidth = style.BoxStyle.borderWidth;
			}
		}

		function getSeriesObject(qViewer, themeDefinitions) {

			var seriesColor = getColorSerie(qViewer);
			var showValuesInMarkPoint = gx.lang.gxBoolean(qViewer.ShowValues) && qViewer.MapType === QueryViewerMapType.Bubble;
			var container = qViewer.getContainerControl();
			var containerSize = Math.min(container.offsetWidth, container.offsetHeight);

			var pictureProperties = qv.util.GetPictureProperties(qViewer.Chart.Series.ByIndex[0].DataType, qViewer.Chart.Series.ByIndex[0].Picture);

			var series = {
				type: 'map',
				map: qv.map.getMapDirectory(qViewer).mapKey,
				roam: true,
				scaleLimit: {
					min: 1
				},
				selectedMode: qViewer.SelectionAllowed() ? 'single' : false,
				label: {
					show: false,
					formatter: '{c}'
				},
				emphasis: {
					label: {
						show: false
					},
					itemStyle: {
						borderWidth: 0.5
					}
				},
				select: {
					label: {
						show: false
					},
					itemStyle: {
						borderWidth: 0.5
					}
				}
			};

			if (qViewer.MapType === QueryViewerMapType.Choropleth) {
				series.nameProperty = "iso-code";
				if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.Character) {
					series.data = getSerieData(qViewer);
				}
				setLabelStyle(series.label, themeDefinitions.SeriesLabels);
				series.select.itemStyle.areaColor = themeDefinitions.SelectionColor;
				series.emphasis.itemStyle.borderWidth = 1;
				series.emphasis.itemStyle.areaColor = null;
				series.emphasis.itemStyle.borderColor = qv.util.color.lightenDarkenColor(seriesColor, 50);
			}
			else if (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.Character) {
				var maxValue = qViewer.Chart.Series.ByIndex[0].MaxValue;
				if (qViewer.Chart.colorAxis.dataClasses.length === 0)
					series.color = seriesColor;
				series.nameProperty = "iso-code";
				series.emphasis.itemStyle.areaColor = '#eeeeee';
				series.select.itemStyle.areaColor = '#eeeeee';
				series.data = getSerieData(qViewer),
					series.showLegendSymbol = false,
					series.markPoint = {
						symbol: 'circle',
						symbolSize: function (value) {
							return Math.sqrt(value / maxValue) * containerSize / 10;	// values represented by the bubble's areas (max size is 10% of the container's size)
						},
						label: {
							show: showValuesInMarkPoint,
							formatter: function (v) {
								return qv.util.ApplyPicture(v.value, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties);
							}
						},
						itemStyle: {
							opacity: 0.6,
							borderColor: qv.util.color.lightenDarkenColor(seriesColor, 50),
							borderWidth: 1
						},
						emphasis: {
							label: {
								show: showValuesInMarkPoint
							},
							itemStyle: {
								opacity: 0.7,
								borderColor: qv.util.color.lightenDarkenColor(seriesColor, 100),
								borderWidth: 2
							}
						}
					};
				setLabelStyle(series.markPoint.label, themeDefinitions.SeriesLabels);

			} else if (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint) {									//Bubble map con geopoint

				series.color = seriesColor;
				series.nameProperty = "iso-code";
				series.emphasis.itemStyle.areaColor = '#eeeeee';
				series.select.itemStyle.areaColor = '#eeeeee';
				series.data = [],
					series.markPoint = {
						symbol: 'circle',
						label: {
							show: showValuesInMarkPoint,
							formatter: function (v) {
								return qv.util.ApplyPicture(v.value, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties);
							}
						},
						itemStyle: {
							opacity: 0.6,
							borderColor: qv.util.color.lightenDarkenColor(seriesColor, 50),
							borderWidth: 1
						},
						emphasis: {
							label: {
								show: showValuesInMarkPoint
							},
							itemStyle: {
								opacity: 0.7,
								borderColor: qv.util.color.lightenDarkenColor(seriesColor, 100),
								borderWidth: 2
							}
						}
					};
				setLabelStyle(series.markPoint.label, themeDefinitions.SeriesLabels);
			}

			return series;
		}

		function getTitleObject(qViewer, titleStyle) {
			return {
				text: qv.util.getTranslation(qViewer.Title),
				left: "center",
				textStyle: titleStyle.TextStyle
			};
		}

		function getTooltipObject(qViewer, tooltipStyle) {
			var pictureProperties = qv.util.GetPictureProperties(qViewer.Chart.Series.ByIndex[0].DataType, qViewer.Chart.Series.ByIndex[0].Picture);

			var tooltipObject;
			if ((qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.Character) || qViewer.MapType == QueryViewerMapType.Choropleth) {
				tooltipObject = {
					trigger: 'item',
					textStyle: tooltipStyle.TextStyle,
					formatter: function (params) {
						for (var i = 0; i < chart._coordSysMgr._coordinateSystems[0].regions.length; i++) {
							if (chart._coordSysMgr._coordinateSystems[0].regions[i].name == params.name) {
								if (Number.isNaN(params.value)) {
									return (qv.util.isRTL(qViewer)) ? qv.util.dom.createSpan(null, "", "", "", { direction: "ltr", unicodeBidi: "bidi-override", whiteSpace: "nowrap" }, null, '0' + ' : ' + chart._coordSysMgr._coordinateSystems[0].regions[i].properties.name).outerHTML : chart._coordSysMgr._coordinateSystems[0].regions[i].properties.name + ' : ' + '0';
								} else {
									return (qv.util.isRTL(qViewer)) ? qv.util.dom.createSpan(null, "", "", "", { direction: "ltr", unicodeBidi: "bidi-override", whiteSpace: "nowrap" }, null, qv.util.ApplyPicture(params.value, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties) + " : " + chart._coordSysMgr._coordinateSystems[0].regions[i].properties.name).outerHTML  : chart._coordSysMgr._coordinateSystems[0].regions[i].properties.name + ' : ' + qv.util.ApplyPicture(params.value, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties);
								}
							}
						}
					}
				}
			} else if (qViewer.MapType == QueryViewerMapType.Bubble && qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint) {		//bubble map con geopoint
				coordData = getSerieData(qViewer);
				tooltipObject = {
					trigger: 'item',
					textStyle: tooltipStyle.TextStyle,
					formatter: function (params) {
						var nameValue = qViewer.Chart.Series.ByIndex[0].Name;
						if (Number.isNaN(params.value)) {
							for (var i = 0; i < chart._coordSysMgr._coordinateSystems[0].regions.length; i++) {
								if (chart._coordSysMgr._coordinateSystems[0].regions[i].name == params.name) {
									return chart._coordSysMgr._coordinateSystems[0].regions[i].properties.name;
								}
							}
						}
						else {
							if (params.value != undefined) {
								return (qv.util.isRTL(qViewer)) ? qv.util.dom.createSpan(null, "", "", "", { direction: "ltr", unicodeBidi: "bidi-override", whiteSpace: "nowrap" }, null, qv.util.ApplyPicture(params.value, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties) + " :" + nameValue + '<br />' + params.data.coord[1] + " " + gx.getMessage("GXPL_QViewerMapLongitude") + '<br />' + params.data.coord[0] + " " + gx.getMessage("GXPL_QViewerMapLatitude")).outerHTML :
									gx.getMessage("GXPL_QViewerMapLatitude") + " " + params.data.coord[0] + '<br />' + gx.getMessage("GXPL_QViewerMapLongitude") + " " + params.data.coord[1] + '<br />' + nameValue + ": " + qv.util.ApplyPicture(params.value, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties);
							} else {
								return (qv.util.isRTL(qViewer)) ? qv.util.dom.createSpan(null, "", "", "", { direction: "ltr", unicodeBidi: "bidi-override", whiteSpace: "nowrap" }, null, params.data.coord[1] + " " + gx.getMessage("GXPL_QViewerMapLongitude") + '<br />' + params.data.coord[0] + " " + gx.getMessage("GXPL_QViewerMapLatitude")).outerHTML :
									gx.getMessage("GXPL_QViewerMapLatitude") + " " + params.data.coord[0] + '<br />' + gx.getMessage("GXPL_QViewerMapLongitude") + " " + params.data.coord[1];
							}
						}
					}
				}
			}

			if (tooltipStyle.BoxStyle.backgroundColor)
				tooltipObject.backgroundColor = qv.util.color.resolveColor(tooltipStyle.BoxStyle.backgroundColor, tooltipStyle.BoxStyle.opacity);
			if (tooltipStyle.BoxStyle.borderColor)
				tooltipObject.borderColor = tooltipStyle.BoxStyle.borderColor;
			if (tooltipStyle.BoxStyle.borderWidth)
				tooltipObject.borderWidth = tooltipStyle.BoxStyle.borderWidth;
			return tooltipObject;
		}

		function SetCheckMapSizeInterval(qViewer) {
			// Echarts maps don't resize automatically if the container is resized. So we check every 500 milliseconds the size of the container and resize the map accordingly
			var code = "try { qv.map.CheckMapSize(" + qViewer.me() + ") } catch (e) {}";
			qViewer.IntervalCheckChartSize = setInterval(code, 500);
		}



		if (container.offsetHeight == 0) {
			container.style.height = "400px";		// Chart library needs non-zero width and height
			container.style.overflow = 'hidden';
		}

		var chart = echarts.init(container);

		var themeDefinitions = getThemeDefinitions(qViewer);

		chart.clear();

		var option = {
			backgroundColor: qv.util.color.resolveColor(themeDefinitions.BackgroundColor, themeDefinitions.Opacity),
			series: getSeriesObject(qViewer, themeDefinitions),
			title: getTitleObject(qViewer, themeDefinitions.Title),
			dataRange: getDataRange(qViewer, themeDefinitions.Legend),
			tooltip: getTooltipObject(qViewer, themeDefinitions.Tooltip)
		};

		initCursor(chart);

		chart.setOption(option);

		var pictureProperties = qv.util.GetPictureProperties(qViewer.Chart.Series.ByIndex[0].DataType, qViewer.Chart.Series.ByIndex[0].Picture);

		chart.lastSelected = null;
		chart.BubbleSelect = null;

		//Cambio el cursor
		if (qViewer.SelectionAllowed()) {
			changeCursor(chart, qViewer);
		}

		if (qViewer.ItemClick && qViewer.Metadata.Data[0].RaiseItemClick) {
			MapsClickEvent(chart, qViewer);
		}

		if (qViewer.MapType == QueryViewerMapType.Bubble) {
			var data = convertData(getSerieData(qViewer), chart, qViewer);

			if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.Character) {
				data = convertData(getSerieData(qViewer), chart, qViewer);
			} else {
				data = getSerieData(qViewer);
			}
			var legend = getLegendObject(qViewer, data, chart);
			option = {
				color: legend[1],
				series: legend[2],
				legend: {
					orient: 'vertical',
					x: 'left',
					y: 'bottom',
					selectedMode: false,
					data: legend[0],
					textStyle: themeDefinitions.Legend.TextStyle,
					formatter: function (name) {
						return name;
					}
				}
			};

			if (qViewer.SelectionAllowed()) {
				chart.on('click', function (params) {
					if (params.componentType === 'markPoint') {
						var option = chart.getOption();
						var colorBubble;
						if (qViewer.Chart.colorAxis.dataClasses.length == 0) { //cuando no tiene conditional style
							colorBubble = option.series[0].color;
						} else {
							colorBubble = qViewer.Chart.Series.ByIndex[0].Points[params.dataIndex].Color.Color;
							if (checkIfIsHexColor(colorBubble)) {
								colorBubble = "#" + colorBubble;
							}
						}
						if (chart.lastSelected != params.dataIndex) {
							if (chart.lastSelected != null) {
								if (qViewer.Chart.colorAxis.dataClasses.length == 0) {
									option.series[0].markPoint.data[chart.lastSelected].itemStyle = { color: option.series[0].color }
								} else {
									colorLastBubble = qViewer.Chart.Series.ByIndex[0].Points[chart.lastSelected].Color.Color;
									if (checkIfIsHexColor(colorLastBubble)) {
										colorLastBubble = "#" + colorLastBubble;
									}
									option.series[0].markPoint.data[chart.lastSelected].itemStyle = { color: colorLastBubble};
								}
							}
							option.series[0].markPoint.data[params.dataIndex].itemStyle = { color: themeDefinitions.SelectionColor };
							chart.lastSelected = params.dataIndex;
							chart.BubbleSelect = params.dataIndex;
						} else {
							option.series[0].markPoint.data[params.dataIndex].itemStyle = { color: colorBubble };
							chart.lastSelected = null;
							chart.BubbleSelect = params.dataIndex;
						}
						chart.setOption(option);
					}
				});
			}

			if (qViewer.Chart.colorAxis.dataClasses.length != 0) {
				if (themeDefinitions.Legend.BoxStyle.backgroundColor)
					option.legend.backgroundColor = qv.util.color.resolveColor(themeDefinitions.Legend.BoxStyle.backgroundColor, themeDefinitions.Legend.BoxStyle.opacity);
				if (themeDefinitions.Legend.BoxStyle.borderColor)
					option.legend.borderColor = themeDefinitions.Legend.BoxStyle.borderColor;
				if (themeDefinitions.Legend.BoxStyle.borderWidth)
					option.legend.borderWidth = themeDefinitions.Legend.BoxStyle.borderWidth;
			}

			chart.setOption(option);

		} else if (qViewer.MapType == QueryViewerMapType.Choropleth) {
			var data;

			if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.GeoPoint) {
				data = geopointToCharacter(getSerieData(qViewer), chart, qViewer);
				maxValue = Math.max.apply(Math, data.map(function (o) { return o.value; }));

				option = {
					series: {
						data: data
					},
					dataRange: {
						max: maxValue
					}
				};

				
			}
			chart.setOption(option);

			if (gx.lang.gxBoolean(qViewer.ShowValues)) {
				if (qViewer.Metadata.Axes[0].DataType == QueryViewerDataType.Character) {
					dataValues = convertData(getSerieData(qViewer), chart, qViewer);
				} else {
					dataValues = convertData(data, chart, qViewer);
				}
				option = {
					series: {
						markPoint: {
							symbol: 'circle',
							symbolSize: function (v) {
								return 0;
							},
							label: {
								show: true,
								color: 'black',
								formatter: function (v) {
									return qv.util.ApplyPicture(v.value, qViewer.Chart.Series.ByIndex[0].Picture, qViewer.Chart.Series.ByIndex[0].DataType, pictureProperties);
								}
							},
							data: dataValues
						}
					}
				};
				setLabelStyle(option.series.markPoint.label, themeDefinitions.SeriesLabels);
			}
			chart.setOption(option);
			
		}
		qViewer.Charts = [chart];
		SetCheckMapSizeInterval(qViewer);
		qViewer._ControlRenderedTo = qViewer.RealType;

	}

	// ---------------------------------------------------- end  functions -------------------------------------------

	return {

		tryToRenderMap: function (qViewer) {

			function renderMap() {
				var qvClasses = qv.util.GetContainerControlClasses(qViewer);
				if (qvClasses != "")
					qv.util.SetUserControlClass(qViewer, qvClasses);
				var errMsg = qv.util.ProcessDataAndMetadata(qViewer);
				if (errMsg == "") {
					var container = qViewer.getContainerControl();
					qv.util.hideActivityIndicator(qViewer);		// Must be hidden before starting to render the map in order to check the actual size of the container
					if (qViewer.MapLibrary == QueryViewerMapLibrary.Highcharts) {
						mapaHighchartsOptions(container, qViewer);
					} else { //ECharts
						var exist = echarts.getMap(qv.map.getMapDirectory(qViewer).mapKey);
						if (exist == null) {
							qv.util.renderError(qViewer, gx.getMessage("GXPL_QViewerNoMapSupport"));
						} else {
							mapaEchartsOptions(container, qViewer);
						}
					}
				}
				else
					qv.util.renderError(qViewer, errMsg);
			}

			var errMsg = "";

			// Ejecuto el primer servicio y verifico que no haya habido error
			var d1 = new Date();
			var t1 = d1.getTime();

			qViewer.xml = qViewer.xml || {};

			qv.services.GetRecordsetCacheKeyIfNeeded(qViewer, function (resText, qViewer) {			// Servicio GetRecordsetCacheKey
				var newRecordsetCacheKey = false;
				if (resText != qViewer.xml.recordsetCacheKey) {
					qViewer.xml.recordsetCacheKey = resText;
					newRecordsetCacheKey = true;
				}
				if (!qv.util.anyError(resText)) {
					if (newRecordsetCacheKey)
						qv.services.parseRecordsetCacheKeyXML(qViewer);

					qv.services.GetMetadataIfNeeded(qViewer, function (resText, qViewer) {			// Servicio GetMetadata
						var newMetadata = false;
						if (resText != qViewer.xml.metadata) {
							qViewer.xml.metadata = resText;
							newMetadata = true;
						}
						var d2 = new Date();
						var t2 = d2.getTime();
						if (!qv.util.anyError(resText)) {
							if (newMetadata)
								qv.services.parseMetadataXML(qViewer);

							if (qViewer.Metadata.ParserResult.Success) {
								qv.services.GetDataIfNeeded(qViewer, function (resText, qViewer) {		// Servicio GetData
									var newData = false;
									if (resText != qViewer.xml.data) {
										qViewer.xml.data = resText;
										newData = true;
									}
									var d3 = new Date();
									var t3 = d3.getTime();
									if (!qv.util.anyError(resText)) {
										if (newData)
											qv.services.parseDataXML(qViewer);
										renderMap();
									} else {
										// Error en el servicio GetData
										errMsg = qv.util.getErrorFromText(resText);
										qv.util.renderError(qViewer, errMsg);
									}
								});
							}
							else
								qv.util.renderError(qViewer, qViewer.Metadata.ParserResult.Message);

						}
						else {
							// Error en el servicio GetMetadata
							errMsg = qv.util.getErrorFromText(resText);
							qv.util.renderError(qViewer, errMsg);
						}
					});

				}
				else {
					// Error en el servicio GetRecordsetCachekey
					errMsg = qv.util.getErrorFromText(resText);
					qv.util.renderError(qViewer, errMsg);
				}
			});

		},

		// Devuelve el directorio del mapa seleccionado para su posterior carga dinamica
		getMapDirectory: function(qViewer) {

			var dir = "QueryViewer/" + (qViewer.MapLibrary === QueryViewerMapLibrary.Highchart ? "highcharts/" : "Echarts/");
			var key;
			var mapa = {};

			if (qViewer.Region == QueryViewerRegion.Country) {

				dir = dir + "countries/" + qViewer.Country.toLowerCase() + "-all.js";
				key = "countries/" + qViewer.Country.toLowerCase() + "/" + qViewer.Country.toLowerCase() + "-all";

			} else {
				if (qViewer.Region == QueryViewerRegion.Continent) { 

					key = "custom/";
					dir = dir + "continents/";

					var keyAux;
					switch (qViewer.Continent) {
						case QueryViewerContinent.SouthAmerica:
							keyAux = "south-america";
							break;
						case QueryViewerContinent.NorthAmerica:
							keyAux = "north-america";
							break;
						default:
							keyAux = qViewer.Continent.toLowerCase();
							break;
					}
					key += keyAux;
					dir += keyAux + ".js";

				} else {
					if (qViewer.MapLibrary == QueryViewerMapLibrary.Highcharts) {
						key = "custom/world-highres";
						dir = dir + "continents/world-highres.js";
					} else { //Echarts
						key = "world";
						dir = dir + "World/world.js";
					}
				}
			}

			mapa = {
				mapKey:	key,
				mapDir:	dir
			}

			return mapa;
		},

		GetMetadataMap: function (qViewer) {
			return qv.util.GetDesigntimeMetadata(qViewer);
		},

		GetDataMap: function (qViewer) {
			return qViewer.xml.data;
		},

		CheckMapSize: function (qViewer) {
			var container = qViewer.getContainerControl();
			if (container.offsetWidth != qViewer.Chart._lastWidth || container.offsetHeight != qViewer.Chart._lastHeight) {
				var chart = qViewer.Charts[0];
				chart.resize({ width: container.offsetWidth + 'px', height: container.offsetHeight + 'px' });
				qViewer.Chart._lastWidth = container.offsetWidth;
				qViewer.Chart._lastHeight = container.offsetHeight;
			}
		},

		IsAfricanCountry: function (country) {
			var countries = [
				"DZ", // "Algeria"
				"AO", // "Angola"
				"BJ", // "Benin"
				"BW", // "Botswana"
				"BF", // "Burkina Faso"
				"BI", // "Burundi"
				"CM", // "Cameroon"
				"CV", // "Cape Verde"
				"CF", // "Central African Republic"
				"TD", // "Chad"
				"KM", // "Comoros"
				"CD", // "Democratic Republic of the Congo"
				"DJ", // "Djibouti"
				"EG", // "Egypt"
				"GQ", // "Equatorial Guinea"
				"ER", // "Eritrea"
				"SZ", // "Eswatini"
				"ET", // "Ethiopia"
				"GA", // "Gabon"
				"GM", // "Gambia"
				"GH", // "Ghana"
				"GN", // "Guinea"
				"GW", // "Guinea Bissau" 
				"CI", // "Ivory Coast" 
				"KE", // "Kenya"
				"LS", // "Lesotho"
				"LR", // "Liberia"
				"LY", // "Libya"
				"MG", // "Madagascar"
				"MW", // "Malawi"
				"ML", // "Mali"
				"MR", // "Mauritania"
				"MU", // "Mauritius"
				"MA", // "Morocco"
				"MZ", // "Mozambique"
				"NA", // "Namibia"
				"NE", // "Niger"
				"NG", // "Nigeria"
				"CG", // "Republic of the Congo"
				"RW", // "Rwanda"
				"ST", // "São Tomé and Príncipe"
				"SN", // "Senegal"
				"SC", // "Seychelles"
				"SL", // "Sierra Leone"
				"SO", // "Somalia"
				"ZA", // "South Africa"
				"SS", // "South Sudan"
				"SD", // "Sudan"
				"TZ", // "Tanzania"
				"TG", // "Togo"
				"TN", // "Tunisia"
				"UG", // "Uganda"
				"EH", // "Western Sahara"
				"ZM", // "Zambia"
				"ZW"  // "Zimbabwe"
			];
			return countries.indexOf(country) >= 0;
		},

		IsAsianCountry: function (country) {
			var countries = [
				"AF", // "Afghanistan"
				"AZ", // "Azerbaijan"
				"AM", // "Armenia"
				"BH", // "Bahrain"
				"BD", // "Bangladesh"
				"BT", // "Bhutan"
				"BN", // "Brunei"
				"KH", // "Cambodia"
				"CN", // "China"
				"CY", // "Cyprus"
				"TL", // "East Timor"
				"GE", // "Georgia"
				"IN", // "India"
				"ID", // "Indonesia"
				"IR", // "Iran"
				"IQ", // "Iraq"
				"IL", // "Israel"
				"JP", // "Japan"
				"JO", // "Jordan"
				"KZ", // "Kazakhstan"
				"KW", // "Kuwait"
				"KG", // "Kyrgyzstan"
				"LA", // "Laos"
				"LB", // "Lebanon"
				"MY", // "Malaysia"
				"MV", // "Maldives"
				"MN", // "Mongolia"
				"MM", // "Myanmar"
				"NP", // "Nepal"
				"KP", // "North Korea"
				"OM", // "Oman"
				"PK", // "Pakistan"
				"PS", // "Palestine"
				"PH", // "Philippines"
				"QA", // "Qatar"
				"RU", // "Russia"
				"SA", // "Saudi Arabia"
				"SG", // "Singapore"
				"KR", // "South Korea"
				"LK", // "Sri Lanka"
				"PS", // "State of Palestine"
				"SY", // "Syria"
				"TW", // "Taiwan"
				"TJ", // "Tajikistan"
				"TH", // "Thailand"
				"TR", // "Turkey"
				"TM", // "Turkmenistan"
				"AE", // "United Arab Emirates"
				"UZ", // "Uzbekistan"
				"VN", // "Vietnam"
				"YE"  // "Yemen"
			];
			return countries.indexOf(country) >= 0;
		},

		IsEuropeanCountry: function (country) {
			var countries = [
				"AL", // "Albania"
				"AD", // "Andorra"
				"AT", // "Austria"
				"AZ", // "Azerbaijan"
				"AM", // "Armenia"
				"BY", // "Belarus"
				"BE", // "Belgium"
				"BA", // "Bosnia and Herzegovina"
				"BG", // "Bulgaria"
				"HR", // "Croatia"
				"CY", // "Cyprus"
				"CZ", // "Czech Republic"
				"DK", // "Denmark"
				"EE", // "Estonia"
				"FO", // "Faroe Islands"
				"FI", // "Finland"
				"FR", // "France"
				"GE", // "Georgia"
				"DE", // "Germany"
				"GR", // "Greece"
				"HU", // "Hungary"
				"IS", // "Iceland"
				"IE", // "Ireland"
				"IT", // "Italy"
				"XK", // "Kosovo"
				"LV", // "Latvia"
				"LI", // "Liechtenstein"
				"LT", // "Lithuania"
				"LU", // "Luxembourg"
				"MT", // "Malta"
				"MD", // "Moldova"
				"MC", // "Monaco"
				"ME", // "Montenegro"
				"NL", // "Netherlands"
				"MK", // "North Macedonia"
				"NO", // "Norway"
				"PL", // "Poland"
				"PT", // "Portugal"
				"RO", // "Romania"
				"RU", // "Russia"
				"SM", // "San Marino"
				"RS", // "Serbia"
				"SK", // "Slovakia"
				"SI", // "Slovenia"
				"ES", // "Spain"
				"SE", // "Sweden"
				"CH", // "Switzerland"
				"TR", // "Turkey"
				"UA", // "Ukraine"
				"GB", // "United Kingdom"
				"VA"  // "Vatican City"
			];
			return countries.indexOf(country) >= 0;
		},

		IsNorthAmericanCountry: function (country) {
			var countries = [
				"AI", // "Anguilla"
				"AG", // "Antigua and Barbuda"
				"BB", // "Barbados"
				"BZ", // "Belize"
				"BM", // "Bermuda"
				"VG", // "British Virgin Islands"
				"CA", // "Canada"
				"CR", // "Costa Rica"
				"CU", // "Cuba"
				"DM", // "Dominica"
				"DO", // "Dominican Republic"
				"SV", // "El Salvador"
				"GL", // "Greenland"
				"GD", // "Grenada"
				"GT", // "Guatemala"
				"HT", // "Haiti"
				"HN", // "Honduras"
				"JM", // "Jamaica"
				"MX", // "Mexico"
				"NI", // "Nicaragua"
				"PA", // "Panama"
				"PR", // "Puerto Rico"
				"LC", // "Saint Lucia"
				"KN", // "Saint Kitts and Nevis"
				"VC", // "Saint Vincent and the Grenadines"
				"BS", // "The Bahamas"
				"US", // "United States of America"
				"TT"  // "Trinidad and Tobago"
			];
			return countries.indexOf(country) >= 0;
		},

		IsOceanianCountry: function (country) {
			var countries = [
				"AU", // "Australia"
				"CK", // "Cook Islands"
				"FJ", // "Fiji"
				"ID", // "Indonesia"
				"KI", // "Kiribati"
				"MY", // "Malaysia"
				"MH", // "Marshall Islands"
				"FM", // "Micronesia"
				"NR", // "Nauru"
				"NC", // "New Caledonia"
				"NZ", // "New Zealand"
				"PW", // "Palau"
				"PG", // "Papua New Guinea"
				"PH", // "Philippines"
				"WS", // "Samoa"
				"SB", // "Solomon Islands"
				"TK", // "Tokelau"
				"TO", // "Tonga"
				"TV", // "Tuvalu"
				"VU"  // "Vanuatu"
			];
			return countries.indexOf(country) >= 0;
		},

		IsSouthAmericanCountry: function (country) {
			var countries = [
				"AR", // "Argentina"
				"BO", // "Bolivia"
				"BR", // "Brazil"
				"CL", // "Chile"
				"CO", // "Colombia"
				"EC", // "Ecuador"
				"GF", // "French Guiana"
				"GY", // "Guyana"
				"PY", // "Paraguay"
				"PE", // "Peru"
				"SR", // "Suriname"
				"TT", // "Trinidad and Tobago"
				"UY", // "Uruguay"
				"VE"  // "Venezuela"
			];
			return countries.indexOf(country) >= 0;
		},
		
		Select: function (qViewer, selection) {
			var option = qViewer.Charts[0].getOption();
			option.series[0].selectedMode = "single";
			qViewer.Charts[0].setOption(option);
			qViewer._selectedValue = selection[0].Value;
			qViewer.Charts[0].dispatchAction({type: 'select', seriesIndex: 0, name: qViewer._selectedValue});
			option = qViewer.Charts[0].getOption();
			option.series[0].selectedMode = false;
			qViewer.Charts[0].setOption(option);
		},

		Deselect: function (qViewer) {
			qViewer.Charts[0].dispatchAction({type: 'unselect', seriesIndex: 0, name: qViewer._selectedValue});
			qViewer._selectedValue = undefined;
		}

	}
}) ()



/* END OF FILE - ..\Sources\Map.src.js - */
