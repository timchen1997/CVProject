   M S B A M L   `   `   `  ���� D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  U QInteractiveDataDisplay.WPF, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullkLclr-namespace:InteractiveDataDisplay.WPF;assembly=InteractiveDataDisplay.WPFInteractiveDataDisplay.WPF %    CVProject.Dialog.ContrastDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CVProject.Dialog     [d3Lclr-namespace:InteractiveDataDisplay.WPF;assembly=InteractiveDataDisplay.WPF     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  Adjust Contrast��$	��423��$	��800�����	#FF363636 � WindowStyle$ 
ToolWindow=� � WindowStartupLocation$ CenterScreen=�.��� .+�	� -    	�Name$ 
rbtnLinear��$�� ��$
��Left=�$��	10,10,0,0q�$	��Top=�	� -   $ rbtnLog��$�� ��$
��Left=�$��
386,10,0,0q�$	��Top=�	� -   $ rbtnExp��$�� ��$
��Left=�$��386,144,0,0q�$	��Top=��� -    ��Name$ 
gboxLinear��$��Linear��$
��Left=�$��	36,10,0,0q�$	��Top=�$	��345��$	��372��.��� .+�&   InteractiveDataDisplay.WPF.Chart  -     Name$ plotter��$��10,10,69,69q����	#FF363636
�������   LegendContent 1  +InteractiveDataDisplay.WPF.LegendItemsPanel   � 	Resources  (  $InteractiveDataDisplay.WPF.LineGraph��%   &	        ��    Title �� $��Center=�$��9(�$��0,5,0,5q�.��� -   	 �Name$	 lines��#  Xceed.Wpf.Toolkit.RangeSlider  -   $��HSlider��$
��Left=�$��
39,278,0,0q�$	��Top=�$	��225��
   Minimum$
 0Q�   Maximum$	 255Q�   
LowerValue$	 100Q�   HigherValue$	 200Q�  -   $��VSlider��$
��Left=�$��
269,32,0,0q�$	��Top=�   Orientation$ Vertical=�$	��211��$
 0Q�$	 255Q�$	 100Q�$	 200Q�%  Xceed.Wpf.Toolkit.IntegerUpDown  -	   $��x1��$
��Left=�$��
30,309,0,0q�$	��Top=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value ��  �� ElementName$ HSlider�� �� Path$ 
LowerValue��� -
    ��Name$ label��$��X1��$
��Left=�$��
10,312,0,0q�$	��Top=�  -   $��x2��$
��Left=�$��110,309,0,0q�$	��Top=� �� $ HSlider��$ HigherValue��� -   $ 
label_Copy��$��X2��$
��Left=�$��
90,312,0,0q�$	��Top=�  -   $��y1��$
��Left=�$��190,309,0,0q�$	��Top=� �� $ VSlider��$ 
LowerValue��� -   $ label_Copy1��$��Y1��$
��Left=�$��170,312,0,0q�$	��Top=�  -   $��y2��$
��Left=�$��270,309,0,0q�$	��Top=� �� $ VSlider��$ HigherValue��� -   $ label_Copy2��$��Y2��$
��Left=�$��250,312,0,0q�$	��Top=��� -   $ gboxLog��$��	Logarithm��$
��Left=�$��
412,10,0,0q�$	��Top=�$	��370��$	��129��.��� .+��� -   $ label1��$
��A = ��$
��Left=�$��	62,32,0,0q�$	��Top=�$��24(�$  Xceed.Wpf.Toolkit.DoubleUpDown  -   $
��logV��$
��Left=�$��
111,37,0,0q�$	��Top=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 10X��  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	Increment$ 1X��� -   $ label1_Copy��$�� * Ln(A + 1) ��$
��Left=�$��
157,32,0,0q�$	��Top=�$��24(��� -   $ gboxExp��$��Exponent��$
��Left=�$��412,144,0,0q�$	��Top=�$	��370��$	��129��.��� .+��� -   $ label1_Copy1��$
��A = ��$
��Left=�$��	62,32,0,0q�$	��Top=�$��24(�  -   $
��expV��$
��Left=�$��
111,37,0,0q�$	��Top=�$	 0.1X�$
 0.01X��� -   $ label1_Copy2��$��
 * Exp(A) ��$
��Left=�$��
157,32,0,0q�$	��Top=�$��24(�	� -   $ rbtnBal��$�� ��$
��Left=�$��386,278,0,0q�$	��Top=��� -   $ groupBox1_Copy1��$��Balance��$
��Left=�$��412,278,0,0q�$	��Top=�$	��370��$��24���� -    ��Name$ btnOK��$��OK��$
��Left=�$��627,365,0,0q�$	��Top=�$��75���� -   $ 	btnCancel��$��Cancel��$
��Left=�$��707,365,0,0q�$	��Top=�$��75��