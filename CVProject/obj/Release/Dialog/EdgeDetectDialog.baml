   M S B A M L   `   `   `  ���� D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  '    !CVProject.Dialog.EdgeDetectDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CVProject.Dialog     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  
EdgeDetect��$	��325��$	��300�����	#FF363636 � WindowStartupLocation$ CenterScreen=�.��� .+�	� -    	�Name$ 	rbtnSobel��$�� ��$
��Left=�$��	10,10,0,0q�$	��Top=�	� -   $ rbtnLaplacian��$�� ��$
��Left=�$��	10,49,0,0q�$	��Top=�	� -   $ 	rbtnCanny��$�� ��$
��Left=�$��
10,129,0,0q�$	��Top=��� -    ��Name$ 	gboxSobel��$��Sobel��$
��Left=�$��	36,10,0,0q�$	��Top=�$	��246��$��24���� -   $ gboxLaplacian��$��	Laplacian��$
��Left=�$��	36,49,0,0q�$	��Top=�$	��246��$��66��.��� .+��� -    ��Name$ label��$
��Mode��$
��Left=�$��17��$��	10,13,0,0q�$	��Top=��� -    ��Name$ cboxMode��$
��Left=�$��	49,10,0,0q�$	��Top=�$	��120�� �� SelectedIndex$ 0��.@��� $��4-Link���� $��8-Link���� -   $ 	gboxCanny��$��Canny��$
��Left=�$��
36,128,0,0q�$	��Top=�$	��246��$	��130��$��2��.��� .+��� $��Gauss Kernel Size��$
��Left=�$��17��$��	10,13,0,0q�$	��Top=��� -	   $ 	cboxKSize��$
��Left=�$	��Top=�$��76��$ 0��$��
127,10,0,0q�.@��� $��3���� $��5���� $��7���� $��	Threshold��$
��Left=�$��17��$��	10,52,0,0q�$	��Top=�#  Xceed.Wpf.Toolkit.RangeSlider  -
   $��TSlider��$
��Left=�$��	67,36,0,0q�$	��Top=�$	��136��   Maximum$	 255Q�   
LowerValue$ 30Q�	   HigherValue$	 80Q�
   IsSnapToTickEnabled
 . %  Xceed.Wpf.Toolkit.DecimalUpDown  -   $��l��$
��Left=�$��	78,61,0,0q�$	��Top=�$��55���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�   Maximum$	 255X�   Value ��  �� ElementName$ TSlider�� �� Path$ 
LowerValue�  -   $��r��$
��Left=�$��
148,61,0,0q�$	��Top=�$��55��$ 0X�$	 255X� �� $ TSlider��$ HigherValue��� -    ��Name$ btnOK��$��OK��$
��Left=�$��127,267,0,0q�$	��Top=�$��75���� -   $ 	btnCancel��$��Cancel��$
��Left=�$��207,267,0,0q�$	��Top=�$��75��