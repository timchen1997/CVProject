   M S B A M L   `   `   `  ���� D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  )    #CVProject.Dialog.BinarizationDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CVProject.Dialog     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  Binarization��$	��232��$	��420�����	#FF363636 � WindowStartupLocation$ CenterScreen=�.��� .+�	� -    	�Name$ radiobtnManaul��$�� ��$
��Left=�$��	10,10,0,0q�$	��Top=��� -   $��
gboxManaul��$��Manual��$
��Left=�$��	31,10,0,0q�$	��Top=�$	��130��$	��371��.���  � RowDefinitions �� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��30 ��� $��50 ��� $��* ��� $��52 ��� $��50 �.+��� $��R��$��Center=�$��Center=�$��0���� -   $��RInOut��$��0��$��1�� �� SelectedIndex$ 0��$��Center=�$��Center=�.@��� $��in���� $	��out��#  Xceed.Wpf.Toolkit.RangeSlider  -   $��RSlider��$��0��$��2��$��Center=�$��Center=�   Maximum$	 255Q�$	��170��   IsSnapToTickEnabled . %  Xceed.Wpf.Toolkit.DecimalUpDown  -   $
��RLow��$��0��$��3��$��Center=�$��Center=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$	 255X�	   Minimum$	 0X�$��0,0,2,0q�
   Value
 ��  �� ElementName$ RSlider�� �� Path$ 
LowerValue�  -   $��RHigh��$��0��$��4��$��Center=�$��Center=�$	 255X�$	 0X�
 �� $ RSlider��$ HigherValue��� $��G��$��Center=�$��Center=�$��1���� -   $��GInOut��$��1��$��1��$ 0��$��Center=�$��Center=�.@��� $��in���� $	��out��  -   $��GSlider��$��1��$��2��$��Center=�$��Center=�$	 255Q�$	��170�� .   -	   $
��GLow��$��1��$��3��$��Center=�$��Center=�$	 255X�$	 0X�$��0,0,2,0q�
 �� $ GSlider��$ 
LowerValue�  -
   $��GHigh��$��1��$��4��$��Center=�$��Center=�$	 255X�$	 0X�
 �� $ GSlider��$ HigherValue��� $��B��$��Center=�$��Center=�$��2���� -   $��BInOut��$��2��$��1��$ 0��$��Center=�$��Center=�.@��� $��in���� $	��out��  -   $��BSlider��$��2��$��2��$��Center=�$��Center=�$	 255Q�$	��170�� .   -   $
��BLow��$��2��$��3��$��Center=�$��Center=�$	 255X�$	 0X�$��0,0,2,0q�
 �� $ BSlider��$ 
LowerValue�  -   $��BHigh��$��2��$��4��$��Center=�$��Center=�$	 255X�$	 0X�
 �� $ BSlider��$ HigherValue�	� -   $ radiobtnOtsu��$�� ��$
��Left=�$��
10,145,0,0q�$	��Top=��� $
��Otsu��$
��Left=�$��
31,145,0,0q�$	��Top=�$	��371��$��24���� -    ��Name$ 	btnCancel��$��Cancel��$
��Left=�$��327,174,0,0q�$	��Top=�$��75���� -   $ btnOK��$��OK��$
��Left=�$��247,174,0,0q�$	��Top=�$��75��