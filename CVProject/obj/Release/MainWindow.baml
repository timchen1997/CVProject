   M S B A M L   `   `   `  ���� D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CVProject	CVProject      CVProject.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:CVProject     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  
MainWindow��$	��720��$
��1280�����	#FF363636 � 	Resources    openFile_key �� Text  saveFile_key  undo_key  redo_key  cancelSelect_key  copy_key  	paste_key  newFile_key  selectAll_key��%2  &	        &	      &	 0     &	 H     &	 `     &	 x     &	 �     &	 �     &	 �     �� $ Button Click���� $ Button Click���� $ Button Click���� $ Button Click���� $ Button Click���� $ Button Click���� $ Button Click���� $ Button Click���� $ Button Click�� J� InputBindings ��  �� Gesture$ Ctrl+O�� �� Command# [  �� $ Ctrl+S��# [ �� $ Ctrl+Z��# [ �� $ Ctrl+Y��# [ �� $ Ctrl+D��# [ �� $ Ctrl+C��# [ �� $ Ctrl+V��# [ �� $ Ctrl+N��# [ �� $ Ctrl+A��# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -	   # [   -
   # [ .���  � RowDefinitions �� $��25 ��� $��* ��� $��25 �.+�o� $��0��.@�m� $
��File��.@�m� -   $	��New��m� -   $
��Open��m� -   $
��Save��m� -   $��Save As��m� -   $
��Exit��m� $
��Edit��.@�m� $
��Undo��m� $
��Redo��m� -   $��Resize��m� -   $��Rotate��m� -   $	��Cut��m� $
��View��.@�m� -   $��	Histogram��m� $��Image��.@�m� -   $��Binarization��m� -   $��To GrayScale��m� -   $��Smooth��m� -   $��Adjust Color��m� -   $��Edge Detect��m� -   $��Arithmetic Oper��m� -   $��Hough Transform��m� -   $��Adjust Contrast��m� $��
Morphology��.@�m� -   $��Basic��m� -   $
��Thin��m� -   $��Thicken��m� -   $��Distance Transform��m� -    $��	Watershed��m� $
��Help��.@�m� $��About��]� $��1��.+�`� 	 `� Orientation$	 Vertical=�$
��Left=�
 `� 
Background
 �	#FF363636 `� IsLocked . .�c� .@��  � ColumnDefinitions �� $��* ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�d� -!    d�Name$ btnBrush��$��Brush��$��0��$��0��d� -"   $ 	btnEraser��$��Eraser��$��1��$��0��d� -#   $ 	btnCursor��$��Cursor��$��0��$��1��d� -$   $ btnPickColor��$��	PickColor��$��1��$��1��d� -%   $ btnRect��$
��Rect��$��0��$��2��d� -&   $ btnLine��$
��Line��$��1��$��2��d� -'   $ 
btnEllipse��$��Ellipse��$��0��$��3��d� -(   $ 	btnCircle��$��Circle��$��1��$��3��d� -)   $ 	btnSelect��$��Select��$��0��$��4��� .+��� -*    ��Name$ btnBackColor��$��	15,15,3,0q����� .R���  ��Name$ BackColorView��$��40��$��40��
���   ��� -+   $ btnForeColor��$��	3,3,15,15q����� .R��� $ ForeColorView��$��40��$��40��
�������� $��
0, 5, 0, 0q� �� $��* ��� $��16 �.+�%  Xceed.Wpf.Toolkit.DecimalUpDown  -,   $��	thickness��$��0��$��
5, 0, 5, 0q��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 1X�   Maximum$	 255X�   Minimum$ 1X����	#FF333333
��������� $��px��$��1��� $��5,5,5,5q�.+��� --   $��drawMode�� �� SelectedIndex$ 0��.@��� $��Link4���� $��Link8���� $��	AntiAlias��� $��Right=� �� $��* ��� $	��250 �.+�� $��0��.+��� -.    ��Name$
 tabs���� $��1��$
��Left=�$	��177��$��	10,10,0,0q�$	��Top=�$	��230��$��Pixel��.��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF363636�� � Offset$ 0Q�� $ 	#FF424242��$ 1Q�.+��� -/   $ 	colorView��$
��Left=�$��60��$��	10,10,0,0q�$	��Top=�$��60���� $
��X = ��$
��Left=�$��	100,8,0,0q�$	��Top=��� $
��Y = ��$
��Left=�$��
100,31,0,0q�$	��Top=��� $��Red = ��$
��Left=�$��	10,75,0,0q�$	��Top=��� $��Green = ��$
��Left=�$��	10,98,0,0q�$	��Top=��� $��Blue = ��$
��Left=�$��
10,121,0,0q�$	��Top=��� $��Hue = ��$
��Left=�$��
100,75,0,0q�$	��Top=��� $��Saturation = ��$
��Left=�$��
100,98,0,0q�$	��Top=��� $��Brightness = ��$
��Left=�$��100,121,0,0q�$	��Top=��� $��Alpha = ��$
��Left=�$��
100,54,0,0q�$	��Top=��� -0    ��Name$
 SVal��$
��Left=�$��
174,98,0,0q�$	��Top=��� -1   $
 HVal��$
��Left=�$��
174,75,0,0q�$	��Top=��� -2   $
 AVal��$
��Left=�$��
174,54,0,0q�$	��Top=��� -3   $
 YVal��$
��Left=�$��
174,31,0,0q�$	��Top=��� -4   $
 XVal��$
��Left=�$��	174,8,0,0q�$	��Top=��� -5   $
 LVal��$
��Left=�$��174,121,0,0q�$	��Top=��� -6   $
 GVal��$
��Left=�$��	62,98,0,0q�$	��Top=��� -7   $
 BVal��$
��Left=�$��
62,121,0,0q�$	��Top=��� -8   $
 RVal��$
��Left=�$��	62,75,0,0q�$	��Top=��� $��1��$
��Left=�$	��177��$��
10,192,0,0q�$	��Top=�$	��230��$��History��.��� ���	#FF2C2C2C.+��� -9    ��Name$ listBox�����	#FF2C2C2C��Z� ���� .R��� .+��� ���� *description+�� $��1��$
��Left=�$	��177��$��
10,374,0,0q�$	��Top=�$	��230��$��	Histogram��.��� ���	#FF2C2C2C�� $��2�����	#FF212121
����������� .R��  �� $��* ��� $��60 ��� $	��200 ��� $��50 �.@��� $��0��.���� -:    ��Name$ status���� $��1��.���� -;   $ btnReset��$��55��$��Reset���� $��2��.���� $	��190���� $��3��.���� $��48��